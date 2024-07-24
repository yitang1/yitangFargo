using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Wulfrum;
using CalamityMod.Items.Weapons.Summon;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using CalamityMod.CalPlayer;
using CalamityMod;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class WulfrumEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(163, 218, 129);

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
            player.AddEffect<WulfrumEffect>(Item);
            player.AddEffect<WulfrumRoverDrive>(Item);
            player.AddEffect<WulfrumTrinketofChi>(Item);

			CalamityPlayer calamityPlayer = player.Calamity();
			//钨钢盔甲 (旧版本的通用盔甲属性)
			if (player.HasEffect<WulfrumEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.statDefense += 3;
					if (player.statLife <= (int)(player.statLifeMax2 * 0.5))
					{
						player.statDefense += 10;
					}
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.aggro += 100;
					player.maxMinions++;
					calamityPlayer.rogueStealthMax += 0.5f;
					calamityPlayer.wearingRogueArmor = true;

					player.statDefense += 3;
					if (player.statLife <= (int)(player.statLifeMax2 * 0.5))
					{
						player.statDefense += 10;
					}
				}
            }
            //钨钢屏障生成仪
            if (player.HasEffect<WulfrumRoverDrive>())
            {
                ModContent.GetInstance<RoverDrive>().UpdateAccessory(player, hideVisual);
            }
            //气功念珠
            if (player.HasEffect<WulfrumTrinketofChi>())
            {
                ModContent.GetInstance<TrinketofChi>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[WulfrumFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[WulfrumFullEffects]", this.GetLocalizedValue("WulfrumFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<WulfrumHat>()
                .AddIngredient<WulfrumJacket>()
                .AddIngredient<WulfrumOveralls>()
                .AddIngredient<WulfrumController>()
                .AddIngredient<RoverDrive>()
                .AddIngredient<TrinketofChi>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class WulfrumEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<WulfrumEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class WulfrumRoverDrive : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<WulfrumEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class WulfrumTrinketofChi : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<WulfrumEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}