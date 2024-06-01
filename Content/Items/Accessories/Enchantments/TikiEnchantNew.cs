using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class TikiEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<TikiEnchant>() && ytFargoConfig.Instance.OldEnchant)
            {
                player.AddEffect<TikiEffectNew>(item);
                if (player.FargoSouls().ForceEffect<TikiEnchant>())
                {
                    player.whipRangeMultiplier += 0.1f;
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<TikiEnchant>())
            {
                if (player.HasEffect<TikiEffectNew>() && player.HasEffect<TikiEffect>())
                {
                    tooltips.ReplaceText("[TikiDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[TikiOld]", "");
                    tooltips.ReplaceText("[TikiNew]", "");
                }
                else if (player.HasEffect<TikiEffect>())
                {
                    tooltips.ReplaceText("[TikiNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.TikiEnchant.New"));
                    tooltips.ReplaceText("[TikiOld]", "");
                    tooltips.ReplaceText("[TikiDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[TikiOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.TikiEnchant.Old"));
                    tooltips.ReplaceText("[TikiNew]", "");
                    tooltips.ReplaceText("[TikiDouble]", "");
                }
            }
        }
    }

    public class TikiEffectNew : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<SpiritHeader>();
        public override int ToggleItemType => ModContent.ItemType<TikiEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}