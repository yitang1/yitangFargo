using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Astral;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using yitangFargo.Common.Toggler;
using CalamityMod.Items.Weapons.Summon;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class AstralEnchant : BaseEnchant
    {
        public override Color nameColor => new(87, 224, 224);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.buyPrice(0, 30, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<AstralEffect>(Item);
            player.AddEffect<AstralHideofAstrum>(Item);
            player.AddEffect<AstralSabaton>(Item);

            //星幻盔甲
            if (player.HasEffect<AstralEffect>())
            {
                player.Calamity().astralStarRain = true;
            }
            //星神隐壳
            if (player.HasEffect<AstralHideofAstrum>())
            {
                ModContent.GetInstance<HideofAstrumDeus>().UpdateAccessory(player, hideVisual);
            }
            //引力靴
            if (player.HasEffect<AstralSabaton>())
            {
                ModContent.GetInstance<GravistarSabaton>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<AstralHelm>()
                .AddIngredient<AstralBreastplate>()
                .AddIngredient<AstralLeggings>()
                .AddIngredient<HivePod>()
                .AddIngredient<HideofAstrumDeus>()
                .AddIngredient<GravistarSabaton>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class AstralEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AstralEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AstralHideofAstrum : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AstralEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AstralSabaton : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AstralEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}