using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using FargowiltasSouls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    [AutoloadEquip(EquipType.Wings)]
    public class FlightMasterySoulOld : FlightMasteryWings
    {
        public override bool HasSupersonicSpeed => false;

        public static readonly Color ItemColor = new(56, 134, 255);
        protected override Color? nameColor => ItemColor;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AddEffects(player, Item);
        }
        public static void AddEffects(Player player, Item item)
        {
            Player Player = player;
            player.FargoSouls().FlightMasterySoul = true;
            Player.wingTimeMax = 999999;
            Player.wingTime = Player.wingTimeMax;
            Player.ignoreWater = true;

            player.AddEffect<FlightMasteryInsignia>(item);
            player.AddEffect<FlightMasteryGravity>(item);
            if (item.ModItem != null && item.ModItem is FlightMasteryWings fmWings && fmWings.HasSupersonicSpeed)
                player.AddEffect<SupersonicSpeedEffect>(item);
            //悬浮飞行
            if (Player.controlDown && Player.controlJump && !Player.mount.Active)
            {
                Player.position.Y -= Player.velocity.Y;
                if (Player.velocity.Y > 0.1f)
                    Player.velocity.Y = 0.1f;
                else if (Player.velocity.Y < -0.1f)
                    Player.velocity.Y = -0.1f;
            }
            //重力球
            player.AddEffect<MasoGravEffect>(item);
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.EmpressFlightBooster)
                    .AddIngredient(ItemID.CreativeWings)
                    .AddIngredient(ItemID.FairyWings)
                    .AddIngredient(ItemID.FrozenWings)
                    .AddIngredient(ItemID.HarpyWings)
                    .AddIngredient(ItemID.BatWings)
                    .AddIngredient(ItemID.FlameWings)
                    .AddIngredient(ItemID.BoneWings)
                    .AddIngredient(ItemID.FestiveWings)
                    .AddIngredient(ItemID.TatteredFairyWings)
                    .AddIngredient(ItemID.RainbowWings)
                    .AddIngredient(ItemID.BetsyWings)
                    .AddIngredient(ItemID.FishronWings)
                    .AddIngredient(ItemID.LongRainbowTrailWings)
                    .AddIngredient(ItemID.GravityGlobe)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<AscendantInsignia>()
                    .AddIngredient(ItemID.CreativeWings)
                    .AddIngredient<SkylineWings>()
                    .AddIngredient(ItemID.FairyWings)
                    .AddIngredient(ItemID.FrozenWings)
                    .AddIngredient(ItemID.FlameWings)
                    .AddIngredient<StarlightWings>()
                    .AddIngredient(ItemID.RainbowWings)
                    .AddIngredient(ItemID.FishronWings)
                    .AddIngredient(ItemID.LongRainbowTrailWings)
                    .AddIngredient<TarragonWings>()
                    .AddIngredient<SilvaWings>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}