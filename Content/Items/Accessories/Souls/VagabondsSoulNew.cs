using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Essences;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class VagabondsSoulNew : BaseSoul
    {
        protected override Color? nameColor => new Color(217, 144, 67);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<RogueDamageClass>() += 0.3f;
            player.Calamity().rogueVelocity += 0.15f;
            player.GetCritChance<RogueDamageClass>() += 0.15f;
            if (player.AddEffect<NanotechEffect>(Item))
            {
                ModContent.GetInstance<Nanotech>().UpdateAccessory(player, hideVisual);
            }
            if (player.AddEffect<EclipseMirrorEffect>(Item))
            {
                ModContent.GetInstance<EclipseMirror>().UpdateAccessory(player, hideVisual);
            }
            if (player.AddEffect<DragonScalesEffect>(Item))
            {
                ModContent.GetInstance<DragonScales>().UpdateAccessory(player, hideVisual);
            }
            if (player.AddEffect<VeneratedLocketEffect>(Item))
            {
                ModContent.GetInstance<VeneratedLocket>().UpdateAccessory(player, hideVisual);
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<OutlawsEssence>()
                .AddIngredient<EclipseMirror>()
                .AddIngredient<Nanotech>()
                .AddIngredient<DragonScales>()
                .AddIngredient<VeneratedLocket>()
                .AddIngredient<WaveSkipper>()
                .AddIngredient<GraveGrimreaver>()
                .AddIngredient<SpentFuelContainer>()
                .AddIngredient<TheSyringe>()
                .AddIngredient<RegulusRiot>()
                .AddIngredient<CelestialReaper>()
                .AddIngredient<Valediction>()
                .AddIngredient<ExecutionersBlade>()
                .AddIngredient<SearedPan>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
