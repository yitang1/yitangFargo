using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using CalamityMod.Items;
using CalamityMod.Items.PermanentBoosters;
using CalamityMod.Items.SummonItems;
using FargowiltasSouls.Content.Items;
using yitangFargo.Common;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Terraria.ID;
using CalamityMod.Items.Accessories;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Accessories.Souls;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class CalamityFargoTooltips : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            #region 灾法平衡
            foreach (TooltipLine tooltipLine in tooltips)
            {
                tooltipLine.Text = tooltipLine.Text.Replace("[c/00A36C:Cross-mod Balance: ]", "");
                tooltipLine.Text = tooltipLine.Text.Replace("[c/FF0000:Cross-mod Balance: ]", "");

                tooltipLine.Text = tooltipLine.Text.Replace("Accumulated damage capped at 500.000", "累计伤害上限为500");
            }

            if (item.type == ItemID.MagicDagger)
            {
                tooltips.Replace("Damage decreased by 50% in Pre-Hardmode.", "");
            }
            if (item.type == ModContent.ItemType<ProfanedSoulCrystal>())
            {
                tooltips.Replace("Massively reduced damage with any minions active", "");
            }
            if (item.type == ModContent.ItemType<TungstenEnchant>())
            {
                tooltips.Replace("Less effective on true melee weapons", "");
            }
            if (item.type == ModContent.ItemType<MythrilEnchant>())
            {
                tooltips.Replace("Less effective on rogue weapons", "");
            }
            if (item.type == ModContent.ItemType<OrichalcumEnchant>())
            {
                tooltips.Replace("Reduced effectiveness", "");
            }
            if (item.type == ModContent.ItemType<DaawnlightSpiritOrigin>())
            {
                tooltips.Replace("Effect disabled while Tin Enchantment effect is active", "");
            }
            if (item.type == ModContent.ItemType<SlimyShield>())
            {
                tooltips.Replace("Does not inflict Oiled", "");
            }
            if (item.ModItem != null && item.ModItem is FlightMasteryWings)
            {
                tooltips.Replace("Flight stats decreased when fighting non-Souls Mod bosses", "");
            }
            if (item.type == ItemID.CobaltSword || item.type == ItemID.PalladiumSword ||
                item.type == ItemID.OrichalcumSword || item.type == ItemID.MythrilSword ||
                item.type == ItemID.OrichalcumHalberd)
            {
                tooltips.Replace("Stat buffs decreased", "");
            }

            #endregion

            #region 通用/其他
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
                tooltips.Replace("[c/FF0000:{BalanceLine}]Is now an upgrade to [i:{ModContent.ItemType<MutantsPact>()}]Mutant's Pact, that allows any accessory in the extra slot.", "");
            }
            //古恒石
            if (item.type == ModContent.ItemType<Rock>())
            {
                tooltips.Replace("[c/AAAAAA:Sold by Squirrel]", "");
            }

            if (item.ModItem != null && item.ModItem is BaseEnchant)
            {
                tooltips.Replace($" [i:{ModContent.ItemType<WizardEnchant>()}]: ", $"[i:{ModContent.ItemType<WizardEnchant>()}] ");
                //tooltips.Replace(" [i:", "[i:");
                //tooltips.Replace("]:", "]");
            }
            #endregion
        }
    }
}