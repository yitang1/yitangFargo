using CalamityMod.Rarities;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using Terraria;
using Terraria.ModLoader;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Content.Items.Calamity.Forces
{
    public class AnnihilationForce : BaseForce
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = Item.buyPrice(1, 0, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //天蓝魔石
            ModContent.GetInstance<AerospecEnchant>().UpdateAccessory(player, hideVisual);
            //斯塔提斯魔石
            ModContent.GetInstance<StatigelEnchant>().UpdateAccessory(player, hideVisual);
            //渊泉魔石
            ModContent.GetInstance<AtaxiaEnchant>().UpdateAccessory(player, hideVisual);
            //皇天魔石
            ModContent.GetInstance<XerocEnchant>().UpdateAccessory(player, hideVisual);
            //神惧者魔石
            ModContent.GetInstance<FearmongerEnchant>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<AerospecEnchant>()
                .AddIngredient<StatigelEnchant>()
                .AddIngredient<AtaxiaEnchant>()
                .AddIngredient<XerocEnchant>()
                .AddIngredient<FearmongerEnchant>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
