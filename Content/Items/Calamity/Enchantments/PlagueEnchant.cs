using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Plaguebringer;
using CalamityMod.Items.Armor.PlagueReaper;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Cooldowns;
using CalamityMod.Projectiles.Rogue;
using CalamityMod.CalPlayer.Dashes;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Content.Projectiles.Minions;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class PlagueEnchant : BaseEnchant
    {
        public override Color nameColor => new(111, 179, 156);

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
            player.AddEffect<PlagueEffectBringer>(Item);
            player.AddEffect<PlagueEffectReaper>(Item);
            player.AddEffect<PlaguePAlchemicalFlask>(Item);
            player.AddEffect<PlagueToxicHeart>(Item);

            /*瘟疫死神盔甲和瘟疫使者盔甲
             这个时期实在是没有多少能缝合进魔石的饰品，所以把两套瘟疫盔甲合并到了一个魔石里*/
            CalamityPlayer calamityPlayer = player.Calamity();
            //瘟疫使者
            if (player.HasEffect<PlagueEffectBringer>())
            {
                calamityPlayer.plaguebringerPatronSet = true;
                calamityPlayer.DashID = PlaguebringerArmorDash.ID;
                player.dashType = 0;
                Lighting.AddLight(player.Center, 0f, 0.39f, 0.24f);
            }

            //瘟疫死神
            if (player.HasEffect<PlagueEffectReaper>())
            {
                calamityPlayer.plagueReaper = true;
                //不要提高飞行时间的数值
                if (player.wingTimeMax > 0)
                {
                    player.wingTimeMax = (int)(player.wingTimeMax / 1.05f);
                }
                var hasPlagueBlackoutCD = calamityPlayer.cooldowns.TryGetValue(PlagueBlackout.ID, out var cd);
                if (hasPlagueBlackoutCD && cd.timeLeft > 1500)
                {
                    player.blind = true;
                    player.headcovered = true;
                    player.blackout = true;
                    player.GetDamage<RangedDamageClass>() += 0.6f;
                    player.GetCritChance<RangedDamageClass>() += 20;
                }
                if (player.whoAmI == Main.myPlayer)
                {
                    var source = player.GetSource_Accessory(Item);
                    if (player.immune)
                    {
                        if (player.miscCounter % 10 == 0)
                        {
                            var damage = (int)player.GetTotalDamage<RangedDamageClass>().ApplyTo(40);
                            damage = player.ApplyArmorAccDamageBonusesTo(damage);

                            var cinder = CalamityUtils.ProjectileRain(source, player.Center, 400f, 100f, 500f, 800f, 22f, ModContent.ProjectileType<TheSyringeCinder>(), damage, 4f, player.whoAmI);
                            if (cinder.whoAmI.WithinBounds(Main.maxProjectiles))
                                cinder.DamageType = DamageClass.Generic;
                        }
                    }
                }
            }
            //冶金烧瓶
            if (player.HasEffect<PlaguePAlchemicalFlask>())
            {
                ModContent.GetInstance<AlchemicalFlask>().UpdateAccessory(player, hideVisual);
            }
            //毒疫之心
            if (player.HasEffect<PlagueToxicHeart>())
            {
                ModContent.GetInstance<ToxicHeart>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyPlagueHelmet")
                .AddRecipeGroup("yitangFargo:AnyPlagueBreastplate")
                .AddRecipeGroup("yitangFargo:AnyPlagueBoot")
                .AddIngredient<SoulHarvester>()
                .AddIngredient<AlchemicalFlask>()
                .AddIngredient<ToxicHeart>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class PlagueEffectBringer : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<PlagueEnchant>();
        public override bool IgnoresMutantPresence => true;
        //瘟疫使者盔甲 瘟疫使者仆从
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(25);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<PlaguebringerSummonNew>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<PlaguebringerSummonNew>(), damage, 0f, player.whoAmI, 0f, 0f);
                }
            }
        }
    }
    public class PlagueEffectReaper : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<PlagueEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class PlaguePAlchemicalFlask : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<PlagueEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class PlagueToxicHeart : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<PlagueEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}