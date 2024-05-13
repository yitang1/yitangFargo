using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    [AutoloadEquip(EquipType.Wings)]
    public class FlightMasterySoulNew : FlightMasteryWings
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
            CreateRecipe()
                .AddIngredient(ItemID.EmpressFlightBooster)
                .AddIngredient(ItemID.BatWings)
                .AddIngredient(ItemID.CreativeWings)
                .AddIngredient(ItemID.FairyWings)
                .AddIngredient(ItemID.HarpyWings)
                .AddIngredient(ItemID.BoneWings)
                .AddIngredient(ItemID.FrozenWings)
                .AddIngredient(ItemID.FlameWings)
                .AddIngredient(ItemID.TatteredFairyWings)
                .AddIngredient(ItemID.FestiveWings)
                .AddIngredient(ItemID.BetsyWings)
                .AddIngredient(ItemID.FishronWings)
                .AddIngredient(ItemID.RainbowWings)
                .AddIngredient(ItemID.LongRainbowTrailWings)
                .AddIngredient(ItemID.GravityGlobe)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
