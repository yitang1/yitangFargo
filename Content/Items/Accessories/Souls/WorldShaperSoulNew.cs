using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Global.Config;
using CalamityMod.Items.Tools;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Mounts;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class WorldShaperSoulNew : BaseSoul
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = Item.buyPrice(0, 75, 0, 0);

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item6;
            Item.useTime = Item.useAnimation = 90;
        }
        public static readonly Color ItemColor = new(255, 239, 2);
        protected override Color? nameColor => ItemColor;

        public override bool? UseItem(Player player) => true;

        public override void UseItemFrame(Player player)
        {
            if (player.itemTime == player.itemTimeMax / 2)
            {
                player.Spawn(PlayerSpawnContext.RecallFromItem);

                for (int d = 0; d < 70; d++)
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
            }
        }

        public override void UpdateInventory(Player player)
        {
            //贝壳电话
            player.accWatch = 3;
            player.accDepthMeter = 1;
            player.accCompass = 1;
            player.accFishFinder = true;
            player.accDreamCatcher = true;
            player.accOreFinder = true;
            player.accStopwatch = true;
            player.accCritterGuide = true;
            player.accJarOfSouls = true;
            player.accThirdEye = true;
            player.accCalendar = true;
            player.accWeatherRadio = true;
            player.chiselSpeed = true;
            player.treasureMagnet = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AddEffects(player, Item, hideVisual);
        }
        public static void AddEffects(Player player, Item item, bool hideVisual)
        {
            Player Player = player;
            player.FargoSouls().WorldShaperSoul = true;
            //矿工魔石
            MinerEnchant.AddEffects(Player, .66f, item);
            //放置速度
            Player.tileSpeed += 0.5f;
            Player.wallSpeed += 0.5f;
            //工具箱
            if (Player.whoAmI == Main.myPlayer)
            {
                Player.tileRangeX += 10;
                Player.tileRangeY += 10;
            }
            //建筑师发明背包 自动上漆
            Player.autoPaint = true;
            //自动安放器
            Player.autoActuator = true;
            //皇家凝胶
            Player.npcTypeNoAggro[1] = true;
            Player.npcTypeNoAggro[16] = true;
            Player.npcTypeNoAggro[59] = true;
            Player.npcTypeNoAggro[71] = true;
            Player.npcTypeNoAggro[81] = true;
            Player.npcTypeNoAggro[138] = true;
            Player.npcTypeNoAggro[121] = true;
            Player.npcTypeNoAggro[122] = true;
            Player.npcTypeNoAggro[141] = true;
            Player.npcTypeNoAggro[147] = true;
            Player.npcTypeNoAggro[183] = true;
            Player.npcTypeNoAggro[184] = true;
            Player.npcTypeNoAggro[204] = true;
            Player.npcTypeNoAggro[225] = true;
            Player.npcTypeNoAggro[244] = true;
            Player.npcTypeNoAggro[302] = true;
            Player.npcTypeNoAggro[333] = true;
            Player.npcTypeNoAggro[335] = true;
            Player.npcTypeNoAggro[334] = true;
            Player.npcTypeNoAggro[336] = true;
            Player.npcTypeNoAggro[537] = true;

            player.AddEffect<BuilderEffect>(item);

            //贝壳电话
            Player.accWatch = 3;
            Player.accDepthMeter = 1;
            Player.accCompass = 1;
            Player.accFishFinder = true;
            Player.accDreamCatcher = true;
            Player.accOreFinder = true;
            Player.accStopwatch = true;
            Player.accCritterGuide = true;
            Player.accJarOfSouls = true;
            Player.accThirdEye = true;
            Player.accCalendar = true;
            Player.accWeatherRadio = true;
            Player.chiselSpeed = true;
            Player.treasureMagnet = true;
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient<MinerEnchant>()
                    .AddIngredient(ItemID.Toolbelt)
                    .AddIngredient(ItemID.Toolbox)
                    .AddIngredient(ItemID.HandOfCreation)
                    .AddIngredient(ItemID.ActuationAccessory)
                    .AddIngredient(ItemID.RoyalGel)
                    .AddRecipeGroup("FargowiltasSouls:AnyShellphone")
                    .AddRecipeGroup("FargowiltasSouls:AnyDrax")
                    .AddIngredient(ItemID.ShroomiteDiggingClaw)
                    .AddIngredient(ItemID.DrillContainmentUnit)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<MinerEnchant>()
                    .AddIngredient(ItemID.HandOfCreation)
                    .AddIngredient(ItemID.ActuationAccessory)
                    .AddIngredient<ArchaicPowder>()
                    .AddIngredient<SpelunkersAmulet>()
                    .AddIngredient(ItemID.RoyalGel)
                    .AddRecipeGroup("FargowiltasSouls:AnyShellphone")
                    .AddIngredient<Grax>()
                    .AddIngredient<BlossomPickaxe>()
                    .AddIngredient<OnyxExcavatorKey>()
                    .AddIngredient(ItemID.DrillContainmentUnit)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}