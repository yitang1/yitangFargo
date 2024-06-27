using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;

namespace yitangFargo.Global.FuckFargo.FuckFargoSystem
{
    public class CalamityFargoSystem : ModSystem
    {
        public override void Load()
        {
            On_ChatManager.ParseMessage += Translate;
        }
        public override void Unload()
        {
            On_ChatManager.ParseMessage -= Translate;
        }

        private static List<TextSnippet> Translate(On_ChatManager.orig_ParseMessage orig, string text, Color baseColor)
        {
			//text = Regex.Replace(text, "A new item has been unlocked in Deviantt's shop!", "戴薇安解锁了新商品！");
			text = Regex.Replace(text, "A new item has been unlocked in Deviantt's shop!", "");
			text = Regex.Replace(text, "Rogue Damage: ", "盗贼伤害：");
            text = Regex.Replace(text, "Rogue Critical: ", "盗贼暴击率：");
            return orig.Invoke(text, baseColor);
        }
    }
}