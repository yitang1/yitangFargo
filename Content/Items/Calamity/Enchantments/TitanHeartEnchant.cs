using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.TitanHeart;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
	public class TitanHeartEnchant : BaseEnchant, ILocalizedModType
	{
		public override Color nameColor => new(140, 129, 187);

		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(0, 5, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddEffect<AstralTitanHeartEffect>(Item);

			//泰坦之心盔甲
			if (player.HasEffect<AstralTitanHeartEffect>())
			{
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.Calamity().titanHeartSet = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<TitanHeartMask>().UpdateArmorSet(player);
				}
			}
			//大熊座雀鲷 (无降低移速的负面效果)
			player.moveSpeed += 0.15f;
			ModContent.GetInstance<UrsaSergeant>().UpdateAccessory(player, hideVisual);
		}

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[TitanHeartFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[TitanHeartFullEffects]", this.GetLocalizedValue("TitanHeartFullTooltip"));
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<TitanHeartMask>()
				.AddIngredient<TitanHeartMantle>()
				.AddIngredient<TitanHeartBoots>()
				.AddIngredient<GacruxianMollusk>()
				.AddIngredient<UrsaSergeant>()
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}

	public class AstralTitanHeartEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
		public override int ToggleItemType => ModContent.ItemType<TitanHeartEnchant>();
		public override bool IgnoresMutantPresence => true;
		public override bool ExtraAttackEffect => true;
	}
	//public class CTitanHeartUrsa : AccessoryEffect
	//{
	//	public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
	//	public override int ToggleItemType => ModContent.ItemType<TitanHeartEnchant>();
	//	public override bool IgnoresMutantPresence => true;
	//}
}