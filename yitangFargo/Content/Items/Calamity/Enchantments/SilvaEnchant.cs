using Terraria;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using CalamityMod.CalPlayer;
using CalamityMod;
using FargowiltasSouls;
using CalamityMod.Projectiles.Summon;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class SilvaEnchant : BaseEnchant
    {
        public override Color nameColor => new(20, 163, 108);

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
            player.AddEffect<SilvaEffect>(Item);
            player.AddEffect<SilvaEffectCrystal>(Item);
            player.AddEffect<SilvaTheAmalgam>(Item);
            player.AddEffect<SilvaTheSponge>(Item);

            //始源林海盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<SilvaEffect>())
            {
                calamityPlayer.silvaSet = true;
                calamityPlayer.silvaMage = true;
            }
            //始源林海水晶
            if (player.HasEffect<SilvaEffectCrystal>())
            {
                calamityPlayer.silvaSummon = true;
            }
            //聚合之脑
            if (player.HasEffect<SilvaTheAmalgam>())
            {
                ModContent.GetInstance<TheAmalgam>().UpdateAccessory(player, hideVisual);
            }
            //化绵留香石
            if (player.HasEffect<SilvaTheSponge>())
            {
                ModContent.GetInstance<TheSponge>().UpdateAccessory(player, hideVisual);
            }
            //空灵护符
            ModContent.GetInstance<EtherealTalisman>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnySilva")
                .AddIngredient<SilvaArmor>()
                .AddIngredient<SilvaLeggings>()
                .AddIngredient<TheAmalgam>()
                .AddIngredient<TheSponge>()
                .AddIngredient<EtherealTalisman>()
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }

    public class SilvaEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class SilvaEffectCrystal : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
        //始源林海水晶
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(600);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<SilvaCrystal>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<SilvaCrystal>(), damage, 0f, player.whoAmI, -20f, 0f);
                }
            }
        }
    }
    public class SilvaTheAmalgam : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class SilvaTheSponge : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}