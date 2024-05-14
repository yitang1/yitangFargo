using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Armor;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Fargo
{
    public class TrueMutantEnchantment : BaseEnchant
    {
        public override Color nameColor => new Color(Main.DiscoR, 51, 255 - (int)(Main.DiscoR * 0.4));

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(0, 90, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<TrueMutantEffect>(Item);
            player.AddEffect<TrueMutantEye>(Item);

            //真·突变盔甲
            if (player.HasEffect<TrueMutantEffect>())
            {
                ModContent.GetInstance<MutantMask>().UpdateArmorSet(player);
            }
            //突变之眼
            if (player.HasEffect<TrueMutantEye>())
            {
                ModContent.GetInstance<MutantEye>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MutantMask>()
                .AddIngredient<MutantBody>()
                .AddIngredient<MutantPants>()
                .AddIngredient<MutantEye>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }

    public class TrueMutantEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<TrueMutantEnchantment>();
        public override bool IgnoresMutantPresence => true;
    }
    public class TrueMutantEye : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EternityHeader>();
        public override int ToggleItemType => ModContent.ItemType<TrueMutantEnchantment>();
        public override bool IgnoresMutantPresence => true;
    }
}