using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Events;
using CalamityMod.Projectiles.Summon;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.NPCs;
using yitangFargo.Global.Config;
using yitangFargo.Common;
using yitangFargo.Content.Projectiles.Minions;

namespace yitangFargo.Global
{
    public class ytFargoGlobalNPC : GlobalNPC
    {
		public override bool InstancePerEntity => true;

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
                    yitangFargoSystem.hasChatedNinja++;
                }
            }   
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            //忍者NPC第一次在世界中成功生成的时候，hasChatedNinja字段经过++变为1，触发下面的对话。
            if (npc.type == ModContent.NPCType<Ninja>() && yitangFargoSystem.hasChatedNinja == 1)
            {
                chat = "呃……这里是？泰拉人，是你把我救出来的吗？我的天……谢谢你……";
                yitangFargoSystem.hasChatedNinja = 2;
            }
            /*触发过上面的第一次对话内容后，字段被赋值为2，此时这个方法内的对话都不满足条件，以后都不会触发。
            ★除非忍者NPC又死亡了，那么此时又经历了一次hasChatedNinja++，此时字段变为3，
            那么触发下面对话，现在这是玩家对第二次刚刚生成的NPC对话。*/
            if (npc.type == ModContent.NPCType<Ninja>() && yitangFargoSystem.hasChatedNinja > 2)
            {
                chat = "呃呃……我好像经历了什么轮回，怎么又会进到史莱姆王的肚子里呢？";
                yitangFargoSystem.hasChatedNinja = 2;
            }
            //之后字段又被重新设为2，
            //如果NPC第三次或三次以上再次死亡，那么字段又变为3，继续触发第二条对话，之后又会重设为2，循环。
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
			Player player = Main.player[Main.myPlayer];

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