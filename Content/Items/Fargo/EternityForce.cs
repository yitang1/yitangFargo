using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using yitangFargo.Common.Rarities;

namespace yitangFargo.Content.Items.Fargo
{
    public class EternityForce : BaseForce
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<Rainbow>();
            Item.value = Item.buyPrice(5, 0, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //猫猫睡衣魔石
            ModContent.GetInstance<NekomiEnchantment>().UpdateAccessory(player, hideVisual);
            //盖亚魔石
            ModContent.GetInstance<GaiaEnchantment>().UpdateAccessory(player, hideVisual);
            //波江魔石
            ModContent.GetInstance<EridanusEnchantment>().UpdateAccessory(player, hideVisual);
            //冥河魔石
            ModContent.GetInstance<StyxEnchantment>().UpdateAccessory(player, hideVisual);
            //真·突变魔石
            ModContent.GetInstance<TrueMutantEnchantment>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<NekomiEnchantment>()
                .AddIngredient<GaiaEnchantment>()
                .AddIngredient<EridanusEnchantment>()
                .AddIngredient<StyxEnchantment>()
                .AddIngredient<TrueMutantEnchantment>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}