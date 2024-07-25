using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.MarniteArchitect;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class MarniteEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(201, 220, 234);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.defense = 5;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<AMarniteEffect>(Item);
            player.AddEffect<AMarniteShieldEffect>(Item);

            //合成岩建筑师盔甲
            if (player.HasEffect<AMarniteEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.tileSpeed += 0.3f;
					player.blockRange += 8;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<MarniteArchitectHeadgear>().UpdateArmorSet(player);
				}
            }
            //合成岩斥力盾
            if (player.HasEffect<AMarniteShieldEffect>())
            {
                ModContent.GetInstance<MarniteRepulsionShield>().UpdateAccessory(player, hideVisual);
            }
            //古元粉末
            ModContent.GetInstance<ArchaicPowder>().UpdateAccessory(player, hideVisual);
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[MarniteFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[MarniteFullEffects]", this.GetLocalizedValue("MarniteFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MarniteArchitectHeadgear>()
                .AddIngredient<MarniteArchitectToga>()
                .AddIngredient(ItemID.EngineeringHelmet)
                .AddIngredient<MarniteRepulsionShield>()
                .AddIngredient<ArchaicPowder>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class AMarniteEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
        public override int ToggleItemType => ModContent.ItemType<MarniteEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AMarniteShieldEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<MiracleHeader>();
        public override int ToggleItemType => ModContent.ItemType<MarniteEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}