using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Projectiles.Typeless;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Reaver;
using CalamityMod.Items.Weapons.Melee;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using System.Collections.Generic;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class ReaverEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(58, 184, 73);

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
            player.AddEffect<ReaverEffect>(Item);
			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				player.AddEffect<ReaverEffectOrb>(Item);
			}
            player.AddEffect<ReaverNecklace>(Item);
            player.AddEffect<ReaverStone>(Item);

            //3个掠夺者盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<ReaverEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					//掠夺者战盔
					calamityPlayer.reaverDefense = true;
					//战盔不要降低飞行时间
					if (player.wingTimeMax > 0)
					{
						player.wingTimeMax = (int)(player.wingTimeMax / 0.7f);
					}
					//掠夺者面罩
					player.noFallDmg = true;
					player.autoJump = true;
					if (player.miscCounter % 3 == 2 && player.dashDelay > 0)
					{
						player.dashDelay--;
					}
					//掠夺者头饰
					player.findTreasure = true;
					player.blockRange += 4;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<ReaverHeadTank>().UpdateArmorSet(player);
					ModContent.GetInstance<ReaverHeadMobility>().UpdateArmorSet(player);
					ModContent.GetInstance<ReaverHeadExplore>().UpdateArmorSet(player);
				}
            }
            //掠夺者毒球
            if (player.HasEffect<ReaverEffectOrb>())
            {
                calamityPlayer.reaverExplore = true;
            }
            //恼怒项链
            if (player.HasEffect<ReaverNecklace>())
            {
                player.yitangFargo().VenomNecklace = true;
            }
            //绽花石
            if (player.HasEffect<ReaverStone>())
            {
                ModContent.GetInstance<BloomStone>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[ReaverFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[ReaverFullEffects]", this.GetLocalizedValue("ReaverFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyReaver")
                .AddIngredient<ReaverScaleMail>()
                .AddIngredient<ReaverCuisses>()
                .AddIngredient<FeralthornClaymore>()
                .AddIngredient<NecklaceofVexation>()
                .AddIngredient<BloomStone>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class ReaverEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<ReaverEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;

    }
    public class ReaverEffectOrb : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<ReaverEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //掠夺者毒球
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<ReaverOrb>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<ReaverOrb>(), 0, 0f, player.whoAmI);
                }
            }
        }
    }
    public class ReaverNecklace : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<ReaverEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class ReaverStone : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<ReaverEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}