using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Rarities;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using System.Collections.Generic;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Souls
{
    public class BrandoftheWitchNew : SoulsItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items";

        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.value = Item.buyPrice(2, 50, 0, 0);
            Item.rare = ModContent.RarityType<Violet>();
            Item.defense = 50;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //元灵之心
            if (player.AddEffect<AHeartElements>(Item))
            {
                ModContent.GetInstance<HeartoftheElements>().UpdateAccessory(player, hideVisual);
            }
            //嘉登之心
            if (player.AddEffect<EDraedonsHeart>(Item))
            {
                ModContent.GetInstance<DraedonsHeart>().UpdateAccessory(player, hideVisual);
            }

            #region 如果开启【配方修改-Fargo魂本体】配置选项的话
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                FargoSoulsPlayer fargoPlayer = player.FargoSouls();
                //虚无箭袋
                if (player.AddEffect<QuiverofNihilityEffect>(Item))
                {
                    ModContent.GetInstance<QuiverofNihility>().UpdateAccessory(player, hideVisual);
                }
                //痴愚金龙干细胞
                if (player.AddEffect<StemCellsEffect>(Item))
                {
                    ModContent.GetInstance<DynamoStemCells>().UpdateAccessory(player, hideVisual);
                }
                //聚合之脑
                if (player.AddEffect<AmalgamEffect>(Item))
                {
                    ModContent.GetInstance<TheAmalgam>().UpdateAccessory(player, hideVisual);
                }
                //阿斯加德之庇护
                if (player.AddEffect<AsgardianAegisEffect>(Item))
                {
                    ModContent.GetInstance<AsgardianAegis>().UpdateAccessory(player, hideVisual);
                    fargoPlayer.HasDash = true;
                }
                //神之壁垒
                if (player.AddEffect<RampartofDeitiesEffect>(Item))
                {
                    ModContent.GetInstance<RampartofDeities>().UpdateAccessory(player, hideVisual);
                }
                //至高统治之盾
                if (player.AddEffect<ShieldHighRulerEffect>(Item))
                {
                    ModContent.GetInstance<ShieldoftheHighRuler>().UpdateAccessory(player, hideVisual);
                    fargoPlayer.HasDash = true;
                }
                //斯塔提斯的虚空饰带
                if (player.AddEffect<StatisVoidSashEffect>(Item))
                {
                    ModContent.GetInstance<StatisVoidSash>().UpdateAccessory(player, hideVisual);
                    fargoPlayer.HasDash = true;
                }
                //深渊潜游服
                if (player.AddEffect<AbyssalDivingSuitEffect>(Item))
                {
                    ModContent.GetInstance<AbyssalDivingSuit>().UpdateAccessory(player, hideVisual);
                }
            }
            #endregion

        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                tooltips.ReplaceText("[BrandoftheWitchEffects]", this.GetLocalizedValue("BrandoftheWitchCalamity"));
            }
            else if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                tooltips.ReplaceText("[BrandoftheWitchEffects]", this.GetLocalizedValue("BrandoftheWitchFargo"));
            }
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient<HeartoftheElements>()
                    .AddIngredient<ShieldoftheHighRuler>()
                    .AddIngredient<AbyssalDivingSuit>()
                    .AddIngredient<DynamoStemCells>()
                    .AddIngredient<QuiverofNihility>()
                    .AddIngredient<StatisVoidSash>()
                    .AddIngredient<TheAmalgam>()
                    .AddIngredient<AsgardianAegis>()
                    .AddIngredient<RampartofDeities>()
                    .AddIngredient<DraedonsHeart>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<HeartoftheElements>()
                    .AddIngredient<DraedonsHeart>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }

    public abstract class BrandWitchEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<BrimstoneWitchHeader>();
    }
    public class AHeartElements : BrandWitchEffect
    {
        public override int ToggleItemType => ModContent.ItemType<HeartoftheElements>();
        public override bool IgnoresMutantPresence => true;
    }
    public class EDraedonsHeart : BrandWitchEffect
    {
        public override int ToggleItemType => ModContent.ItemType<DraedonsHeart>();
        public override bool IgnoresMutantPresence => true;
    }
}