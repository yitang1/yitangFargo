using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using Microsoft.Xna.Framework;
using yitangFargo.Global.Config;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using System.Collections.Generic;
using Terraria.Localization;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class SnipersSoulNew : BaseSoul, ILocalizedModType
    {
        public new string LocalizationCategory => "Items";

		public static readonly Color ItemColor = new(188, 253, 68);
		protected override Color? nameColor => ItemColor;

		public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //降低弹药消耗
            player.FargoSouls().RangedSoul = true;
            player.GetDamage(DamageClass.Ranged) += 0.3f;
            player.GetCritChance(DamageClass.Ranged) += 15;

            //狙击镜
            player.AddEffect<SniperScopeEffect>(Item);
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
			base.SafeModifyTooltips(tooltips);

			if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                tooltips.ReplaceText("[SnipersEffects]", this.GetLocalizedValue("SnipersCalamity"));
            }
            else if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                tooltips.ReplaceText("[SnipersEffects]", this.GetLocalizedValue("SnipersFargo"));
            }
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient<SharpshootersEssence>()
                    .AddIngredient(ItemID.MoltenQuiver)
                    .AddIngredient(ItemID.StalkersQuiver)
                    .AddIngredient(ItemID.ReconScope)
                    .AddIngredient(ItemID.DartPistol)
                    .AddIngredient(ItemID.Megashark)
                    .AddIngredient(ItemID.PulseBow)
                    .AddIngredient(ItemID.NailGun)
                    .AddIngredient(ItemID.PiranhaGun)
                    .AddIngredient(ItemID.SniperRifle)
                    .AddIngredient(ItemID.Tsunami)
                    .AddIngredient(ItemID.StakeLauncher)
                    .AddIngredient(ItemID.ElfMelter)
                    .AddIngredient(ItemID.Xenopopper)
                    .AddIngredient(ItemID.Celeb2)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<SharpshootersEssence>()
                    .AddIngredient(ItemID.ReconScope)
                    .AddIngredient<DynamoStemCells>()
                    .AddIngredient<QuiverofNihility>()
                    .AddIngredient(ItemID.DartPistol)
                    .AddIngredient<SeasSearing>()
                    .AddIngredient(ItemID.NailGun)
                    .AddIngredient(ItemID.StakeLauncher)
                    .AddIngredient(ItemID.ElfMelter)
                    .AddIngredient<Vortexpopper>()
                    .AddIngredient(ItemID.Celeb2)
                    .AddIngredient<PridefulHuntersPlanarRipper>()
                    .AddIngredient<HandheldTank>()
                    .AddIngredient<Alluvion>()
                    .AddIngredient<Starmageddon>()
                    .AddIngredient<Ultima>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}