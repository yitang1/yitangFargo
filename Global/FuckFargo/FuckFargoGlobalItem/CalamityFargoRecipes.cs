using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.Materials;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangFargo.Global.Config;
using static Terraria.ModLoader.ModContent;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class CalamityFargoRecipes : ModSystem
    {
        //修改灾法联动Mod里更改的一些配方
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                //天使之靴(材料泰拉靴)
                if (recipe.HasResult<AngelTreads>() && recipe.HasIngredient<ZephyrBoots>())
                {
                    if (recipe.RemoveIngredient(ItemType<ZephyrBoots>()))
                    {
                        recipe.AddIngredient(ItemID.TerrasparkBoots);
                    }
                }
                //天界翼靴(材料天使之靴)
                if (recipe.HasResult<TracersCelestial>() && recipe.HasIngredient<AeolusBoots>())
                {
                    if (recipe.RemoveIngredient(ItemType<AeolusBoots>()))
                    {
                        recipe.AddIngredient(ItemType<AngelTreads>());
                    }
                }
                //风神之靴(三王后)
                if (recipe.HasResult<AeolusBoots>() && recipe.HasIngredient<LivingShard>())
                {
                    if (recipe.RemoveIngredient(ItemType<LivingShard>()))
                    {
                        recipe.AddIngredient(ItemID.SoulofFright, 5);
                        recipe.AddIngredient(ItemID.SoulofMight, 5);
                        recipe.AddIngredient(ItemID.SoulofSight, 5);
                    }
                    if (recipe.RemoveIngredient(ItemType<AngelTreads>()))
                    {
                        recipe.AddIngredient(ItemType<ZephyrBoots>());
                    }
                }
            }
        }
    }
}
