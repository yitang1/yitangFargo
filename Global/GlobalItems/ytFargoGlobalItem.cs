using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CalamityMod.Items.PermanentBoosters;
using FargowiltasSouls.Content.Items.Consumables;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using yitangFargo.Common;
using yitangFargo.Content.Items.Accessories.Souls;

namespace yitangFargo.Global.GlobalItems
{
    public class ytFargoGlobalItem : GlobalItem
    {
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ModContent.ItemType<CelestialOnion>())
            {
                return false;
            }
            if (item.type == ModContent.ItemType<MutantsPact>() && player.yitangFargo().celestialSeal)
            {
                return false;
            }
            return true;
        }

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

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemID.DemonHeart, 1, 1, 1));
            }
        }
    }
}