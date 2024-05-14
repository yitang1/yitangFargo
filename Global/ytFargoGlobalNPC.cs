using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Events;
using CalamityMod.Projectiles.Summon;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Content.Projectiles.Minions;
using yitangFargo.Global.Config;
using yitangFargo.NPCs;

namespace yitangFargo.Global
{
    public class ytFargoGlobalNPC : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            Player player = Main.LocalPlayer;
            yitangFargoPlayer modPlayerY = player.yitangFargo();

            for (int k = 0; k < Main.maxPlayers; k++)
            {
                Player playerA = Main.player[k];
                if (!playerA.active)
                {
                    continue;
                }
                if (playerA.inventory.Any(item => item.type == ModContent.ItemType<NinjaEnchant>()))
                {
                    modPlayerY.IamNinja = true;
                }
            }
            //拥有忍者魔石的情况下，击败史莱姆王后会掉下来一个NPC
            if (npc.type == NPCID.KingSlime && modPlayerY.IamNinja && ytFargoConfig.Instance.FCNPC)
            {
                int NinjaNPC = NPC.FindFirstNPC(ModContent.NPCType<Ninja>());

                if (NinjaNPC == -1 && !BossRushEvent.BossRushActive)
                {
                    NPC.NewNPC(npc.GetSource_Death(), (int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Ninja>(), 0, 0f, 0f, 0f, 0f, 255);
                }
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            //沉沦之贝，咬咬咬
            if (npc.Calamity().shellfishVore > 0)
            {
                int projectileCount = 0;
                int owner = 255;
                for (int j = 0; j < Main.maxProjectiles; j++)
                {
                    if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType<ShellfishNew>() &&
                        Main.projectile[j].ai[0] == 1f && Main.projectile[j].ai[1] == npc.whoAmI)
                    {
                        owner = Main.projectile[j].owner;
                        projectileCount++;
                        if (projectileCount >= 5)
                        {
                            projectileCount = 5;
                            break;
                        }
                    }
                }

                Item heldItem = Main.player[owner].ActiveItem();
                int totalDamage = (int)Main.player[owner].GetTotalDamage<SummonDamageClass>().ApplyTo(140f);
                bool forbidden = Main.player[owner].head == ArmorIDs.Head.AncientBattleArmor && Main.player[owner].body == ArmorIDs.Body.AncientBattleArmor && Main.player[owner].legs == ArmorIDs.Legs.AncientBattleArmor;
                bool reducedNerf = Main.player[owner].Calamity().fearmongerSet || (forbidden && heldItem.CountsAsClass<MagicDamageClass>());

                double summonNerfMult = reducedNerf ? 0.75 : 0.5;
                if (!Main.player[owner].Calamity().profanedCrystalBuffs)
                {
                    if (heldItem.type > ItemID.None)
                    {
                        if (!heldItem.CountsAsClass<SummonDamageClass>() &&
                            (heldItem.CountsAsClass<MeleeDamageClass>() || heldItem.CountsAsClass<RangedDamageClass>() || heldItem.CountsAsClass<MagicDamageClass>() || heldItem.CountsAsClass<ThrowingDamageClass>()) &&
                            heldItem.hammer == 0 && heldItem.pick == 0 && heldItem.axe == 0 && heldItem.useStyle != 0 &&
                            !heldItem.accessory && heldItem.ammo == AmmoID.None)
                        {
                            totalDamage = (int)(totalDamage * summonNerfMult);
                        }
                    }
                }

                int totalDisplayedDamage = totalDamage / 5;
                npc.Calamity().ApplyDPSDebuff(projectileCount * totalDamage, projectileCount * totalDisplayedDamage, ref npc.lifeRegen, ref damage);
            }
        }
    }
}
