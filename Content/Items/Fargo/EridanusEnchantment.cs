using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Content.Items.Armor;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;
using FargowiltasSouls;

namespace yitangFargo.Content.Items.Fargo
{
    public class EridanusEnchantment : BaseEnchant
    {
        public override Color nameColor => Color.Purple;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(0, 40, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<EridanusEffect>(Item);

            //波江盔甲
            if (player.HasEffect<EridanusEffect>())
            {
                ModContent.GetInstance<EridanusHat>().UpdateArmorSet(player);
                //不再默认增加玩家的基础数值，不然会变得超模，大概
                DamageClass damageClass = player.ProcessDamageTypeFromHeldItem();
                player.GetDamage(damageClass) -= 0.20f;
                player.GetCritChance(damageClass) -= 10;
            }
            //
            //if (player.HasEffect<EridanusCore>())
            //{
            //    ModContent.GetInstance<>().UpdateAccessory(player, hideVisual);
            //}
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<EridanusHat>()
                .AddIngredient<EridanusBattleplate>()
                .AddIngredient<EridanusLegwear>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class EridanusEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<EridanusEnchantment>();
        public override bool IgnoresMutantPresence => true;
    }
    //public class EridanusCore : AccessoryEffect
    //{
    //    public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
    //    public override int ToggleItemType => ModContent.ItemType<EridanusEnchantment>();
    //}
}