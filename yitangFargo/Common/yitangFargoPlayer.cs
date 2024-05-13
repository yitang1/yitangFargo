using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangFargo.Content.Buffs;
using yitangFargo.Content.Items.Accessories.Enchantments;
using yitangFargo.Global.FuckFargo.FuckFargoSystem;

namespace yitangFargo.Common
{
    public class yitangFargoPlayer : ModPlayer
    {
        public override void ResetEffects()
        {
            MinionCritsYT = false;
            AttackSpeed = 1f;
            DisruptedFocus = false;
            VenomMinions = false;
            VenomNecklace = false;
            IamNinja = false;
            if (WizardEnchantActiveNew)
            {
                WizardEnchantActiveNew = false;
                for (int i = 3; i <= 11; i++)
                {
                    if (!Player.armor[i].IsAir && (Player.armor[i].type == ModContent.ItemType<WizardEnchant>() || Player.armor[i].type == ModContent.ItemType<CosmoForce>()))
                    {
                        WizardEnchantActiveNew = true;
                        break;
                    }
                }
            }
        }

        public override void UpdateDead()
        {
            WizardEnchantActiveNew = false;
            DisruptedFocus = false;
        }

        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            GlobalSystemFC.BalanceWeaponStats(Player, item, ref damage);
        }

        public override void PostUpdateEquips()
        {
            //冰冻海龟壳的削弱回调
            if (Player.iceBarrier)
            {
                Player.GetDamage(DamageClass.Generic) += 0.10f;
            }
            //十字项链连续受击也依然触发无敌时间
            if (!Player.longInvince && !Player.immune)
            {
                if (CrossNecklaceTimer < 20)
                {
                    Player.longInvince = true;
                    CrossNecklaceTimer++;
                }
            }
            else
            {
                CrossNecklaceTimer = 0;
            }
        }

        public override void PostUpdateMiscEffects()
        {
            //提基魔石的无限召唤栏
            if (Player.HasEffect<TikiEffectNew>())
            {
                actualMinions = Player.maxMinions;
                Player.maxMinions = 999;

                if (Player.slotsMinions > actualMinions)
                {
                    TikiMinion = true;
                }

                actualSentries = Player.maxTurrets;
                Player.maxTurrets = 999;

                if (getNumSentries() > actualSentries)
                {
                    TikiSentry = true;
                }
            }
            //鞭子攻速如何再次受近战攻速加成的影响？(强制赋值的操作让俺真的不知道怎么回调了)
            //if (Player.HeldItem.shoot > ProjectileID.None && ProjectileID.Sets.IsAWhip[Player.HeldItem.shoot])
            //{
            //    Player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.5f;
            //}
        }
        //对当前召唤出的哨兵数量的检测 (原版没有slotsMinions那样的字段)
        private int getNumSentries()
        {
            int count = 0;

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];

                if (p.active && p.owner == Player.whoAmI && p.sentry)
                {
                    count++;
                }
            }
            return count;
        }

        public override float UseSpeedMultiplier(Item item)
        {
            int useTime = item.useTime;
            int useAnimate = item.useAnimation;

            if (useTime <= 0 || useAnimate <= 0 || item.damage <= 0)
            {
                return base.UseSpeedMultiplier(item);
            }

            bool forceEffect = Player.FargoSouls().ForceEffect(item.type);

            //旧版忍者魔石 攻速翻倍
            if (Player.HasEffect<NinjaEffectNew>())
            {
                AttackSpeed *= 2f;
                //召唤杖不要攻速翻倍，不然一次会召唤好几个
                if (item.DamageType == DamageClass.Summon && !ProjectileID.Sets.IsAWhip[Player.HeldItem.shoot])
                {
                    AttackSpeed /= 2f;
                }
            }
            //旧版秘银魔石 攻速提升
            if (!Player.HasBuff<DisruptedFocus>() && Player.HasEffect<MythrilEffectNew>())
            {
                float Mythrilspeed = forceEffect ? 0.3f : 0.15f;
                AttackSpeed += Mythrilspeed;
                if (item.DamageType == DamageClass.Summon && !ProjectileID.Sets.IsAWhip[Player.HeldItem.shoot])
                {
                    AttackSpeed -= Mythrilspeed;
                }
            }

            while (useTime / AttackSpeed < 1)
            {
                AttackSpeed -= 0.01f;
            }
            while (useAnimate / AttackSpeed < 3)
            {
                AttackSpeed -= 0.01f;
            }
            if (AttackSpeed < 0.1f)
            {
                AttackSpeed = 0.1f;
            }
            return AttackSpeed;
        }

        public void ModifyHitNPCBoth(NPC target, ref NPC.HitModifiers modifiers, DamageClass damageClass)
        {
            //蜘蛛魔石的召唤暴击伤害
            modifiers.ModifyHitInfo += (ref NPC.HitInfo hitInfo) =>
            {
                if (hitInfo.Crit)
                {
                    if (MinionCritsYT && damageClass.CountsAsClass(DamageClass.Summon))
                    {
                        hitInfo.Damage = (int)(hitInfo.Damage / 0.75);
                    }
                }
            };
        }

        public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers)
        {
            //旧版忍者魔石 伤害减半(对于真近战武器，即无射弹的武器)
            if (Player.HasEffect<NinjaEffectNew>())
            {
                modifiers.FinalDamage /= 2f;
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            //保暖药水
            if (Player.resistCold && proj.coldDamage)
            {
                modifiers.SourceDamage /= 1.15f;
            }
            //旧版忍者魔石 伤害减半(对于有射弹的武器)
            if (Player.HasEffect<NinjaEffectNew>())
            {
                modifiers.FinalDamage /= 2f;
            }

            //旧版提基魔石 召唤物造成的伤害降低
            /*如果仆从和哨兵同时超出了各自的最大栏位，那么如果有一项符合条件就会影响全部。
            举例：原本最大仆从和哨兵栏位各自只有1个，
            但如果召唤出来的仆从存在6个 + 哨兵存在2个，那么此时仆从和哨兵造成的伤害皆降低95%。*/
            float damageMult = 1f;
            float extraSlotM = Player.slotsMinions - actualMinions;
            float extraSlotS = getNumSentries() - actualSentries;
            if (proj.DamageType == DamageClass.Summon && (TikiMinion || TikiSentry))
            {
                if ((Player.slotsMinions > actualMinions) || (getNumSentries() > actualSentries))
                {
                    if ((extraSlotM >= 1 && extraSlotM < 5) || (extraSlotS >= 1 && extraSlotS < 5))
                    {
                        damageMult = 0.3f;  //对于额外召唤的1到4个召唤物，其伤害降低70%
                    }
                    if ((extraSlotM >= 5) || (extraSlotS >= 5))
                    {
                        damageMult = 0.05f;  //对于额外召唤的第5个及以上的召唤物，其伤害降低95%
                    }
                }
                modifiers.SourceDamage *= damageMult;
            }

            ModifyHitNPCBoth(target, ref modifiers, proj.DamageType);
        }

        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            float dr = 0;
            dr += Player.AccessoryEffects().ContactDamageDR(npc, ref modifiers);
            ApplyDR(Player, dr, ref modifiers);

            //保暖药水
            if (Player.resistCold && npc.coldDamage)
            {
                modifiers.FinalDamage /= 1.15f;
            }
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Player.whoAmI != Main.myPlayer)
                return;

            NPCDebuffs(target, item.CountsAsClass<MeleeDamageClass>(),
                item.CountsAsClass<RangedDamageClass>(),
                item.CountsAsClass<MagicDamageClass>(),
                item.CountsAsClass<SummonDamageClass>(),
                item.CountsAsClass<ThrowingDamageClass>(),
                item.CountsAsClass<SummonMeleeSpeedDamageClass>());
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Player.whoAmI != Main.myPlayer)
                return;

            if (!proj.npcProj && !proj.trap && proj.friendly)
            {
                NPCDebuffs(target, proj.CountsAsClass<MeleeDamageClass>(),
                    proj.CountsAsClass<RangedDamageClass>(),
                    proj.CountsAsClass<MagicDamageClass>(),
                    proj.CountsAsClass<SummonDamageClass>(),
                    proj.CountsAsClass<ThrowingDamageClass>(),
                    proj.CountsAsClass<SummonMeleeSpeedDamageClass>(), true, proj.noEnchantments);
            }
        }

        //移除Fargo魂设定的75%伤害减免上限的限制
        private void ApplyDR(Player player, float dr, ref Player.HurtModifiers modifiers)
        {
            float DRCap = 0.75f;
            player.endurance += dr;
            float DRFix = Player.endurance - DRCap;
            if (WorldSavingSystem.EternityMode)
            {
                if (DRFix >= 0)
                {
                    player.endurance += DRFix;
                }
            }
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            //猩红魔石的受伤判定
            if (Player.HasEffect<CrimsonEffectNew>())
            {
                CrimsonEffectNew.CrimsonHurt(Player, this, ref modifiers);
            }
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (Player.HasEffect<MythrilEffectNew>())
            {
                Player.AddBuff(ModContent.BuffType<DisruptedFocus>(), 300);
            }
        }

        public void AddMinion(Item item, bool toggle, int proj, int damage, float knockback)
        {
            if (Player.whoAmI != Main.myPlayer) return;
            if (Player.ownedProjectileCounts[proj] < 1 && Player.whoAmI == Main.myPlayer && toggle)
            {
                FargoSoulsUtil.NewSummonProjectile(Player.GetSource_Accessory(item), Player.Center, -Vector2.UnitY, proj, damage, knockback, Main.myPlayer);
            }
        }

        public void NPCDebuffs(NPC target, bool melee, bool ranged, bool magic, bool summon, bool rogue, bool whip, bool proj = false, bool noFlask = false)
        {
            if (summon)
            {
                if (VenomMinions)
                {
                    target.AddBuff(BuffID.Venom, 180);
                }
            }
            if (VenomNecklace)
            {
                target.AddBuff(BuffID.Venom, 120);
            }
        }

        public bool MinionCritsYT;
        public float AttackSpeed;
        public bool WizardEnchantActiveNew;
        public int CrimsonRegenAmount;
        public bool TikiMinion;
        public int actualMinions;
        public bool TikiSentry;
        public int actualSentries;
        public int MeteorTimer;
        public int MeteorCD = 60;
        public bool MeteorShower;
        public int CrossNecklaceTimer;
        public bool DisruptedFocus;
        public bool VenomMinions = false;
        public bool VenomNecklace = false;
        public bool IamNinja = false;
    }
}
