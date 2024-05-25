using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;

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
            text = Regex.Replace(text, "A new item has been unlocked in Deviantt's shop!", "戴薇安解锁了新商品！");
            return orig.Invoke(text, baseColor);
        }
    }
}
