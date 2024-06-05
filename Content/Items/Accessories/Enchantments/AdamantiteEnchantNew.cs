using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Projectiles;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using yitangFargo.Common;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class AdamantiteEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<AdamantiteEnchant>() && ytFargoConfig.Instance.OldVanillaEnchant)
            {
                player.AddEffect<AdamantiteEffectNew>(item);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<AdamantiteEnchant>())
            {
                if (player.HasEffect<AdamantiteEffectNew>() && player.HasEffect<AdamantiteEffect>())
                {
                    tooltips.ReplaceText("[AdamantiteDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[AdamantiteOld]", "");
                    tooltips.ReplaceText("[AdamantiteNew]", "");
                }
                else if (player.HasEffect<AdamantiteEffect>())
                {
                    tooltips.ReplaceText("[AdamantiteNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.AdamantiteEnchant.New"));
                    tooltips.ReplaceText("[AdamantiteOld]", "");
                    tooltips.ReplaceText("[AdamantiteDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[AdamantiteOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.AdamantiteEnchant.Old"));
                    tooltips.ReplaceText("[AdamantiteNew]", "");
                    tooltips.ReplaceText("[AdamantiteDouble]", "");
                }
            }
        }
    }

    public class AdamantiteEffectNew : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EarthHeader>();
        public override int ToggleItemType => ModContent.ItemType<AdamantiteEnchant>();
        public override bool IgnoresMutantPresence => true;

        public static void AdamantiteSplitNew(Projectile projectile, Player player, int splitDegreeAngle)
        {
            yitangFargoPlayer modPlayerYT = player.yitangFargo();
            FargoSoulsPlayer modPlayerF = player.FargoSouls();
            bool adaForce = modPlayerF.ForceEffect<AdamantiteEnchant>();

            foreach (Projectile p in FargoSoulsGlobalProjectile.SplitProj(projectile, 3, MathHelper.ToRadians(8f), 1f, false))
            {
                if (p.Alive())
                {
                    p.FargoSouls().HuntressProj = projectile.FargoSouls().HuntressProj;
                }
            }

            if (!adaForce)
            {
                projectile.type = ProjectileID.None;
                projectile.timeLeft = 0;
                projectile.active = false;
            }
        }
    }
}