using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    [AutoloadEquip(EquipType.Shield)]
    public class TerrariaSoulNew : BaseSoul
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 24));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
        {
            if (line.Mod == "Terraria" && line.Name == "ItemName")
            {
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                GameShaders.Armor.Apply(GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye), Item, null);
                Utils.DrawBorderString(Main.spriteBatch, line.Text, new Vector2(line.X, line.Y), Color.White, 1);
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
                return false;
            }
            return true;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = Item.buyPrice(5, 0, 0, 0);
            Item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoSoulsPlayer modPlayer = player.FargoSouls();
            modPlayer.TerrariaSoul = true;

            //森林之力
            ModContent.GetInstance<TimberForce>().UpdateAccessory(player, hideVisual);
            //泰拉之力
            ModContent.GetInstance<TerraForce>().UpdateAccessory(player, hideVisual);
            //大地之力
            ModContent.GetInstance<EarthForce>().UpdateAccessory(player, hideVisual);
            //自然之力
            ModContent.GetInstance<NatureForce>().UpdateAccessory(player, hideVisual);
            //生命之力
            ModContent.GetInstance<LifeForce>().UpdateAccessory(player, hideVisual);
            //心灵之力
            ModContent.GetInstance<SpiritForce>().UpdateAccessory(player, hideVisual);
            //暗影之力
            ModContent.GetInstance<ShadowForce>().UpdateAccessory(player, hideVisual);
            //意志之力
            ModContent.GetInstance<WillForce>().UpdateAccessory(player, hideVisual);
            //宇宙之力
            ModContent.GetInstance<CosmoForce>().UpdateAccessory(player, hideVisual);
        }

        public override void UpdateVanity(Player player)
        {
            player.FargoSouls().WoodEnchantDiscount = true;
            player.AddEffect<GoldToPiggy>(Item);
        }

        public override void UpdateInventory(Player player)
        {
            player.FargoSouls().WoodEnchantDiscount = true;
            player.AddEffect<GoldToPiggy>(Item);
            AshWoodEnchant.PassiveEffect(player);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<TimberForce>()
                .AddIngredient<TerraForce>()
                .AddIngredient<EarthForce>()
                .AddIngredient<NatureForce>()
                .AddIngredient<LifeForce>()
                .AddIngredient<SpiritForce>()
                .AddIngredient<ShadowForce>()
                .AddIngredient<WillForce>()
                .AddIngredient<CosmoForce>()
                .AddIngredient<AbomEnergy>(10)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
