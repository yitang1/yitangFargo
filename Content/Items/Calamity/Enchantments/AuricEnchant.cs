using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.CalPlayer.Dashes;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Auric;
using CalamityMod.Rarities;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Tiles.Furniture.CraftingStations;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class AuricEnchant : BaseEnchant
    {
        public override Color nameColor => new(236, 185, 18);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<Violet>();
            Item.value = Item.buyPrice(0, 80, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<AuricEffect>(Item);
            player.AddEffect<AuricMinion>(Item);
            player.AddEffect<AuricPurity>(Item);
            player.AddEffect<AuricYharimsGift>(Item);

            //古圣金源盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<AuricEffect>())
            {
                //全职业通用效果
                calamityPlayer.tarraSet = true;
                calamityPlayer.bloodflareSet = true;
                calamityPlayer.godSlayer = true;
                calamityPlayer.silvaSet = true;
                calamityPlayer.auricSet = true;
                player.thorns += 3f;
                player.ignoreWater = true;
                player.crimsonRegen = true;
                //近战
                calamityPlayer.tarraMelee = true;
                calamityPlayer.bloodflareMelee = true;
                calamityPlayer.godSlayerDamage = true;
                //远程
                calamityPlayer.tarraRanged = true;
                calamityPlayer.bloodflareRanged = true;
                calamityPlayer.godSlayerRanged = true;
                //魔法
                calamityPlayer.tarraMage = true;
                calamityPlayer.bloodflareMage = true;
                calamityPlayer.silvaMage = true;
                //盗贼
                calamityPlayer.tarraThrowing = true;
                calamityPlayer.bloodflareThrowing = true;
                calamityPlayer.godSlayerThrowing = true;
                //弑神者冲刺
                if (calamityPlayer.godSlayerDashHotKeyPressed || (player.dashDelay != 0 && calamityPlayer.LastUsedDashID == GodslayerArmorDash.ID))
                {
                    calamityPlayer.DeferredDashID = GodslayerArmorDash.ID;
                }
            }
            //生命光环、噬魂幽花地雷、始源林海水晶
            if (player.HasEffect<AuricMinion>())
            {
                //召唤
                calamityPlayer.tarraSummon = true;
                calamityPlayer.bloodflareSummon = true;
                calamityPlayer.silvaSummon = true;
            }
            //无瑕粹魂晶
            if (player.HasEffect<AuricPurity>())
            {
                ModContent.GetInstance<Radiance>().UpdateAccessory(player, hideVisual);
            }
            //寻神者之礼
            if (player.HasEffect<AuricYharimsGift>())
            {
                ModContent.GetInstance<YharimsGift>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyAuric")
                .AddIngredient<AuricTeslaBodyArmor>()
                .AddIngredient<AuricTeslaCuisses>()
                .AddIngredient<TheWand>()
                .AddIngredient<Radiance>()
                .AddIngredient<YharimsGift>()
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }

    public class AuricEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AuricEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AuricMinion : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AuricEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //始源林海水晶
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(1200);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<SilvaCrystal>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<SilvaCrystal>(), damage, 0f, player.whoAmI, - 20f, 0f);
                }
            }
        }
    }
    public class AuricPurity : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AuricEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AuricYharimsGift : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AuricEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}