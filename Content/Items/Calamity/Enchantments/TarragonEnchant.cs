using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Rarities;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Tarragon;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class TarragonEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(199, 156, 75);

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
            player.AddEffect<TarragonEffect>(Item);

            //龙蒿盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<TarragonEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					calamityPlayer.tarraSet = true;
					calamityPlayer.tarraMelee = true;
					calamityPlayer.tarraRanged = true;
					calamityPlayer.tarraMage = true;
					calamityPlayer.tarraSummon = true;
					calamityPlayer.tarraThrowing = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<TarragonHeadMelee>().UpdateArmorSet(player);
					ModContent.GetInstance<TarragonHeadRanged>().UpdateArmorSet(player);
					ModContent.GetInstance<TarragonHeadMagic>().UpdateArmorSet(player);
					ModContent.GetInstance<TarragonHeadSummon>().UpdateArmorSet(player);
					ModContent.GetInstance<TarragonHeadRogue>().UpdateArmorSet(player);
				}
            }
            //蚀日尊戒 (这两个全是正面添加数值的饰品效果，就直接默认生效好了)
            ModContent.GetInstance<DarkSunRing>().UpdateAccessory(player, hideVisual);
            //勇气勋章 
            ModContent.GetInstance<BadgeofBravery>().UpdateAccessory(player, hideVisual);
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[XeroFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[XeroFullEffects]", this.GetLocalizedValue("XeroFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyTarragon")
                .AddIngredient<TarragonBreastplate>()
                .AddIngredient<TarragonLeggings>()
                .AddIngredient<HolyCollider>()
                .AddIngredient<DarkSunRing>()
                .AddIngredient<BadgeofBravery>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class TarragonEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<TarragonEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}