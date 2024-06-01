using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;

namespace yitangFargo.Global.Others
{
    //一些和我个人的另一个Mod(ytCN)功能冲突的地方，在这里进行[只保留一个]的判断
    public class CrossYTGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (!ModLoader.HasMod("yitangCN"))
            {
                //十字章护身符和十字章护盾因为配方里新加了暖手宝，所以免疫冷冻和冰冻
                if (item.type == ItemID.AnkhCharm)
                {
                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;
                }
                if (item.type == ItemID.AnkhShield)
                {
                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;
                    player.buffImmune[BuffID.WindPushed] = true; //添加灾厄免疫强风的设定
                }
            }
        }
    }

    public class CrossYTModSystem : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                //灾厄天顶剑的配方
                if (!ModLoader.HasMod("yitangCN"))
                {
                    if (recipe.HasResult(ItemID.Zenith))
                    {
                        recipe.RemoveIngredient(ModContent.ItemType<AuricBar>());
                    }
                }
            }
        }
    }
}