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
    public class EridanusEnchantment : BaseEnchant
    {
        public override Color nameColor => Color.Purple;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(0, 40, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<EridanusEffect>(Item);

            //波江盔甲
            if (player.HasEffect<EridanusEffect>())
            {
                ModContent.GetInstance<EridanusHat>().UpdateArmorSet(player);
            }
            //
            //if (player.HasEffect<EridanusCore>())
            //{
            //    ModContent.GetInstance<>().UpdateAccessory(player, hideVisual);
            //}
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<EridanusHat>()
                .AddIngredient<EridanusBattleplate>()
                .AddIngredient<EridanusLegwear>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class EridanusEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<EridanusEnchantment>();
        public override bool IgnoresMutantPresence => true;
    }
    //public class EridanusCore : AccessoryEffect
    //{
    //    public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
    //    public override int ToggleItemType => ModContent.ItemType<EridanusEnchantment>();
    //}
}