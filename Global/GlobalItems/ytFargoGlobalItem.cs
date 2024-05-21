﻿using FargowiltasSouls.Content.Items.Accessories.Masomode;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yitangFargo.Common;
using yitangFargo.Content.Items.Accessories.Souls;

namespace yitangFargo.Global.GlobalItems
{
    public class ytFargoGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            void ApplyTooltipEdits(IList<TooltipLine> lines, Func<Item, TooltipLine, bool> predicate, Action<TooltipLine> action)
            {
                foreach (TooltipLine line in lines)
                    if (predicate.Invoke(item, line))
                        action.Invoke(line);
            }
            Func<Item, TooltipLine, bool> LineNum(int n) => (Item i, TooltipLine l) => l.Mod == "Terraria" && l.Name == $"Tooltip{n}";
            void EditTooltipByNum(int lineNum, Action<TooltipLine> action) => ApplyTooltipEdits(tooltips, LineNum(lineNum), action);

            //蒂姆的秘药，添加药水掉落清单
            if (item.type == ModContent.ItemType<TimsConcoction>())
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    EditTooltipByNum(0, (line) => line.Text += "\n" + Language.GetTextValue("Mods.yitangFargo.ContentTexts.TimsConcoction"));
                    return;
                }
                EditTooltipByNum(0, (line) => line.Text += "\n" + Language.GetTextValue("Mods.yitangFargo.ContentTexts.CommonTips"));
            }

            TooltipLine nameLine = tooltips.FirstOrDefault(x => x.Name == "ItemName" && x.Mod == "Terraria");
            if (nameLine != null)
            {
                SpecialRarityColor(item, nameLine);
            }

            ////混沌传送杖扣血说明
            //if (item.type == ItemID.RodofDiscord)
            //{
            //    tooltips.Replace("导致混沌状态", Language.GetTextValue("Mods.yitangFargo.ContentTexts.RodofDiscord"));
            //    //tooltips.Add(new TooltipLine(Mod, "RodofDiscord", Language.GetTextValue("Mods.yitangFargo.ContentTexts.RodofDiscord")));
            //}
        }
        private void SpecialRarityColor(Item item, TooltipLine nameLine)
        {
            if (item.type == ModContent.ItemType<BerserkerSoulNew>())
            {
                nameLine.OverrideColor = new Color(255, 111, 6);
            }
            if (item.type == ModContent.ItemType<SnipersSoulNew>())
            {
                nameLine.OverrideColor = new Color(188, 253, 68);
            }
            if (item.type == ModContent.ItemType<ColossusSoulNew>())
            {
                nameLine.OverrideColor = new Color(252, 59, 0);
            }
            if (item.type == ModContent.ItemType<SupersonicSoulNew>())
            {
                nameLine.OverrideColor = new Color(238, 0, 69);
            }
            if (item.type == ModContent.ItemType<TrawlerSoulNew>())
            {
                nameLine.OverrideColor = new Color(0, 238, 125);
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (!ModLoader.HasMod("yitangCN"))
            {
                //十字章护身符和十字章护盾因为配方里新加了暖手宝，所以免疫冷冻和冰冻
                if (item.type == ItemID.AnkhCharm)
                {
                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;
                }
                if (item.type == ItemID.AnkhShield)
                {
                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;
                    player.buffImmune[BuffID.WindPushed] = true; //添加灾厄免疫强风的设定
                }
            }
        }
    }
}
