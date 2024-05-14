using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Umbraphile;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using yitangFargo.Common.Toggler;
using CalamityMod;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class UmbraphileEnchant : BaseEnchant
    {
        public override Color nameColor => new(124, 86, 86);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<UmbraphileEffect>(Item);
            player.AddEffect<UmbraphileVampiric>(Item);
            player.AddEffect<UmbraphileGlove>(Item);

            //日影盔甲
            if (player.HasEffect<UmbraphileEffect>())
            {
                player.Calamity().umbraphileSet = true;
            }
            //吸血鬼符咒
            if (player.HasEffect<UmbraphileVampiric>())
            {
                ModContent.GetInstance<VampiricTalisman>().UpdateAccessory(player, hideVisual);
            }
            //精准手套
            if (player.HasEffect<UmbraphileGlove>())
            {
                ModContent.GetInstance<GloveOfPrecision>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<UmbraphileHood>()
                .AddIngredient<UmbraphileRegalia>()
                .AddIngredient<UmbraphileBoots>()
                .AddIngredient<FantasyTalisman>()
                .AddIngredient<VampiricTalisman>()
                .AddIngredient<GloveOfPrecision>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class UmbraphileEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<UmbraphileEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class UmbraphileVampiric : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<UmbraphileEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class UmbraphileGlove : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<UmbraphileEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}