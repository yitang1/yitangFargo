using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Rarities;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Prismatic;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamityMod.Items.Weapons.Magic;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
	public class PrismaticEnchant : BaseEnchant, ILocalizedModType
	{
		public override Color nameColor => new(170, 178, 207);

		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ModContent.RarityType<Turquoise>();
			Item.value = Item.buyPrice(0, 50, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddEffect<EPrismaticEffect>(Item);
			player.AddEffect<EPrismaticTheEvolution>(Item);

			//光棱盔甲
			if (player.HasEffect<EPrismaticEffect>())
			{
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.Calamity().prismaticSet = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<PrismaticHelmet>().UpdateArmorSet(player);
				}
			}
			//进化者
			if (player.HasEffect<EPrismaticTheEvolution>())
			{
				ModContent.GetInstance<TheEvolution>().UpdateAccessory(player, hideVisual);
			}
		}

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[PrismaticFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[PrismaticFullEffects]", this.GetLocalizedValue("PrismaticFullTooltip"));
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<PrismaticHelmet>()
				.AddIngredient<PrismaticRegalia>()
				.AddIngredient<PrismaticGreaves>()
				.AddIngredient<Thunderstorm>()
				.AddIngredient<TheEvolution>()
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}

	public class EPrismaticEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
		public override int ToggleItemType => ModContent.ItemType<PrismaticEnchant>();
		public override bool IgnoresMutantPresence => true;
	}
	public class EPrismaticTheEvolution : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
		public override int ToggleItemType => ModContent.ItemType<PrismaticEnchant>();
		public override bool IgnoresMutantPresence => true;
	}
}