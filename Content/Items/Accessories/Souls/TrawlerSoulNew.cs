using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Global.Config;
using CalamityMod.Items.Accessories;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.Toggler;
using CalamityMod.Items.Fishing.FishingRods;
using CalamityMod.Items.Fishing.SunkenSeaCatches;
using CalamityMod.Items.Weapons.Ranged;
using System.Collections.Generic;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class TrawlerSoulNew : BaseSoul, ILocalizedModType
    {
        public new string LocalizationCategory => "Items";

		public static readonly Color ItemColor = new(0, 238, 125);
		protected override Color? nameColor => ItemColor;

		public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = Item.buyPrice(0, 75, 0, 0);
        }

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

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
			base.SafeModifyTooltips(tooltips);

			if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                tooltips.ReplaceText("[TrawlerEffects]", this.GetLocalizedValue("TrawlerCalamity"));
            }
            else if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                tooltips.ReplaceText("[TrawlerEffects]", this.GetLocalizedValue("TrawlerFargo"));
            }
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
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
                    .AddIngredient(ItemID.ObsidianSwordfish)
                    .AddIngredient(ItemID.Bladetongue)
                    .AddIngredient(ItemID.FuzzyCarrot)
                    .AddIngredient(ItemID.HardySaddle)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<AnglerEnchant>()
                    .AddIngredient(ItemID.BalloonHorseshoeSharkron)
                    .AddIngredient<SupremeBaitTackleBoxFishingStation>()
                    .AddIngredient(ItemID.VolatileGelatin)
                    .AddIngredient(ItemID.SporeSac)
                    .AddIngredient<AbyssalDivingSuit>()
                    .AddIngredient(ItemID.GoldenFishingRod)
                    .AddIngredient<SparklingEmpress>()
                    .AddIngredient<PolarisParrotfish>()
                    .AddIngredient<TheDevourerofCods>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}