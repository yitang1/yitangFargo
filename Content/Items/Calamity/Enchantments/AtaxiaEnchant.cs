using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Hydrothermic;
using CalamityMod.Items.Weapons.Melee;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using CalamityMod;
using CalamityMod.CalPlayer;
using FargowiltasSouls;
using CalamityMod.Projectiles.Summon;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class AtaxiaEnchant : BaseEnchant
    {
        public override Color nameColor => new(162, 77, 77);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(0, 20, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<AtaxiaEffect>(Item);
            player.AddEffect<AtaxiaMinion>(Item);
            player.AddEffect<AtaxiaPauldron>(Item);

            //渊泉盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<AtaxiaEffect>())
            {
                calamityPlayer.ataxiaBlaze = true;

                calamityPlayer.ataxiaGeyser = true;
                calamityPlayer.ataxiaBolt = true;
                calamityPlayer.ataxiaMage = true;
                calamityPlayer.ataxiaVolley = true;
            }
            //沸腾渊泉
            if (player.HasEffect<AtaxiaMinion>())
            {
                calamityPlayer.chaosSpirit = true;
            }
            //熔火碎矿肩甲
            if (player.HasEffect<AtaxiaPauldron>())
            {
                ModContent.GetInstance<SlagsplitterPauldron>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyAtaxia")
                .AddIngredient<HydrothermicArmor>()
                .AddIngredient<HydrothermicSubligar>()
                .AddIngredient<VulcaniteLance>()
                .AddIngredient<StygianShield>()
                .AddIngredient<SlagsplitterPauldron>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class AtaxiaEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AtaxiaEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AtaxiaMinion : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AtaxiaEnchant>();
        public override bool IgnoresMutantPresence => true;
        //沸腾渊泉
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(190);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<HydrothermicVent>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<HydrothermicVent>(), damage, 0f, player.whoAmI, 38f, 0f);
                }
            }
        }
    }
    public class AtaxiaPauldron : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AtaxiaEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}