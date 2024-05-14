using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class TrawlerSoulNew : BaseSoul
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = 750000;
        }
        public static readonly Color ItemColor = new(0, 238, 125);
        protected override Color? nameColor => ItemColor;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AddEffects(player, Item, hideVisual);
        }
        public static void AddEffects(Player player, Item item, bool hideVisual)
        {
            Player Player = player;
            FargoSoulsPlayer modPlayer = player.FargoSouls();
            //快速上钩
            modPlayer.FishSoul1 = true;
            //额外鱼线
            modPlayer.FishSoul2 = true;
            //防熔岩渔具袋
            Player.fishingSkill += 60;
            Player.sonarPotion = true;
            Player.cratePotion = true;
            Player.accFishingLine = true;
            Player.accTackleBox = true;
            Player.accFishFinder = true;
            Player.accLavaFishing = true;
            //挥发明胶
            player.AddEffect<TrawlerGel>(item);
            //孢子囊
            player.AddEffect<TrawlerSporeSac>(item);
            //北极潜水装备
            Player.arcticDivingGear = true;
            Player.accFlipper = true;
            Player.accDivingHelm = true;
            Player.iceSkate = true;
            if (Player.wet)
            {
                Lighting.AddLight((int)Player.Center.X / 16, (int)Player.Center.Y / 16, 0.2f, 0.8f, 0.9f);
            }
            //鲨鱼龙气球
            player.AddEffect<TrawlerJump>(item);

            Player.jumpBoost = true;
            Player.noFallDmg = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<AnglerEnchant>()
            .AddIngredient(ItemID.BalloonHorseshoeSharkron)
            .AddIngredient(ItemID.ArcticDivingGear)
            .AddIngredient(ItemID.VolatileGelatin)
            .AddIngredient(ItemID.SporeSac)
            .AddIngredient(ItemID.SittingDucksFishingRod)
            .AddIngredient(ItemID.GoldenFishingRod)
            .AddIngredient(ItemID.GoldenCarp)
            .AddIngredient(ItemID.ReaverShark)
            .AddIngredient(ItemID.Bladetongue)
            .AddIngredient(ItemID.ObsidianSwordfish)
            .AddIngredient(ItemID.FuzzyCarrot)
            .AddIngredient(ItemID.HardySaddle)
            .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
            .Register();
        }
    }
}
