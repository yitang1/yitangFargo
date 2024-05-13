using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using yitangFargo.Common;
using yitangFargo.Global;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class NinjaEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<NinjaEnchant>() && ytFargoConfig.Instance.OldEnchant)
            {
                player.yitangFargo().IamNinja = true;
                player.AddEffect<NinjaEffectNew>(item);
            }
        }

        public override void ModifyManaCost(Item item, Player player, ref float reduce, ref float mult)
        {
            FargoSoulsPlayer modPlayerF = player.FargoSouls();

            if (player.HasEffect<NinjaEffectNew>() || modPlayerF.ForceEffect<NinjaEnchant>())
            {
                mult *= 0.5f;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<NinjaEnchant>())
            {
                if (player.HasEffect<NinjaEffectNew>() && player.HasEffect<NinjaEffect>())
                {
                    tooltips.ReplaceText("[NinjaDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[NinjaOld]", "");
                    tooltips.ReplaceText("[NinjaNew]", "");
                }
                else if (player.HasEffect<NinjaEffect>())
                {
                    tooltips.ReplaceText("[NinjaNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.NinjaEnchant.New"));
                    tooltips.ReplaceText("[NinjaOld]", "");
                    tooltips.ReplaceText("[NinjaDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[NinjaOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.NinjaEnchant.Old"));
                    tooltips.ReplaceText("[NinjaNew]", "");
                    tooltips.ReplaceText("[NinjaDouble]", "");
                }
            }
        }
    }

    public class NinjaEffectNew : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ShadowHeader>();
        public override int ToggleItemType => ModContent.ItemType<NinjaEnchant>();
        public override bool IgnoresMutantPresence => true;

        public static void NinjaSpeedSetupNew(Player player, Projectile projectile, ytFargoGlobalProjectile globalProj)
        {
            yitangFargoPlayer modPlayerY = player.yitangFargo();
            FargoSoulsPlayer modPlayerF = player.FargoSouls();
            if (modPlayerY.Player.HasEffect<NinjaEffectNew>())
            {
                globalProj.NinjaSpeedupNew = projectile.extraUpdates + 1;
                int armorPen = 15;
                if (modPlayerF.ForceEffect<NinjaEnchant>())
                {
                    armorPen *= 3;
                }
                projectile.ArmorPenetration += armorPen;
            }
        }

    }
}
