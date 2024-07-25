using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.DesertProwler;
using CalamityMod.Items.Weapons.Ranged;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Common;
using yitangFargo.Content.Buffs;
using yitangFargo.Global.Config;
using System.Collections.Generic;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class DesertProwlerEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(172, 152, 96);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<BDesertProwlerEffect>(Item);
            player.AddEffect<BDesertProwlerRusty>(Item);

			player.buffImmune[BuffID.WindPushed] = true;

			yitangFargoPlayer yitangPlayer = player.yitangFargo();
			if (player.HasEffect<BDesertProwlerEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					yitangPlayer.DesertProwlerBonus = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					yitangPlayer.DesertProwlerBonus = true;
					player.GetDamage<RangedDamageClass>().Flat += 1;
				}
			}

			//锈蚀勋章
			if (player.HasEffect<BDesertProwlerRusty>())
            {
                ModContent.GetInstance<RustyMedallion>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[DesertProwlerFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[DesertProwlerFullEffects]", this.GetLocalizedValue("DesertProwlerFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<DesertProwlerHat>()
                .AddIngredient<DesertProwlerShirt>()
                .AddIngredient<DesertProwlerPants>()
                .AddIngredient<CrackshotColt>()
                .AddIngredient<RustyMedallion>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class BDesertProwlerEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
        public override int ToggleItemType => ModContent.ItemType<DesertProwlerEnchant>();
        public override bool IgnoresMutantPresence => true;
		public override bool ExtraAttackEffect => true;
	}
    public class BDesertProwlerRusty : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
        public override int ToggleItemType => ModContent.ItemType<DesertProwlerEnchant>();
        public override bool IgnoresMutantPresence => true;
		public override bool ExtraAttackEffect => true;
	}
}