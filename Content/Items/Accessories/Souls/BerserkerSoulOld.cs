using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.DraedonsArsenal;
using yitangFargo.Common;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class BerserkerSoulOld : BaseSoul, ILocalizedModType
    {
        public new string LocalizationCategory => "Items";

		public static readonly Color ItemColor = new(255, 111, 6);
		protected override Color? nameColor => ItemColor;

		public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.3f;
            player.GetCritChance(DamageClass.Melee) += 15;

            player.AddEffect<MeleeSpeedEffect>(Item);

            player.FargoSouls().MeleeSoul = true;

            //烈火手套
            player.AddEffect<MagmaStoneEffect>(Item);
            player.kbGlove = true;
            player.autoReuseGlove = true;
            player.meleeScaleGlove = true;

            player.counterWeight = 556 + Main.rand.Next(6);
            player.yoyoGlove = true;
            player.yoyoString = true;

            //天界壳
            player.wolfAcc = true;
            player.accMerman = true;

            if (hideVisual)
            {
                player.hideMerman = true;
                player.hideWolf = true;
            }

            player.lifeRegen += 2;
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
			base.SafeModifyTooltips(tooltips);

			if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                tooltips.ReplaceText("[BerserkerEffects]", this.GetLocalizedValue("BerserkerCalamity"));
            }
            else if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                tooltips.ReplaceText("[BerserkerEffects]", this.GetLocalizedValue("BerserkerFargo"));
            }
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient<BarbariansEssence>()
                    .AddIngredient(ItemID.StingerNecklace)
                    .AddIngredient(ItemID.YoyoBag)
                    .AddIngredient(ItemID.FireGauntlet)
                    .AddIngredient(ItemID.BerserkerGlove)
                    .AddIngredient(ItemID.CelestialShell)
                    .AddIngredient(ItemID.KOCannon)
                    .AddIngredient(ItemID.IceSickle)
                    .AddIngredient(ItemID.DripplerFlail)
                    .AddIngredient(ItemID.ScourgeoftheCorruptor)
                    .AddIngredient(ItemID.Kraken)
                    .AddIngredient(ItemID.Flairon)
                    .AddIngredient(ItemID.MonkStaffT3)
                    .AddIngredient(ItemID.NorthPole)
                    .AddIngredient(ItemID.Zenith)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<BarbariansEssence>()
                    .AddIngredient(ItemID.StingerNecklace)
                    .AddIngredient(ItemID.YoyoBag)
                    .AddIngredient(ItemID.FireGauntlet)
                    .AddIngredient(ItemID.BerserkerGlove)
                    .AddIngredient(ItemID.CelestialShell)
                    .AddIngredient<ReaperToothNecklace>()

                    .AddIngredient<NeptunesBounty>()
                    .AddIngredient<PulseDragon>()
                    .AddIngredient<DevilsDevastation>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}