using Terraria;
using Terraria.ModLoader;
using CalamityMod.Rarities;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Content.Items.Calamity.Forces
{
    public class MiracleForce : BaseForce
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = Item.buyPrice(1, 0, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //合成岩魔石
            ModContent.GetInstance<MarniteEnchant>().UpdateAccessory(player, hideVisual);
			//沙漠巡游者魔石
			ModContent.GetInstance<DesertProwlerEnchant>().UpdateAccessory(player, hideVisual);
			//雷神之锤魔石
			ModContent.GetInstance<LunicCorpsEnchant>().UpdateAccessory(player, hideVisual);
			//光棱魔石
			ModContent.GetInstance<PrismaticEnchant>().UpdateAccessory(player, hideVisual);
			//天钻魔石
			ModContent.GetInstance<GemTechEnchant>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MarniteEnchant>()
                .AddIngredient<DesertProwlerEnchant>()
                .AddIngredient<LunicCorpsEnchant>()
                .AddIngredient<PrismaticEnchant>()
                .AddIngredient<GemTechEnchant>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}