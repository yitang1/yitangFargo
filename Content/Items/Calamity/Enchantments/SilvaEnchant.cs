using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class SilvaEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(20, 163, 108);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<DarkBlue>();
            Item.value = Item.buyPrice(0, 70, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<SilvaEffect>(Item);
			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				player.AddEffect<SilvaEffectCrystal>(Item);
			}
            player.AddEffect<SilvaHeartElements>(Item);
            player.AddEffect<SilvaTheSponge>(Item);

            //始源林海盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<SilvaEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					calamityPlayer.silvaSet = true;
					calamityPlayer.silvaMage = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<SilvaHeadMagic>().UpdateArmorSet(player);
					ModContent.GetInstance<SilvaHeadSummon>().UpdateArmorSet(player);
				}
            }
            //始源林海水晶
            if (player.HasEffect<SilvaEffectCrystal>())
            {
                calamityPlayer.silvaSummon = true;
            }
			//元灵之心
			if (player.HasEffect<SilvaHeartElements>())
			{
				ModContent.GetInstance<HeartoftheElements>().UpdateAccessory(player, hideVisual);
			}
            //化绵留香石
            if (player.HasEffect<SilvaTheSponge>())
            {
                ModContent.GetInstance<TheSponge>().UpdateAccessory(player, hideVisual);
            }
            //空灵护符
            ModContent.GetInstance<EtherealTalisman>().UpdateAccessory(player, hideVisual);
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[SilvaFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[SilvaFullEffects]", this.GetLocalizedValue("SilvaFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnySilva")
                .AddIngredient<SilvaArmor>()
                .AddIngredient<SilvaLeggings>()
                .AddIngredient<TheSponge>()
                .AddIngredient<EtherealTalisman>()
                .AddIngredient<HeartoftheElements>()
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }

    public class SilvaEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class SilvaEffectCrystal : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
        //始源林海水晶
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(600);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<SilvaCrystal>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<SilvaCrystal>(), damage, 0f, player.whoAmI, -20f, 0f);
                }
            }
        }
    }
    public class SilvaHeartElements : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
		public override bool MinionEffect => true;
	}
    public class SilvaTheSponge : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SilvaEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}