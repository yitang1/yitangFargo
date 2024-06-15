using Terraria;
using Terraria.ModLoader;
using CalamityMod.Rarities;
using yitangFargo.Content.Items.Calamity.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Forces;

namespace yitangFargo.Content.Items.Calamity.Forces
{
    public class DesolationForce : BaseForce
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = Item.buyPrice(1, 0, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //软壳魔石
            ModContent.GetInstance<MolluskEnchant>().UpdateAccessory(player, hideVisual);
            //代达罗斯魔石
            ModContent.GetInstance<DaedalusEnchant>().UpdateAccessory(player, hideVisual);
            //幻渊魔石
            ModContent.GetInstance<FathomSwarmerEnchant>().UpdateAccessory(player, hideVisual);
            //日影魔石
            ModContent.GetInstance<UmbraphileEnchant>().UpdateAccessory(player, hideVisual);
            //星幻魔石
            ModContent.GetInstance<AstralEnchant>().UpdateAccessory(player, hideVisual);
            //蓝色欧米茄魔石
            ModContent.GetInstance<OmegaBlueEnchant>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MolluskEnchant>()
                .AddIngredient<DaedalusEnchant>()
                .AddIngredient<FathomSwarmerEnchant>()
                .AddIngredient<UmbraphileEnchant>()
                .AddIngredient<AstralEnchant>()
                .AddIngredient<OmegaBlueEnchant>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}