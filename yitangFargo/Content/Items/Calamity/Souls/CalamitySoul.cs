using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangFargo.Content.Items.Calamity.Forces;
using yitangFargo.Common.Rarities;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;

namespace yitangFargo.Content.Items.Calamity.Souls
{
    public class CalamitySoul : BaseSoul
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<Rainbow>();
            Item.value = Item.buyPrice(5, 0, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //湮灭之力
            ModContent.GetInstance<AnnihilationForce>().UpdateAccessory(player, hideVisual);
            //荒芜之力
            ModContent.GetInstance<DesolationForce>().UpdateAccessory(player, hideVisual);
            //毁灭之力
            ModContent.GetInstance<DevastationForce>().UpdateAccessory(player, hideVisual);
            //升华之力
            ModContent.GetInstance<ExaltationForce>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<AnnihilationForce>()
                .AddIngredient<DesolationForce>()
                .AddIngredient<DevastationForce>()
                .AddIngredient<ExaltationForce>()
                .AddIngredient<AbomEnergy>(10)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
