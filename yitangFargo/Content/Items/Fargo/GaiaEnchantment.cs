using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Armor;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Fargo
{
    public class GaiaEnchantment : BaseEnchant
    {
        public override Color nameColor => Color.Green;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(0, 30, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<BGaiaEffect>(Item);

            //盖亚盔甲
            if (player.HasEffect<BGaiaEffect>())
            {
                ModContent.GetInstance<GaiaHelmet>().UpdateArmorSet(player);
            }
            //
            //if (player.HasEffect<>())
            //{
            //    ModContent.GetInstance<>().UpdateAccessory(player, hideVisual);
            //}
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<GaiaHelmet>()
                .AddIngredient<GaiaPlate>()
                .AddIngredient<GaiaGreaves>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class BGaiaEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<GaiaEnchantment>();
        public override bool IgnoresMutantPresence => true;
    }
    //public class BGaiaEffect : AccessoryEffect
    //{
    //    public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
    //    public override int ToggleItemType => ModContent.ItemType<GaiaEnchantment>();
    //}
}