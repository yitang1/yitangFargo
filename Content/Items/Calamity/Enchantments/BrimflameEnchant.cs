using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Brimflame;
using CalamityMod.Items.Weapons.Magic;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Microsoft.Xna.Framework;
using yitangFargo.Common.Toggler;
using CalamityMod;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class BrimflameEnchant : BaseEnchant
    {
        public override Color nameColor => new(142, 71, 81);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<BloodYBrimEffect>(Item);
            player.AddEffect<BloodYVoidC>(Item);
            player.AddEffect<BloodYVoidE>(Item);

            //硫火盔甲
            if (player.HasEffect<BloodYBrimEffect>())
            {
                player.Calamity().brimflameSet = true;
            }
            //灾劫虚空
            if (player.HasEffect<BloodYVoidC>())
            {
                ModContent.GetInstance<VoidofCalamity>().UpdateAccessory(player, hideVisual);
            }
            //终结虚空
            if (player.HasEffect<BloodYVoidE>())
            {
                ModContent.GetInstance<VoidofExtinction>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BrimflameScowl>()
                .AddIngredient<BrimflameRobes>()
                .AddIngredient<BrimflameBoots>()
                .AddIngredient<BrimroseStaff>()
                .AddIngredient<VoidofCalamity>()
                .AddIngredient<VoidofExtinction>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class BloodYBrimEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BrimflameEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BloodYVoidC : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BrimflameEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BloodYVoidE : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ExaltationHeader>();
        public override int ToggleItemType => ModContent.ItemType<BrimflameEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}