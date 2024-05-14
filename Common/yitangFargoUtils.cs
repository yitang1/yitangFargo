using FargowiltasSouls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Common
{
    public static class yitangFargoUtils
    {
        public static yitangFargoPlayer yitangFargo(this Player player)
        {
            return player.GetModPlayer<yitangFargoPlayer>();
        }

        public static void Replace(this List<TooltipLine> tooltips, string oldValue, string newValue)
        {
            TooltipLine value = Enumerable.FirstOrDefault<TooltipLine>(tooltips, (TooltipLine x) => x.Text.Contains(oldValue));
            if (value != null)
            {
                value.Text = value.Text.Replace(oldValue, newValue);
            }
        }

        public static void ReplaceText(this List<TooltipLine> tooltips, string replacedKey, string newKey)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Text.Contains(replacedKey));
            if (line != null)
                line.Text = line.Text.Replace(replacedKey, newKey);
        }

        public static void DrawInventoryCustomScale(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale, float wantedScale = 1f, Vector2 drawOffset = default)
        {
            wantedScale = Math.Max(scale, wantedScale * Main.inventoryScale);
            float scaleDifference = wantedScale - scale;
            position += drawOffset * wantedScale;
            spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, wantedScale, SpriteEffects.None, 0);
        }

        public static bool CanDeleteProjectile(Projectile projectile, int deletionRank = 0, bool clearSummonProjs = false)
        {
            if (!projectile.active)
                return false;
            if (projectile.damage <= 0)
                return false;
            if (projectile.FargoSouls().DeletionImmuneRank > deletionRank)
                return false;
            if (projectile.friendly)
            {
                if (projectile.whoAmI == Main.player[projectile.owner].heldProj)
                    return false;
                if (FargoSoulsUtil.IsSummonDamage(projectile, false) && !clearSummonProjs)
                    return false;
            }
            return true;
        }

        public static void ClearFriendlyProjectiles(int deletionRank = 0, int bossNpc = -1, bool clearSummonProjs = false)
        {
            ClearProjectiles(false, true, deletionRank, bossNpc, clearSummonProjs);
        }

        public static void ClearHostileProjectiles(int deletionRank = 0, int bossNpc = -1)
        {
            ClearProjectiles(true, false, deletionRank, bossNpc);
        }

        public static void ClearAllProjectiles(int deletionRank = 0, int bossNpc = -1, bool clearSummonProjs = false)
        {
            ClearProjectiles(true, true, deletionRank, bossNpc, clearSummonProjs);
        }

        private static void ClearProjectiles(bool clearHostile, bool clearFriendly, int deletionRank = 0, int bossNpc = -1, bool clearSummonProjs = false)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            if (OtherBossAlive(bossNpc))
                clearHostile = false;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    Projectile projectile = Main.projectile[i];
                    if (projectile.active && ((projectile.hostile && clearHostile) || (projectile.friendly && clearFriendly)) && CanDeleteProjectile(projectile, deletionRank, clearSummonProjs))
                    {
                        projectile.Kill();
                    }
                }
            }
        }

        public static bool OtherBossAlive(int npcID)
        {
            if (npcID > -1 && npcID < Main.maxNPCs)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].boss && i != npcID)
                        return true;
                }
            }
            return false;
        }

        public static int HighestDamageTypeScaling(Player player, int dmg)
        {
            return (int)(new List<float>
            {
                player.ActualClassDamage(DamageClass.Melee),
                player.ActualClassDamage(DamageClass.Ranged),
                player.ActualClassDamage(DamageClass.Magic),
                player.ActualClassDamage(DamageClass.Summon)
            }.Max() * (float)dmg);
        }
    }
}
