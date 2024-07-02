using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.TitanHeart;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Items.Weapons.Rogue;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
	public class TitanHeartEnchant : BaseEnchant
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
				player.Calamity().titanHeartSet = true;
			}
			//大熊座雀鲷 (无降低移速的负面效果)
			player.moveSpeed += 0.15f;
			ModContent.GetInstance<UrsaSergeant>().UpdateAccessory(player, hideVisual);
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