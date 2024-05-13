using Terraria;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Demonshade;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using yitangFargo.Common.Toggler;
using CalamityMod.CalPlayer;
using CalamityMod;
using FargowiltasSouls;
using CalamityMod.Projectiles.Typeless;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class DemonShadeEnchant : BaseEnchant
    {
        public override Color nameColor => new(184, 19, 19);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = Item.buyPrice(0, 90, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<DemonShadeEffect>(Item);
            player.AddEffect<DemonShadeFAngelic>(Item);
            player.AddEffect<DemonShadeFCrystal>(Item);
            player.AddEffect<DemonShadeGCommunity>(Item);

            //魔影盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<DemonShadeEffect>())
            {
                calamityPlayer.dsSetBonus = true;
                calamityPlayer.redDevil = true;
            }
            //圣天誓盟
            if (player.HasEffect<DemonShadeFAngelic>())
            {
                ModContent.GetInstance<AngelicAlliance>().UpdateAccessory(player, hideVisual);
            }
            //渎神魂晶
            if (player.HasEffect<DemonShadeFCrystal>())
            {
                ModContent.GetInstance<ProfanedSoulCrystal>().UpdateAccessory(player, hideVisual);
            }
            //幻灭心元石
            if (player.HasEffect<DemonShadeGCommunity>())
            {
                ModContent.GetInstance<ShatteredCommunity>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<DemonshadeHelm>()
                .AddIngredient<DemonshadeBreastplate>()
                .AddIngredient<DemonshadeGreaves>()
                .AddIngredient<AngelicAlliance>()
                .AddIngredient<ProfanedSoulCrystal>()
                .AddIngredient<ShatteredCommunity>()
                .AddTile<DraedonsForge>()
                .Register();
        }
    }

    public class DemonShadeEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
        //红恶魔
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(10000);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<DemonshadeRedDevil>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<DemonshadeRedDevil>(), damage, 0f, player.whoAmI, 0f, 0f);
                }
            }
        }
    }
    public class DemonShadeFAngelic : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class DemonShadeFCrystal : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class DemonShadeGCommunity : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}