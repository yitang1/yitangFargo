using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Essences;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using CalamityMod.Items.Weapons.DraedonsArsenal;

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
            //盗贼的魂饰品默认为龙后时期
            CreateRecipe()
                .AddIngredient<OutlawsEssence>()
                .AddIngredient<EclipseMirror>()
                .AddIngredient<Nanotech>()
                .AddIngredient<VeneratedLocket>()
                .AddIngredient<DragonScales>()
                .AddIngredient<WaveSkipper>()
                .AddIngredient<GraveGrimreaver>()
                .AddIngredient<Exorcism>()
                .AddIngredient<HeavenfallenStardisk>()
                .AddIngredient<Malachite>()
                .AddIngredient<RegulusRiot>()
                .AddIngredient<AlphaVirus>()
                .AddIngredient<WavePounder>()
                .AddIngredient<TheOldReaper>()
                .AddIngredient<EclipsesFall>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}