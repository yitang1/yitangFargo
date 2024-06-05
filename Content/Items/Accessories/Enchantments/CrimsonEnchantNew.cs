using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using System.Collections.Generic;
using yitangFargo.Common;
using yitangFargo.Content.Buffs;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class CrimsonEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<CrimsonEnchant>() && ytFargoConfig.Instance.OldVanillaEnchant)
            {
                player.AddEffect<CrimsonEffectNew>(item);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<CrimsonEnchant>())
            {
                if (player.HasEffect<CrimsonEffectNew>() && player.HasEffect<CrimsonEffect>())
                {
                    tooltips.ReplaceText("[CrimsonDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[CrimsonOld]", "");
                    tooltips.ReplaceText("[CrimsonNew]", "");
                }
                else if (player.HasEffect<CrimsonEffect>())
                {
                    tooltips.ReplaceText("[CrimsonNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.CrimsonEnchant.New"));
                    tooltips.ReplaceText("[CrimsonOld]", "");
                    tooltips.ReplaceText("[CrimsonDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[CrimsonOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.CrimsonEnchant.Old"));
                    tooltips.ReplaceText("[CrimsonNew]", "");
                    tooltips.ReplaceText("[CrimsonDouble]", "");
                }
            }
        }
    }

    public class CrimsonEffectNew : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<NatureHeader>();
        public override int ToggleItemType => ModContent.ItemType<CrimsonEnchant>();
        public override bool IgnoresMutantPresence => true;

        public static void CrimsonHurt(Player player, yitangFargoPlayer modPlayerY, ref Player.HurtModifiers modifiers)
        {
            FargoSoulsPlayer modPlayerF = player.FargoSouls();
            if (player.HasBuff<CrimsonRegenNewBuff>())
            {
                player.ClearBuff(ModContent.BuffType<CrimsonRegenNewBuff>());
                return;
            }
            modifiers.ModifyHurtInfo += delegate (ref Player.HurtInfo hurtInfo)
            {
                if (hurtInfo.Damage < 10)
                {
                    return;
                }
                player.AddBuff(ModContent.BuffType<CrimsonRegenNewBuff>(), 420, true, false);

                bool isForce = modPlayerF.ForceEffect<CrimsonEnchant>();
                int totalToRegen = isForce ? hurtInfo.Damage : hurtInfo.Damage / 2;
                modPlayerY.CrimsonRegenAmount = (int)((float)totalToRegen / 5f * 2f);
            };
        }
    }
}