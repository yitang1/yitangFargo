using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using CalamityMod;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.Systems;
using FargowiltasCrossmod.Core.Calamity.Globals;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Common;
using yitangFargo.Content.Buffs;
using yitangFargo.Content.Items.Others;
using yitangFargo.Content.Items.Accessories.Enchantments;
using yitangFargo.Global.FuckFargo.FuckFargoSystem;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Common
{
    public class yitangFargoPlayer : ModPlayer
    {
        public override void ResetEffects()
        {
            MinionCritsYT = false;
            //AttackSpeed = 1f;
            VenomMinions = false;
            VenomNecklace = false;
            IamNinja = false;
            DesertProwlerBonus = false;
			LunicCorpsShield = false;
        }

		public override void UpdateDead()
		{
			DesertProwlerBonus = false;
		}

		public override void Initialize()
        {
            celestialSeal = false;
        }
        public override void SaveData(TagCompound tag)
        {
            tag["CelestialSeal"] = celestialSeal;
        }

        public override void LoadData(TagCompound tag)
        {
            celestialSeal = tag.GetBool("CelestialSeal");
        }

		public bool CelestialSealEnabled = false;
		public override void PostUpdate()
        {
            if (Player.yitangFargo().celestialSeal)
            {
				DropPactSlot();
				Player.Calamity().extraAccessoryML = false;
				Player.FargoSouls().MutantsPactSlot = false;
				Player.GetModPlayer<CalExtraSlotPlayer>().MutantPactShouldBeEnabled = false;
				CelestialSealEnabled = true;
			}
			else if (!Player.yitangFargo().celestialSeal)
			{
				CelestialSealEnabled = false;
			}
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

        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            GlobalSystemFC.BalanceWeaponStats(Player, item, ref damage);
        }

        public override float UseSpeedMultiplier(Item item)
        {
			//int useTime = item.useTime;
			//int useAnimate = item.useAnimation;

			//if (useTime <= 0 || useAnimate <= 0 || item.damage <= 0)
			//{
			//    return base.UseSpeedMultiplier(item);
			//}
			FargoSoulsPlayer fargoPlayer = Player.FargoSouls();

			//旧版忍者魔石 攻速翻倍
			if (Player.HasEffect<NinjaEffectNew>())
			{
				fargoPlayer.AttackSpeed *= 2f;
				//召唤杖、消耗物品不吃加成
				if (item.DamageType == DamageClass.Summon && !ProjectileID.Sets.IsAWhip[Player.HeldItem.shoot]
					|| item.damage <= 0)
				{
					fargoPlayer.AttackSpeed /= 2f;
				}
			}
			//旧版秘银魔石 攻速提升
			bool forceEffect = Player.FargoSouls().ForceEffect(item.type);

			if (!Player.HasBuff<DisruptedFocus>() && Player.HasEffect<MythrilEffectNew>())
			{
				float MythrilSpeed = forceEffect ? 0.3f : 0.15f;
				fargoPlayer.AttackSpeed += MythrilSpeed;
				if (item.DamageType == DamageClass.Summon && !ProjectileID.Sets.IsAWhip[Player.HeldItem.shoot]
					|| item.damage <= 0)
				{
					fargoPlayer.AttackSpeed -= MythrilSpeed;
				}
			}
			//while (useTime / AttackSpeed < 1)
			//{
			//    AttackSpeed -= 0.01f;
			//}
			//while (useAnimate / AttackSpeed < 3)
			//{
			//    AttackSpeed -= 0.01f;
			//}
			//if (AttackSpeed < 0.1f)
			//{
			//    AttackSpeed = 0.1f;
			//}
			return fargoPlayer.AttackSpeed;
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
                    if (Player.HasBuff<DesertProwlerBuff>())
                    {
                        hitInfo.Damage *= 2;
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

            FargoSoulsPlayer fargoPlayer = Player.FargoSouls();
            if (Player.HasEffect<TungstenEffect>() && fargoPlayer.Toggler != null
                && (fargoPlayer.ForceEffect<TungstenEnchant>() || item.shoot == ProjectileID.None))
            {
                TungstenTrueMeleeDamageUnNerf(Player, ref modifiers, item);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            //保暖药水
            if (Player.resistCold && proj.coldDamage)
            {
                modifiers.SourceDamage /= 1.15f;
            }
            //旧版忍者魔石 伤害减半(对于武器的射弹)
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

            if (Player.HasEffect<TungstenEffect>() && proj.FargoSouls().TungstenScale != 1)
            {
                TungstenTrueMeleeDamageUnNerf(Player, ref modifiers);
            }
        }

        public static void TungstenTrueMeleeDamageUnNerf(Player player, ref NPC.HitModifiers modifiers, Item item = null)
        {
            if (item == null)
                item = player.HeldItem;
            if (item != null && (item.DamageType == ModContent.GetInstance<TrueMeleeDamageClass>()
                || item.DamageType == ModContent.GetInstance<TrueMeleeNoSpeedDamageClass>()))
                modifiers.FinalDamage *= 1.15f;
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
			if (Player == Main.LocalPlayer)
			{
				//猩红魔石的受伤判定
				if (Player.HasEffect<CrimsonEffectNew>())
				{
					CrimsonEffectNew.CrimsonHurt(Player, this, ref modifiers);
				}
				//雷神之锤魔石
				if (LunicCorpsShield)
				{
					modifiers.FinalDamage -= (int)50;
				}
			}
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (Player.HasEffect<MythrilEffectNew>())
            {
                Player.AddBuff(ModContent.BuffType<DisruptedFocus>(), 300);
            }
			if (Player.HasEffect<DLunicCorpsEffect>())
			{
				LunicCorpsCooldown = 420;
			}
        }

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (CalamityKeybinds.ArmorSetBonusHotKey.JustPressed)
			{
				//沙漠巡游者魔石
				if (DesertProwlerBonus && DesertProwlerCooldown <= 0)
				{
					if (Player.whoAmI == Main.myPlayer)
					{
						Player.AddBuff(ModContent.BuffType<DesertProwlerBuff>(), 600, false);
						DesertProwlerCooldown = 2100;
					}
				}
			}
		}

		public override void PreUpdate()
		{
			if (DesertProwlerCooldown > 0)
			{
				DesertProwlerCooldown--;
			}
			if (LunicCorpsCooldown > 0)
			{
				LunicCorpsCooldown--;
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

        private void DropPactSlot()
        {
			if (!CelestialSealEnabled)
			{
				void DropItem(Item item)
				{
					Item.NewItem(Player.GetSource_DropAsItem(), Player.Center, item);
				}
				void DropSlot(ref ModAccessorySlot slot)
				{
					DropItem(slot.FunctionalItem);
					slot.FunctionalItem = new();
					DropItem(slot.VanityItem);
					slot.VanityItem = new();
					DropItem(slot.DyeItem);
					slot.DyeItem = new();
				}
				ModAccessorySlot eSlot0 = LoaderManager.Get<AccessorySlotLoader>().Get(ModContent.GetInstance<EModeAccessorySlot0>().Type, Player);
				ModAccessorySlot eSlot1 = LoaderManager.Get<AccessorySlotLoader>().Get(ModContent.GetInstance<EModeAccessorySlot1>().Type, Player);
				ModAccessorySlot eSlot2 = LoaderManager.Get<AccessorySlotLoader>().Get(ModContent.GetInstance<EModeAccessorySlot2>().Type, Player);
				DropSlot(ref eSlot0);
				DropSlot(ref eSlot1);
				DropSlot(ref eSlot2);
			}
        }

        public bool MinionCritsYT;
        //public float AttackSpeed;
        public int CrimsonRegenAmount;
        public bool TikiMinion;
        public int actualMinions;
        public bool TikiSentry;
        public int actualSentries;
        public int MeteorTimer;
        public int MeteorCD = 60;
        public bool MeteorShower;
        public int CrossNecklaceTimer;
        public bool VenomMinions = false;
        public bool VenomNecklace = false;
        public bool IamNinja = false;
        public bool celestialSeal;
        public bool DesertProwlerBonus;
		public int DesertProwlerCooldown;
		public bool LunicCorpsShield;
		public int LunicCorpsCooldown;
	}
}