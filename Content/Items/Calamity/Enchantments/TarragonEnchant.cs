using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Tarragon;
using CalamityMod.Rarities;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.Items.Weapons.Melee;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class TarragonEnchant : BaseEnchant
    {
        public override Color nameColor => new(199, 156, 75);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<Turquoise>();
            Item.value = Item.buyPrice(0, 50, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<TarragonEffect>(Item);

            //龙蒿盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<TarragonEffect>())
            {
                calamityPlayer.tarraSet = true;
                calamityPlayer.tarraMelee = true;
                calamityPlayer.tarraRanged = true;
                calamityPlayer.tarraMage = true;
                calamityPlayer.tarraSummon = true;
                calamityPlayer.tarraThrowing = true;
            }
            //蚀日尊戒 (这两个全是正面添加数值的饰品效果，就直接默认生效好了)
            ModContent.GetInstance<DarkSunRing>().UpdateAccessory(player, hideVisual);
            //勇气勋章 
            ModContent.GetInstance<BadgeofBravery>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyTarragon")
                .AddIngredient<TarragonBreastplate>()
                .AddIngredient<TarragonLeggings>()
                .AddIngredient<HolyCollider>()
                .AddIngredient<DarkSunRing>()
                .AddIngredient<BadgeofBravery>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class TarragonEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<TarragonEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}