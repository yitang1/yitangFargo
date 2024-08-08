using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using FargowiltasSouls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.Toggler;
using yitangFargo.Common;
using yitangFargo.Global.Config;
using yitangFargo.Common.Toggler;
using yitangFargo.Content.Items.Calamity.Souls;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class ColossusSoulOld : BaseSoul, ILocalizedModType
    {
        public new string LocalizationCategory => "Items";

		public static readonly Color ItemColor = new(252, 59, 0);
		protected override Color? nameColor => ItemColor;

		public override void SetDefaults()
        {
            base.SetDefaults();

            Item.defense = 10;
            Item.shieldSlot = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AddEffects(player, Item, 100, 0.15f, 5);
        }
        public static void AddEffects(Player player, Item item, int maxHP, float damageResist, int lifeRegen)
        {
            Player Player = player;
            player.FargoSouls().ColossusSoul = true;
            Player.statLifeMax2 += maxHP;
            Player.endurance += damageResist;
            Player.lifeRegen += lifeRegen;

            Player.buffImmune[BuffID.Chilled] = true;
            Player.buffImmune[BuffID.Frozen] = true;
			Player.buffImmune[BuffID.WindPushed] = true;
            Player.buffImmune[BuffID.Stoned] = true;
            Player.buffImmune[BuffID.Weak] = true;
            Player.buffImmune[BuffID.BrokenArmor] = true;
            Player.buffImmune[BuffID.Bleeding] = true;
            Player.buffImmune[BuffID.Poisoned] = true;
            Player.buffImmune[BuffID.Slow] = true;
            Player.buffImmune[BuffID.Confused] = true;
            Player.buffImmune[BuffID.Silenced] = true;
            Player.buffImmune[BuffID.Cursed] = true;
            Player.buffImmune[BuffID.Darkness] = true;
            Player.noKnockback = true;
            Player.fireWalk = true;
            Player.noFallDmg = true;
            player.AddEffect<DefenseBrainEffect>(item);
            //神话护身符
            Player.pStone = true;
            player.AddEffect<DefenseStarEffect>(item);
            player.AddEffect<DefenseBeeEffect>(item);
            Player.longInvince = true;
            //闪亮石
            Player.shinyStone = true;
            player.AddEffect<FleshKnuckleEffect>(item);
            player.AddEffect<FrozenTurtleEffect>(item);
            player.AddEffect<PaladinShieldEffect>(item);
            player.AddEffect<ShimmerImmunityEffect>(item);
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
			base.SafeModifyTooltips(tooltips);

			if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                tooltips.ReplaceText("[ColossusEffects]", this.GetLocalizedValue("ColossusCalamity"));
            }
            else if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                tooltips.ReplaceText("[ColossusEffects]", this.GetLocalizedValue("ColossusFargo"));
            }
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.ObsidianHorseshoe)
                    .AddIngredient(ItemID.WormScarf)
                    .AddIngredient(ItemID.BrainOfConfusion)
                    .AddIngredient(ItemID.CharmofMyths)
                    .AddIngredient(ItemID.BeeCloak)
                    .AddIngredient(ItemID.StarVeil)
                    .AddIngredient(ItemID.ShinyStone)
                    .AddIngredient(ItemID.HeroShield)
                    .AddIngredient(ItemID.FrozenShield)
                    .AddIngredient(ItemID.AnkhShield)
                    .AddIngredient(ItemID.ShimmerCloak)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.ObsidianHorseshoe)
                    .AddIngredient(ItemID.BeeCloak)
                    .AddIngredient<BloodyWormScarf>()
                    .AddIngredient(ItemID.ShinyStone)
                    .AddIngredient(ItemID.HeroShield)
                    .AddIngredient(ItemID.ShimmerCloak)
                    .AddIngredient<TheAmalgam>()
                    .AddIngredient<AsgardianAegis>()
                    .AddIngredient<RampartofDeities>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}