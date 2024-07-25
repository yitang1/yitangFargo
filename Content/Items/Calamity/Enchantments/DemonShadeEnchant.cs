using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Projectiles.Typeless;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Demonshade;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class DemonShadeEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(184, 19, 19);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = Item.buyPrice(0, 90, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<DemonShadeEffect>(Item);
            player.AddEffect<DemonShadeFAngelic>(Item);
            player.AddEffect<DemonShadeFCrystal>(Item);
            player.AddEffect<DemonShadeGCommunity>(Item);

            //魔影盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<DemonShadeEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					calamityPlayer.dsSetBonus = true;
					calamityPlayer.redDevil = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<DemonshadeHelm>().UpdateArmorSet(player);
				}
            }
            //圣天誓盟
            if (player.HasEffect<DemonShadeFAngelic>())
            {
                ModContent.GetInstance<AngelicAlliance>().UpdateAccessory(player, hideVisual);
            }
            //渎神魂晶
            if (player.HasEffect<DemonShadeFCrystal>())
            {
                ModContent.GetInstance<ProfanedSoulCrystal>().UpdateAccessory(player, hideVisual);
            }
            //幻灭心元石
            if (player.HasEffect<DemonShadeGCommunity>())
            {
                ModContent.GetInstance<ShatteredCommunity>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[DemonShadeFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[DemonShadeFullEffects]", this.GetLocalizedValue("DemonShadeFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<DemonshadeHelm>()
                .AddIngredient<DemonshadeBreastplate>()
                .AddIngredient<DemonshadeGreaves>()
                .AddIngredient<AngelicAlliance>()
                .AddIngredient<ProfanedSoulCrystal>()
                .AddIngredient<ShatteredCommunity>()
                .AddTile<DraedonsForge>()
                .Register();
        }
    }

    public class DemonShadeEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //红恶魔
        public override void PostUpdateEquips(Player player)
        {
			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				if (player.whoAmI == Main.myPlayer)
				{
					int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(10000);
					if (player.ownedProjectileCounts[ModContent.ProjectileType<DemonshadeRedDevil>()] < 1)
					{
						FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
							ModContent.ProjectileType<DemonshadeRedDevil>(), damage, 0f, player.whoAmI, 0f, 0f);
					}
				}
			}
        }
    }
    public class DemonShadeFAngelic : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class DemonShadeFCrystal : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class DemonShadeGCommunity : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DevastationHeader>();
        public override int ToggleItemType => ModContent.ItemType<DemonShadeEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}