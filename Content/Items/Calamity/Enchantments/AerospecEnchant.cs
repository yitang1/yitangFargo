using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Buffs.Summon;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Aerospec;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Projectiles.Summon;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Global.GlobalItems;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class AerospecEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(190, 174, 120);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(0, 4, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<AerospecEffect>(Item);
            player.AddEffect<AerospecEValkyrie>(Item);
            player.AddEffect<AerospecGladiatorsLocket>(Item);
            player.AddEffect<AerospecGraniteCore>(Item);

            //天蓝盔甲
            if (player.HasEffect<AerospecEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.Calamity().aeroSet = true;
					player.noFallDmg = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<AerospecHelm>().UpdateArmorSet(player);
					ModContent.GetInstance<AerospecHood>().UpdateArmorSet(player);
					ModContent.GetInstance<AerospecHat>().UpdateArmorSet(player);
					ModContent.GetInstance<AerospecHelmet>().UpdateArmorSet(player);
					ModContent.GetInstance<AerospecHeadgear>().UpdateArmorSet(player);
				}
            }
            //天武神
            if (player.HasEffect<AerospecEValkyrie>())
            {
                player.Calamity().valkyrie = true;
            }
            //角斗士金锁
            if (player.HasEffect<AerospecGladiatorsLocket>())
            {
                ModContent.GetInstance<GladiatorsLocket>().UpdateAccessory(player, hideVisual);
            }
            //不稳定花岗岩核心
            if (player.HasEffect<AerospecGraniteCore>())
            {
                ModContent.GetInstance<UnstableGraniteCore>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[AerospecFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[AerospecFullEffects]", this.GetLocalizedValue("AerospecFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyAerospec")
                .AddIngredient<AerospecBreastplate>()
                .AddIngredient<AerospecLeggings>()
                .AddIngredient<GladiatorsLocket>()
                .AddIngredient<UnstableGraniteCore>()
                .AddIngredient<Tradewinds>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class AerospecEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AerospecEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AerospecEValkyrie : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AerospecEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //天武神
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(20);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<Valkyrie>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<Valkyrie>(), damage, 0f, player.whoAmI);
                }
            }
        }
    }
    public class AerospecGladiatorsLocket : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AerospecEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class AerospecGraniteCore : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AerospecEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}