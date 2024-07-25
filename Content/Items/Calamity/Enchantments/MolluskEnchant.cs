using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Mollusk;
using CalamityMod.Projectiles.Summon;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using yitangFargo.Common.Toggler;
using yitangFargo.Content.Projectiles.Minions;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class MolluskEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(58, 134, 167);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<MolluskEffect>(Item);
            player.AddEffect<MolluskFDeepDiver>(Item);
            player.AddEffect<MolluskGAquaticEmblem>(Item);
            ModContent.GetInstance<VictideEnchant>().UpdateAccessory(player, hideVisual);

            //软壳贝盔
            if (player.HasEffect<MolluskEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					player.Calamity().molluskSet = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<MolluskShellmet>().UpdateArmorSet(player);
				}
            }
			//深潜者
			if (player.HasEffect<MolluskFDeepDiver>())
            {
                ModContent.GetInstance<DeepDiver>().UpdateAccessory(player, hideVisual);
            }
            //海波纹章
            if (player.HasEffect<MolluskGAquaticEmblem>())
            {
                ModContent.GetInstance<AquaticEmblem>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[MolluskFullEffects]", "四只贝壳会在战斗中助你一臂之力");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[MolluskFullEffects]", this.GetLocalizedValue("MolluskFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MolluskShellmet>()
                .AddIngredient<MolluskShellplate>()
                .AddIngredient<MolluskShelleggings>()
                .AddIngredient<VictideEnchant>()
                .AddIngredient<DeepDiver>()
                .AddIngredient<AquaticEmblem>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class MolluskEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<MolluskEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //沉沦之贝
        public override void PostUpdateEquips(Player player)
        {
			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				if (player.whoAmI == Main.myPlayer)
				{
					int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(140);
					if (player.ownedProjectileCounts[ModContent.ProjectileType<ShellfishNew>()] < 4)
					{
						FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
							ModContent.ProjectileType<ShellfishNew>(), damage, 0f, player.whoAmI);
					}
				}
			}
        }
    }
    public class MolluskFDeepDiver : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<MolluskEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class MolluskGAquaticEmblem : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<MolluskEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}