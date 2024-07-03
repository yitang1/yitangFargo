using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.LunicCorps;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamityMod.Items.Weapons.Melee;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Common;
using yitangFargo.Content.Buffs;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
	public class LunicCorpsEnchant : BaseEnchant
	{
		public override Color nameColor => new(162, 191, 132);

		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.buyPrice(0, 30, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddEffect<DLunicCorpsEffect>(Item);
			player.AddEffect<DLunicCorpsTheAbsorber>(Item);

			//雷神之锤盔甲
			if (player.HasEffect<DLunicCorpsEffect>())
			{
				yitangFargoPlayer yitangPlayer = player.yitangFargo();
				if (yitangPlayer.LunicCorpsCooldown <= 0)
				{
					player.AddBuff(ModContent.BuffType<LunicCorpsShieldBuff>(), 2);
				}
			}
			//阴阳吸星石
			if (player.HasEffect<DLunicCorpsTheAbsorber>())
			{
				ModContent.GetInstance<TheAbsorber>().UpdateAccessory(player, hideVisual);
			}
			//老旧骰子
			ModContent.GetInstance<OldDie>().UpdateAccessory(player, hideVisual);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LunicCorpsHelmet>()
				.AddIngredient<LunicCorpsVest>()
				.AddIngredient<LunicCorpsBoots>()
				.AddIngredient<TheAbsorber>()
				.AddIngredient<OldDie>()
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}

	public class DLunicCorpsEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
		public override int ToggleItemType => ModContent.ItemType<LunicCorpsEnchant>();
		public override bool IgnoresMutantPresence => true;
	}
	public class DLunicCorpsTheAbsorber : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
		public override int ToggleItemType => ModContent.ItemType<LunicCorpsEnchant>();
		public override bool IgnoresMutantPresence => true;
	}
}