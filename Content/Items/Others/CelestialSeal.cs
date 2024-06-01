using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Drawing.Text;
using CalamityMod.Items.PermanentBoosters;
using FargowiltasSouls;
using FargowiltasSouls.Common;
using FargowiltasSouls.Content.Items.Consumables;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using yitangFargo.Common.Rarities;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Others
{
    public class CelestialSeal : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ModContent.RarityType<Rainbow>();
            Item.maxStack = 9999;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.consumable = true;
            Item.UseSound = SoundID.Item92;
            Item.value = Item.buyPrice(0, 30, 0, 0);
        }

        public override bool CanUseItem(Player player)
        {
            return !player.yitangFargo().celestialSeal;
        }

        public override bool? UseItem(Player player)
        {
            if (player.itemAnimation > 0 && player.itemTime == 0)
            {
                player.itemTime = Item.useTime;
                player.yitangFargo().celestialSeal = true;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemonHeart)
                .AddIngredient<MutantsPact>()
                .AddIngredient<CelestialOnion>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class CelestialSealAccessorySlot : ModAccessorySlot
    {
        public override bool IsEnabled()
        {
            if (!Player.active)
                return false;
            return Player.yitangFargo().celestialSeal;
        }
        public override bool IsHidden() => IsEmpty && !IsEnabled();

        public override void ApplyEquipEffects()
        {
            int lastAccIndex = 7 + Player.GetAmountOfExtraAccessorySlotsToShow();
            if (Player.armor[lastAccIndex].type == ModContent.ItemType<WizardEnchant>() || Player.armor[lastAccIndex].type == ModContent.ItemType<CosmoForce>())
            {
                Player.FargoSouls().WizardedItem = FunctionalItem;
            }

            base.ApplyEquipEffects();
        }
    }
}