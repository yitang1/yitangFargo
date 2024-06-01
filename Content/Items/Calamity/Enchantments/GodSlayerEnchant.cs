using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.CalPlayer.Dashes;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.GodSlayer;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class GodSlayerEnchant : BaseEnchant
    {
        public override Color nameColor => new(214, 75, 217);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<DarkBlue>();
            Item.value = Item.buyPrice(0, 70, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<GodSlayerEffect>(Item);
            player.AddEffect<GodSlayerNebulousCore>(Item);

            //弑神者盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<GodSlayerEffect>())
            {
                calamityPlayer.godSlayer = true;
                calamityPlayer.godSlayerDamage = true;
                calamityPlayer.godSlayerRanged = true;
                calamityPlayer.godSlayerThrowing = true;

                player.thorns += 2.5f;
                if (calamityPlayer.godSlayerDashHotKeyPressed || (player.dashDelay != 0 && calamityPlayer.LastUsedDashID == GodslayerArmorDash.ID))
                {
                    calamityPlayer.DeferredDashID = GodslayerArmorDash.ID;
                    player.dash = 0;
                }
            }
            //元素之握
            ModContent.GetInstance<ElementalGauntlet>().UpdateAccessory(player, hideVisual);
            //元素箭袋
            ModContent.GetInstance<ElementalQuiver>().UpdateAccessory(player, hideVisual);
            //星云之核
            if (player.HasEffect<GodSlayerNebulousCore>())
            {
                ModContent.GetInstance<NebulousCore>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyGodSlayer")
                .AddIngredient<GodSlayerChestplate>()
                .AddIngredient<GodSlayerLeggings>()
                .AddIngredient<ElementalGauntlet>()
                .AddIngredient<ElementalQuiver>()
                .AddIngredient<NebulousCore>()
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }

    public class GodSlayerEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<GodSlayerEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class GodSlayerNebulousCore : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<GodSlayerEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}