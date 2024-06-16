using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using CalamityMod;
using CalamityMod.Rarities;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.GemTech;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using CalamityMod.Items.Weapons.Melee;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
	public class GemTechEnchant : BaseEnchant, ILocalizedModType
	{
		public new string LocalizationCategory => "Items";

		public override Color nameColor => new(255, 216, 216);

		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ModContent.RarityType<Violet>();
			Item.value = Item.buyPrice(0, 80, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddEffect<FGemTechEffect>(Item);
			player.AddEffect<FGemTechHeart>(Item);

			//天钻盔甲
			if (player.HasEffect<FGemTechEffect>())
			{
				player.Calamity().GemTechSet = true;

				if (player.Calamity().GemTechState.IsRedGemActive)
					player.Calamity().rogueStealthMax += GemTechHeadgear.RogueStealthBoost * 0.01f;
				if (player.Calamity().GemTechState.IsYellowGemActive)
					player.GetAttackSpeed<MeleeDamageClass>() += GemTechHeadgear.MeleeSpeedBoost;
			}
			//嘉登之心
			if (player.HasEffect<FGemTechHeart>())
			{
				ModContent.GetInstance<DraedonsHeart>().UpdateAccessory(player, hideVisual);
			}
		}

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!Keyboard.GetState().IsKeyDown(Keys.LeftShift))
			{
				tooltips.ReplaceText("[GemTechGeneral]", this.GetLocalizedValue("GemTechGeneral"));
				tooltips.ReplaceText("[GemTechBonus]", "");
			}
			else
			{
				tooltips.ReplaceText("[GemTechBonus]", this.GetLocalizedValue("GemTechBonus"));
				tooltips.ReplaceText("[GemTechGeneral]", "");
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<GemTechHeadgear>()
				.AddIngredient<GemTechBodyArmor>()
				.AddIngredient<GemTechSchynbaulds>()
				.AddIngredient<MiracleMatter>()
				.AddIngredient<DraedonsHeart>()
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}

	public class FGemTechEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
		public override int ToggleItemType => ModContent.ItemType<GemTechEnchant>();
		public override bool IgnoresMutantPresence => true;
		public override bool ExtraAttackEffect => true;
	}
	public class FGemTechHeart : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
		public override int ToggleItemType => ModContent.ItemType<GemTechEnchant>();
		public override bool IgnoresMutantPresence => true;
	}
}