using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Bloodflare;
using CalamityMod.Rarities;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using CalamityMod.CalPlayer;
using CalamityMod;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class BloodflareEnchant : BaseEnchant
    {
        public override Color nameColor => new(157, 12, 77);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<PureGreen>();
            Item.value = Item.buyPrice(0, 50, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<BloodEffect>(Item);
            player.AddEffect<BloodMinion>(Item);
            player.AddEffect<BloodTheChalice>(Item);
            player.AddEffect<BloodTheCore>(Item);
            ModContent.GetInstance<BrimflameEnchant>().UpdateAccessory(player, hideVisual);

            //血炎盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<BloodEffect>())
            {
                calamityPlayer.bloodflareSet = true;
                player.crimsonRegen = true;

                calamityPlayer.bloodflareMelee = true;
                calamityPlayer.bloodflareRanged = true;
                calamityPlayer.bloodflareMage = true;
                calamityPlayer.bloodflareThrowing = true;
            }
            //噬魂幽花地雷
            if (player.HasEffect<BloodMinion>())
            {
                calamityPlayer.bloodflareSummon = true;
            }
            //血神圣杯
            if (player.HasEffect<BloodTheChalice>())
            {
                ModContent.GetInstance<ChaliceOfTheBloodGod>().UpdateAccessory(player, hideVisual);
            }
            //血炎晶核
            if (player.HasEffect<BloodTheCore>())
            {
                ModContent.GetInstance<BloodflareCore>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyBloodflare")
                .AddIngredient<BloodflareBodyArmor>()
                .AddIngredient<BloodflareCuisses>()
                .AddIngredient<BrimflameEnchant>()
                .AddIngredient<ChaliceOfTheBloodGod>()
                .AddIngredient<BloodflareCore>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class BloodEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BloodMinion : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BloodTheChalice : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BloodTheCore : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}