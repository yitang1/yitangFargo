﻿using FargowiltasSouls.Content.Items.Accessories.Masomode;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yitangFargo.Common;

namespace yitangFargo.Global
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

            ////混沌传送杖扣血说明
            //if (item.type == ItemID.RodofDiscord)
            //{
            //    tooltips.Replace("导致混沌状态", Language.GetTextValue("Mods.yitangFargo.ContentTexts.RodofDiscord"));
            //    //tooltips.Add(new TooltipLine(Mod, "RodofDiscord", Language.GetTextValue("Mods.yitangFargo.ContentTexts.RodofDiscord")));
            //}
        }
    }
}
