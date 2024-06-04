using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.FathomSwarmer;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class FathomSwarmerEnchant : BaseEnchant
    {
        public override Color nameColor => new(121, 192, 196);

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
            player.AddEffect<FathomREffect>(Item);
            player.AddEffect<FathomRLumenAmulet>(Item);
            player.AddEffect<FathomRTransformer>(Item);
            ModContent.GetInstance<SulphurousEnchant>().UpdateAccessory(player, hideVisual);

            //幻渊鱼群盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<FathomREffect>())
            {
                calamityPlayer.fathomSwarmer = true;
                calamityPlayer.fathomSwarmerBreastplate = true;

                player.spikedBoots = 2;
                player.ignoreWater = true;
                if (player.breath <= player.breathMax + 2 && !calamityPlayer.ZoneAbyss)
                {
                    player.breath = player.breathMax + 3;
                }
                if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
                {
                    player.GetDamage<SummonDamageClass>() += 0.3f;
                    player.statDefense += 10;
                    player.lifeRegen += 5;
                    player.moveSpeed += 0.4f;
                    Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.3f, 0.9f, 1.35f);
                }
                if (player.wingTime <= 0)
                {
                    player.accFlipper = true;
                }
            }
            //流明护身符
            if (player.HasEffect<FathomRLumenAmulet>())
            {
                ModContent.GetInstance<LumenousAmulet>().UpdateAccessory(player, hideVisual);
            }
            //变压器
            if (player.HasEffect<FathomRTransformer>())
            {
                ModContent.GetInstance<TheTransformer>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<FathomSwarmerVisage>()
                .AddIngredient<FathomSwarmerBreastplate>()
                .AddIngredient<FathomSwarmerBoots>()
                .AddIngredient<SulphurousEnchant>()
                .AddIngredient<LumenousAmulet>()
                .AddIngredient<TheTransformer>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class FathomREffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<FathomSwarmerEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class FathomRLumenAmulet : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<FathomSwarmerEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class FathomRTransformer : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<FathomSwarmerEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;
    }
}