using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using yitangFargo.Global.Config;
using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.Mounts.Minecarts;
using CalamityMod.Items.Mounts;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class SupersonicSoulNew : BaseSoul
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = 750000;
        }
        public static readonly Color ItemColor = new(238, 0, 69);
        protected override Color? nameColor => ItemColor;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoSoulsPlayer modPlayer = player.FargoSouls();
            AddEffects(player, Item, hideVisual);
        }
        public static void AddEffects(Player player, Item item, bool hideVisual)
        {
            Player Player = player;
            FargoSoulsPlayer modPlayer = player.FargoSouls();

            player.AddEffect<MasoAeolusFrog>(item);
            player.AddEffect<MasoAeolusFlower>(item);
            player.AddEffect<ZephyrJump>(item);

            modPlayer.SupersonicSoul = true;

            if (Player.AddEffect<SupersonicSpeedEffect>(item) && !modPlayer.noSupersonic && !LumUtils.AnyBosses())
            {
                Player.runAcceleration += 5f * .1f;
                Player.maxRunSpeed += 5f * 2;
                //蛙腿
                if (player.HasEffect<MasoAeolusFrog>())
                {
                    Player.autoJump = true;
                }
                Player.jumpSpeedBoost += 2.4f;
                Player.maxFallSpeed += 5f;
                Player.jumpBoost = true;
            }
            else
            {
                //飞行大师之魂 Or 霜花靴 
                Player.accRunSpeed = player.AddEffect<RunSpeed>(item) ? 15.6f : 6.75f;
            }
            if (player.AddEffect<NoMomentum>(item))
                modPlayer.NoMomentum = true;

            Player.moveSpeed += 0.5f;

            if (player.AddEffect<SupersonicRocketBoots>(item))
            {
                Player.rocketBoots = Player.vanityRocketBoots = ArmorIDs.RocketBoots.TerrasparkBoots;
                Player.rocketTimeMax = 10;
            }
            Player.iceSkate = true;
            //熔岩靴
            Player.waterWalk = true;
            Player.fireWalk = true;
            Player.lavaImmune = true;
            Player.noFallDmg = true;
            //气球束
            if (Player.AddEffect<SupersonicJumps>(item) && Player.wingTime == 0)
            {
                Player.GetJumpState(ExtraJump.CloudInABottle).Enable();
                Player.GetJumpState(ExtraJump.SandstormInABottle).Enable();
                Player.GetJumpState(ExtraJump.BlizzardInABottle).Enable();
                Player.GetJumpState(ExtraJump.FartInAJar).Enable();
            }
            //飞毯
            if (Player.whoAmI == Main.myPlayer && Player.AddEffect<SupersonicCarpet>(item))
            {
                Player.carpet = true;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendData(MessageID.SyncPlayer, number: Player.whoAmI);

                if (Player.canCarpet)
                {
                    modPlayer.extraCarpetDuration = true;
                }
                else if (modPlayer.extraCarpetDuration)
                {
                    modPlayer.extraCarpetDuration = false;
                    Player.carpetTime = 1000;
                }
            }
            //克苏鲁护盾
            if (Player.AddEffect<CthulhuShield>(item))
                Player.dashType = 2;
            //忍者大师装备
            if (Player.AddEffect<SupersonicTabi>(item))
                Player.dashType = 1;
            if (Player.AddEffect<BlackBelt>(item))
                Player.blackBelt = true;
            if (Player.AddEffect<BlackBelt>(item))
                Player.spikedBoots = 2;
            //甜心项链
            if (Player.HasEffect<DefenseBeeEffect>() || Player.AddEffect<DefenseBeeEffect>(item))
            {
                Player.honeyCombItem = item;
            }
            if (Player.AddEffect<SupersonicPanic>(item))
            {
                Player.panic = true;
            }
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<AeolusBoots>())
                    .AddIngredient(ItemID.FlyingCarpet)
                    .AddIngredient(ItemID.SweetheartNecklace)
                    .AddIngredient(ItemID.BalloonHorseshoeHoney)
                    .AddIngredient(ItemID.HorseshoeBundle)
                    .AddIngredient(ItemID.EoCShield)
                    .AddIngredient(ItemID.MasterNinjaGear)
                    .AddIngredient(ItemID.MinecartMech)
                    .AddIngredient(ItemID.BlessedApple)
                    .AddIngredient(ItemID.AncientHorn)
                    .AddIngredient(ItemID.ReindeerBells)
                    .AddIngredient(ItemID.BrainScrambler)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<TracersSeraph>()
                    .AddIngredient<AeolusBoots>()
                    .AddIngredient(ItemID.FlyingCarpet)
                    .AddIngredient(ItemID.SweetheartNecklace)
                    .AddIngredient(ItemID.BalloonHorseshoeHoney)
                    .AddIngredient(ItemID.EoCShield)
                    .AddIngredient(ItemID.MasterNinjaGear)
                    .AddIngredient<MOAB>()
                    .AddIngredient(ItemID.MinecartMech)
                    .AddIngredient<TundraLeash>()
                    .AddIngredient(ItemID.BlessedApple)
                    .AddIngredient(ItemID.AncientHorn)
                    .AddIngredient(ItemID.ReindeerBells)
                    .AddIngredient(ItemID.BrainScrambler)
                    .AddIngredient<FollyFeed>()
                    .AddIngredient<TheCartofGods>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}