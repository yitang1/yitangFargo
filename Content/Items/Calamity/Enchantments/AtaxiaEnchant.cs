using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Hydrothermic;
using CalamityMod.Items.Weapons.Melee;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Global.Config;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class AtaxiaEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(162, 77, 77);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(0, 20, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<AtaxiaEffect>(Item);
            player.AddEffect<AtaxiaMinion>(Item);
            player.AddEffect<AtaxiaPauldron>(Item);

            //渊泉盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<AtaxiaEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					calamityPlayer.ataxiaBlaze = true;

					calamityPlayer.ataxiaGeyser = true;
					calamityPlayer.ataxiaBolt = true;
					calamityPlayer.ataxiaMage = true;
					calamityPlayer.ataxiaVolley = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<HydrothermicHeadMelee>().UpdateArmorSet(player);
					ModContent.GetInstance<HydrothermicHeadRanged>().UpdateArmorSet(player);
					ModContent.GetInstance<HydrothermicHeadMagic>().UpdateArmorSet(player);
					ModContent.GetInstance<HydrothermicHeadSummon>().UpdateArmorSet(player);
					ModContent.GetInstance<HydrothermicHeadRogue>().UpdateArmorSet(player);
				}
            }
            //沸腾渊泉
            if (player.HasEffect<AtaxiaMinion>())
            {
                calamityPlayer.chaosSpirit = true;
            }
            //熔火碎矿肩甲
            if (player.HasEffect<AtaxiaPauldron>())
            {
                ModContent.GetInstance<SlagsplitterPauldron>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[AtaxiaFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[AtaxiaFullEffects]", this.GetLocalizedValue("AtaxiaFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyAtaxia")
                .AddIngredient<HydrothermicArmor>()
                .AddIngredient<HydrothermicSubligar>()
                .AddIngredient<VulcaniteLance>()
                .AddIngredient<StygianShield>()
                .AddIngredient<SlagsplitterPauldron>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class AtaxiaEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AtaxiaEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class AtaxiaMinion : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AtaxiaEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //沸腾渊泉
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(190);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<HydrothermicVent>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<HydrothermicVent>(), damage, 0f, player.whoAmI, 38f, 0f);
                }
            }
        }
    }
    public class AtaxiaPauldron : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<AtaxiaEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}