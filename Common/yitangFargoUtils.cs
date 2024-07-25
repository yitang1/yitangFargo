using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;

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
			{
                line.Text = line.Text.Replace(replacedKey, newKey);
			}
        }
        //物品名字在两种以上的颜色之间切换
        //public static Color ColorSwap(Color firstColor, Color secondColor, float seconds)
        //{
        //    double timeMult = (double)(MathHelper.TwoPi / seconds);
        //    float colorMePurple = (float)((Math.Sin(timeMult * Main.GlobalTimeWrappedHourly) + 1) * 0.5f);
        //    return Color.Lerp(firstColor, secondColor, colorMePurple);
        //}

        public static void DrawInventoryCustomScale(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale, float wantedScale = 1f, Vector2 drawOffset = default)
        {
            wantedScale = Math.Max(scale, wantedScale * Main.inventoryScale);
            float scaleDifference = wantedScale - scale;
            position += drawOffset * wantedScale;
            spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, wantedScale, SpriteEffects.None, 0);
        }
    }
}