using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.Materials;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using yitangFargo.Global.Config;
using static Terraria.ModLoader.ModContent;
using CalamityMod.Items;
using FargowiltasCrossmod.Core.Calamity;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Content.Items.Summons;
using FargowiltasSouls.Content.Items.Accessories.Forces;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class CalamityFargoRecipes : ModSystem
    {
        //修改Fargo DLC Mod里更改的一些配方
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (ytFargoConfig.Instance.FuckBalance)
                {
                    #region 天使之靴和风神之靴系列
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
                    #endregion

                    //突变体后的武器 移除古恒石
                    if (recipe.HasIngredient<EternalEnergy>()
                        && recipe.createItem != null && CalDLCSets.Items.RockItem[recipe.createItem.type]
                        && recipe.HasIngredient(ItemType<Rock>()))
                    {
                        recipe.RemoveIngredient(ItemType<Rock>());
                    }
                    //十字章护盾
                    if (recipe.HasResult(ItemID.AnkhShield) && recipe.HasIngredient(ItemID.SoulofNight))
                    {
                        recipe.RemoveIngredient(ItemID.SoulofNight);
                    }
                    //唤灵魔符 移除神圣晶石
                    if (recipe.HasResult(ItemType<SigilOfChampions>()) && recipe.HasIngredient<DivineGeode>())
                    {
                        recipe.RemoveIngredient(ItemType<DivineGeode>());
                    }
                    //力级饰品 移除神圣晶石
                    if (recipe.createItem.ModItem is BaseForce && recipe.HasIngredient<DivineGeode>())
                    {
                        recipe.RemoveIngredient(ItemType<DivineGeode>());
                    }
                    //憎恶诅咒 移除圣金源锭
                    if (recipe.HasResult<AbomsCurse>() && recipe.HasIngredient<AuricBar>())
                    {
                        recipe.RemoveIngredient(ItemType<AuricBar>());
                    }
                }
            }
        }
    }
}