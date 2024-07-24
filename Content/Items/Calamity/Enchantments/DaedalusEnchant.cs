using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Daedalus;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Content.Projectiles.Minions;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class DaedalusEnchant : BaseEnchant
    {
        public override Color nameColor => new(113, 187, 237);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<DaedalusEffect>(Item);
            player.AddEffect<DaedalusEffectCrystal>(Item);
            player.AddEffect<DaedalusEffectGolem>(Item);
            player.AddEffect<DaedalusFConcoction>(Item);
            player.AddEffect<DaedalusFrostBarrier>(Item);
            ModContent.GetInstance<SnowRuffianEnchant>().UpdateAccessory(player, hideVisual);

            //代达罗斯盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<DaedalusEffect>())
            {
                calamityPlayer.daedalusReflect = true;
                calamityPlayer.daedalusShard = true;
                calamityPlayer.daedalusAbsorb = true;
                calamityPlayer.daedalusSplit = true;
            }
            //代达罗斯水晶
            if (player.HasEffect<DaedalusEffectCrystal>())
            {
                calamityPlayer.daedalusCrystal = true;
            }
            //永冻秘药
            if (player.HasEffect<DaedalusFConcoction>())
            {
                ModContent.GetInstance<PermafrostsConcoction>().UpdateAccessory(player, hideVisual);
            }
            //寒冰屏障
            if (player.HasEffect<DaedalusFrostBarrier>())
            {
                ModContent.GetInstance<FrostBarrier>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyDaedalus")
                .AddIngredient<DaedalusBreastplate>()
                .AddIngredient<DaedalusLeggings>()
                .AddIngredient<SnowRuffianEnchant>()
                .AddIngredient<PermafrostsConcoction>()
                .AddIngredient<FrostBarrier>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class DaedalusEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DaedalusEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class DaedalusEffectCrystal : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DaedalusEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //代达罗斯水晶
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(95);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<DaedalusCrystal>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<DaedalusCrystal>(), damage, 0f, player.whoAmI, 50f, 0f);
                }
            }
        }
    }
    public class DaedalusEffectGolem : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DaedalusEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //代达罗斯守卫仆从
        public override void PostUpdateEquips(Player player)
        {
            int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(70);
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<DaedalusGolemNew>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<DaedalusGolemNew>(), damage, 3f, player.whoAmI);
                }
            }
        }
    }
    public class DaedalusFConcoction : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DaedalusEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class DaedalusFrostBarrier : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DaedalusEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}