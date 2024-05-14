using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Content.Items.Armor;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using FargowiltasSouls;

namespace yitangFargo.Content.Items.Fargo
{
    public class StyxEnchantment : BaseEnchant
    {
        public override Color nameColor => Color.Orange;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(0, 50, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<StyxEffect>(Item);
            player.AddEffect<StyxWand>(Item);

            //冥河盔甲
            if (player.HasEffect<StyxEffect>())
            {
                ModContent.GetInstance<StyxCrown>().UpdateArmorSet(player);
                //不再增加玩家的基础数值
                player.GetDamage(player.ProcessDamageTypeFromHeldItem()) -= 0.20f;
            }
            //憎恶手杖
            if (player.HasEffect<StyxWand>())
            {
                ModContent.GetInstance<AbominableWand>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<StyxCrown>()
                .AddIngredient<StyxChestplate>()
                .AddIngredient<StyxLeggings>()
                .AddIngredient<AbominableWand>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }

    public class StyxEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<StyxEnchantment>();
        public override bool IgnoresMutantPresence => true;
    }
    public class StyxWand : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<StyxEnchantment>();
        public override bool IgnoresMutantPresence => true;
    }
}