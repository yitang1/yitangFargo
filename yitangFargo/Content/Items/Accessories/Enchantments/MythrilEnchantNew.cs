using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using yitangFargo.Common;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class MythrilEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<MythrilEnchant>() && ytFargoConfig.Instance.OldEnchant)
            {
                player.AddEffect<MythrilEffectNew>(item);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<MythrilEnchant>())
            {
                if (player.HasEffect<MythrilEffectNew>() && player.HasEffect<MythrilEffect>())
                {
                    tooltips.ReplaceText("[MythrilDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[MythrilOld]", "");
                    tooltips.ReplaceText("[MythrilNew]", "");
                }
                else if (player.HasEffect<MythrilEffect>())
                {
                    tooltips.ReplaceText("[MythrilNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.MythrilEnchant.New"));
                    tooltips.ReplaceText("[MythrilOld]", "");
                    tooltips.ReplaceText("[MythrilDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[MythrilOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.MythrilEnchant.Old"));
                    tooltips.ReplaceText("[MythrilNew]", "");
                    tooltips.ReplaceText("[MythrilDouble]", "");
                }
            }
        }
    }

    public class MythrilEffectNew : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EarthHeader>();
        public override int ToggleItemType => ModContent.ItemType<MythrilEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}
