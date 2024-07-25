using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Brimflame;
using CalamityMod.Items.Weapons.Magic;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class BrimflameEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(142, 71, 81);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<BloodYBrimEffect>(Item);
            player.AddEffect<BloodYVoidC>(Item);
            player.AddEffect<BloodYVoidE>(Item);

            //硫火盔甲
            if (player.HasEffect<BloodYBrimEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.Calamity().brimflameSet = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<BrimflameScowl>().UpdateArmorSet(player);
				}
            }
            //灾劫虚空
            if (player.HasEffect<BloodYVoidC>())
            {
                ModContent.GetInstance<VoidofCalamity>().UpdateAccessory(player, hideVisual);
            }
            //终结虚空
            if (player.HasEffect<BloodYVoidE>())
            {
                ModContent.GetInstance<VoidofExtinction>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[BrimflameFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[BrimflameFullEffects]", this.GetLocalizedValue("BrimflameFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BrimflameScowl>()
                .AddIngredient<BrimflameRobes>()
                .AddIngredient<BrimflameBoots>()
                .AddIngredient<BrimroseStaff>()
                .AddIngredient<VoidofCalamity>()
                .AddIngredient<VoidofExtinction>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class BloodYBrimEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BrimflameEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BloodYVoidC : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BrimflameEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class BloodYVoidE : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BrimflameEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}