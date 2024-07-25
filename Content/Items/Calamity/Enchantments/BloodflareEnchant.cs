using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Bloodflare;
using CalamityMod.Rarities;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class BloodflareEnchant : BaseEnchant, ILocalizedModType
	{
        public override Color nameColor => new(157, 12, 77);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<PureGreen>();
            Item.value = Item.buyPrice(0, 50, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<BloodEffect>(Item);
			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				player.AddEffect<BloodMinion>(Item);
			}
            player.AddEffect<BloodTheChalice>(Item);
            player.AddEffect<BloodTheCore>(Item);
            ModContent.GetInstance<BrimflameEnchant>().UpdateAccessory(player, hideVisual);

            //血炎盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<BloodEffect>())
            {
				if (!ytFargoConfig.Instance.FullCalamityEnchant)
				{
					calamityPlayer.bloodflareSet = true;
					player.crimsonRegen = true;

					calamityPlayer.bloodflareMelee = true;
					calamityPlayer.bloodflareRanged = true;
					calamityPlayer.bloodflareMage = true;
					calamityPlayer.bloodflareThrowing = true;
				}
				else if (ytFargoConfig.Instance.FullCalamityEnchant)
				{
					ModContent.GetInstance<BloodflareHeadMelee>().UpdateArmorSet(player);
					ModContent.GetInstance<BloodflareHeadRanged>().UpdateArmorSet(player);
					ModContent.GetInstance<BloodflareHeadMagic>().UpdateArmorSet(player);
					ModContent.GetInstance<BloodflareHeadSummon>().UpdateArmorSet(player);
					ModContent.GetInstance<BloodflareHeadRogue>().UpdateArmorSet(player);
				}
            }
            //噬魂幽花地雷
            if (player.HasEffect<BloodMinion>())
            {
                calamityPlayer.bloodflareSummon = true;
            }
            //血神圣杯
            if (player.HasEffect<BloodTheChalice>())
            {
                ModContent.GetInstance<ChaliceOfTheBloodGod>().UpdateAccessory(player, hideVisual);
            }
            //血炎晶核
            if (player.HasEffect<BloodTheCore>())
            {
                ModContent.GetInstance<BloodflareCore>().UpdateAccessory(player, hideVisual);
            }
        }

		public override void SafeModifyTooltips(List<TooltipLine> tooltips)
		{
			base.SafeModifyTooltips(tooltips);

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[BloodflareFullEffects]", "");
			}
			else if (ytFargoConfig.Instance.FullCalamityEnchant)
			{
				tooltips.ReplaceText("[BloodflareFullEffects]", this.GetLocalizedValue("BloodflareFullTooltip"));
			}
		}

		public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyBloodflare")
                .AddIngredient<BloodflareBodyArmor>()
                .AddIngredient<BloodflareCuisses>()
                .AddIngredient<BrimflameEnchant>()
                .AddIngredient<ChaliceOfTheBloodGod>()
                .AddIngredient<BloodflareCore>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class BloodEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class BloodMinion : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool MinionEffect => true;
    }
    public class BloodTheChalice : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BloodTheCore : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BloodflareEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}