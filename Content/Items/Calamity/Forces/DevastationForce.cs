using Terraria;
using Terraria.ModLoader;
using CalamityMod.Rarities;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Content.Items.Calamity.Forces
{
    public class DevastationForce : BaseForce
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = Item.buyPrice(1, 0, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //钨钢魔石
            ModContent.GetInstance<WulfrumEnchant>().UpdateAccessory(player, hideVisual);
            //掠夺者魔石
            ModContent.GetInstance<ReaverEnchant>().UpdateAccessory(player, hideVisual);
            //瘟疫魔石
            ModContent.GetInstance<PlagueEnchant>().UpdateAccessory(player, hideVisual);
            //魔影魔石
            ModContent.GetInstance<DemonShadeEnchant>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<WulfrumEnchant>()
                .AddIngredient<ReaverEnchant>()
                .AddIngredient<PlagueEnchant>()
                .AddIngredient<DemonShadeEnchant>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}