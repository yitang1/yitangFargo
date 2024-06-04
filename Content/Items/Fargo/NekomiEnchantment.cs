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

namespace yitangFargo.Content.Items.Fargo
{
    public class NekomiEnchantment : BaseEnchant
    {
        public override Color nameColor => Color.Pink;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<ANekomiEffect>(Item);
            player.AddEffect<ANekomiSparkling>(Item);

            //猫猫睡衣盔甲
            if (player.HasEffect<ANekomiEffect>())
            {
                ModContent.GetInstance<NekomiHood>().UpdateArmorSet(player);
            }
            //闪烁崇心
            if (player.HasEffect<ANekomiSparkling>())
            {
                ModContent.GetInstance<SparklingAdoration>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<NekomiHood>()
                .AddIngredient<NekomiHoodie>()
                .AddIngredient<NekomiLeggings>()
                .AddIngredient<SparklingAdoration>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class ANekomiEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<NekomiEnchantment>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
    public class ANekomiSparkling : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<NekomiEnchantment>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}