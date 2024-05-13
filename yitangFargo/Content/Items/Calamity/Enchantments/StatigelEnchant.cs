using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Statigel;
using CalamityMod.Items.Weapons.Summon;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Content.Projectiles.Minions;
using CalamityMod;
using CalamityMod.ExtraJumps;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class StatigelEnchant : BaseEnchant
    {
        public override Color nameColor => new(233, 107, 182);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(0, 4, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<StatigelEffect>(Item);
            player.AddEffect<StatigelManaPolarizer>(Item);
            player.AddEffect<StatigelSlimeMinions>(Item);

            //斯塔提斯盔甲
            if (player.HasEffect<StatigelEffect>())
            {
                player.Calamity().statigelSet = true;
                player.GetJumpState<StatigelJump>().Enable();
                Player.jumpHeight += 5;
                player.jumpSpeedBoost += 0.6f;
            }
            //魔能谐振仪
            if (player.HasEffect<StatigelManaPolarizer>())
            {
                ModContent.GetInstance<ManaPolarizer>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyStatigel")
                .AddIngredient<StatigelArmor>()
                .AddIngredient<StatigelGreaves>()
                .AddIngredient<ManaPolarizer>()
                .AddIngredient<CrimslimeStaff>()
                .AddIngredient<CorroslimeStaff>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class StatigelEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<StatigelEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class StatigelManaPolarizer : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<StatigelEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class StatigelSlimeMinions : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<StatigelEnchant>();
        public override bool IgnoresMutantPresence => true;
        
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                //史莱姆仆从
                int damageM = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(24);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<CrimslimeMinionNew>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<CrimslimeMinionNew>(), damageM, 2f, player.whoAmI);
                }
                if (player.ownedProjectileCounts[ModContent.ProjectileType<CorroslimeMinionNew>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<CorroslimeMinionNew>(), damageM, 2f, player.whoAmI);
                }
                //史莱姆之神宝宝
                int damageG = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(33);
                if (WorldGen.crimson && player.ownedProjectileCounts[ModContent.ProjectileType<CrimsonSlimeGodNew>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<CrimsonSlimeGodNew>(), damageG, 0f, player.whoAmI);
                }
                else if (!WorldGen.crimson && player.ownedProjectileCounts[ModContent.ProjectileType<CorruptionSlimeGodNew>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<CorruptionSlimeGodNew>(), damageG, 0f, player.whoAmI);
                }
            }
        }
    }
}
