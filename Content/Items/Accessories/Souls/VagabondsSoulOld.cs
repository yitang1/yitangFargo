using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.DraedonsArsenal;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Essences;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class VagabondsSoulOld : BaseSoul
    {
        protected override Color? nameColor => new Color(217, 144, 67);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<ThrowingDamageClass>() += 0.3f;
            player.GetCritChance<ThrowingDamageClass>() += 15;
            player.Calamity().rogueVelocity += 0.15f;

            if (player.AddEffect<EclipseMirrorEffect>(Item))
            {
                ModContent.GetInstance<EclipseMirror>().UpdateAccessory(player, hideVisual);
            }
            if (player.AddEffect<NanotechEffect>(Item))
            {
                ModContent.GetInstance<Nanotech>().UpdateAccessory(player, hideVisual);
            }
            if (player.AddEffect<VeneratedLocketEffect>(Item))
            {
                ModContent.GetInstance<VeneratedLocket>().UpdateAccessory(player, hideVisual);
            }
            if (player.AddEffect<DragonScalesEffect>(Item))
            {
                ModContent.GetInstance<DragonScales>().UpdateAccessory(player, hideVisual);
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

                .AddIngredient<HellsSun>()
                .AddIngredient<WavePounder>()
                .AddIngredient<TheOldReaper>()
                .AddIngredient<EclipsesFall>()
                .AddIngredient<Seraphim>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }

	//日蚀魔镜
	public class EclipseMirrorEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<CalamityVagabondsHeader>();
		public override int ToggleItemType => ModContent.ItemType<EclipseMirror>();
		public override bool IgnoresMutantPresence => true;
	}
	//纳米技术
	public class NanotechEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<CalamityVagabondsHeader>();
		public override int ToggleItemType => ModContent.ItemType<Nanotech>();
		public override bool IgnoresMutantPresence => true;
	}
	//敬天神盗盒
	public class VeneratedLocketEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<CalamityVagabondsHeader>();
		public override int ToggleItemType => ModContent.ItemType<VeneratedLocket>();
		public override bool IgnoresMutantPresence => true;
	}
	//浴火龙鳞
	public class DragonScalesEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<CalamityVagabondsHeader>();
		public override int ToggleItemType => ModContent.ItemType<DragonScales>();
		public override bool IgnoresMutantPresence => true;
	}
}