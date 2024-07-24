using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.SnowRuffian;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class SnowRuffianEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(138, 170, 182);
        private bool shouldBoost = false;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<DaedalusSnowEffect>(Item);
            player.AddEffect<DaedalusSnowJewel>(Item);
            player.AddEffect<DaedalusSnowTooth>(Item);

            //雪境暴徒盔甲
            if (player.HasEffect<DaedalusSnowEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.Calamity().snowRuffianSet = true;

					if (player.controlJump)
					{
						player.noFallDmg = true;
						player.UpdateJumpHeight();
						if (shouldBoost && !player.mount.Active)
						{
							player.velocity.X *= 1.1f;
							shouldBoost = false;
						}
					}
					else if (!shouldBoost && player.velocity.Y == 0)
					{
						shouldBoost = true;
					}
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<SnowRuffianMask>().UpdateArmorSet(player);
				}
            }
            //潜遁者宝石
            if (player.HasEffect<DaedalusSnowJewel>())
            {
                ModContent.GetInstance<ScuttlersJewel>().UpdateAccessory(player, hideVisual);
            }
            //腐烂犬齿
            if (player.HasEffect<DaedalusSnowTooth>())
            {
                ModContent.GetInstance<RottenDogtooth>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[SnowRuffianFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[SnowRuffianFullEffects]", this.GetLocalizedValue("SnowRuffianFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<SnowRuffianMask>()
                .AddIngredient<SnowRuffianChestplate>()
                .AddIngredient<SnowRuffianGreaves>()
                .AddIngredient<ScuttlersJewel>()
                .AddIngredient<RottenDogtooth>()
                .AddIngredient<GleamingDagger>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class DaedalusSnowEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SnowRuffianEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class DaedalusSnowJewel : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SnowRuffianEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class DaedalusSnowTooth : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SnowRuffianEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}