using CalamityMod.Items;
using CalamityMod.Items.PermanentBoosters;
using CalamityMod.Items.SummonItems;
using FargowiltasSouls.Content.Items;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using yitangFargo.Common;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class CalamityFargoTooltips : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            //突变体的礼物
            if (item.type == ModContent.ItemType<Masochist>())
            {
                tooltips.Replace("[c/FF0000:Calamity Crossmod Support:] Disabled. Use Calamity's difficulty UI instead!", "已禁用\n请到灾厄的难度指示器UI里切换难度");
            }
            //终末石
            if (item.type == ModContent.ItemType<Terminus>())
            {
                tooltips.Replace("[c/FF0000:Calamity Crossmod Support:] Can only be used after defeating the Mutant", "只能在击败突变体后使用");
            }
            //天体洋葱
            if (item.type == ModContent.ItemType<CelestialOnion>())
            {
                tooltips.Replace("[c/FF0000:{BalanceLine}]Is now an upgrade to [i:{ModContent.ItemType<MutantsPact>()}]Mutant's Pact, that allows any accessory in the extra slot.", "现在可作为对[i:{ModContent.ItemType<MutantsPact>()}]的升级\n可以允许在额外的魂石饰品栏中装备任何饰品");
            }
            //古恒石
            if (item.type == ModContent.ItemType<Rock>())
            {
                tooltips.Replace("[c/AAAAAA:Sold by Squirrel]", "");
            }
        }
    }
}
