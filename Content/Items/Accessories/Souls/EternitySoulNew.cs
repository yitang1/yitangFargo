using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using Luminance.Core.Graphics;
using yitangFargo.Content.Items.Calamity.Souls;
using yitangFargo.Content.Items.Fargo;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    [AutoloadEquip(EquipType.Wings)]
    public class EternitySoulNew : FlightMasteryWings
    {
        public override bool HasSupersonicSpeed => true;

        public override bool Eternity => true;
        public override int NumFrames => 10;

        public static int WingSlotID
        {
            get;
            private set;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            WingSlotID = Item.wingSlot;

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 10));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Item.social)
            {
                return;
            }
            const int linesToShow = 5;

            string description = Language.GetTextValue("Mods.yitangFargo.EternitySoulNewExtra.ESCommonTips");

            if (Main.GameUpdateCount % 9 == 0 || EternitySoulSystem.TooltipLines == null)
            {
                EternitySoulSystem.TooltipLines = new();
                for (int i = 0; i < linesToShow; i++)
                {
                    string line = Main.rand.NextFromCollection(EternitySoulSystem.Tooltips);
                    EternitySoulSystem.TooltipLines.Add(line);
                }
            }
            for (int i = 0; i < EternitySoulSystem.TooltipLines.Count; i++)
            {
                description += "\n" + EternitySoulSystem.TooltipLines[i];
            }
            tooltips.Add(new TooltipLine(Mod, "tooltip", description));
            tooltips.Add(new TooltipLine(Mod, "HonorText", Language.GetTextValue("Mods.yitangFargo.EternitySoulNewExtra.Honor")));
        }

        public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
        {
            if ((line.Mod == "Terraria" && line.Name == "ItemName") || line.Name == "HonorText")
            {
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                ManagedShader shader = ShaderManager.GetShader("FargowiltasSouls.Text");
                shader.TrySetParameter("mainColor", new Color(42, 42, 99));
                shader.TrySetParameter("secondaryColor", yitangFargo.EModeColor());
                shader.Apply("PulseUpwards");
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

            Item.rare = ItemRarityID.Red;
            Item.value = Item.buyPrice(20, 0, 0, 0);
            Item.shieldSlot = 5;
            Item.defense = 100;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 180;
            Item.useAnimation = 180;
            Item.UseSound = SoundID.Item6;
        }

        public override void UseItemFrame(Player player) => SandsofTime.Use(player);
        public override bool? UseItem(Player player) => true;

        void PassiveEffect(Player player)
        {
            BionomicCluster.PassiveEffect(player, Item);
            AshWoodEnchant.PassiveEffect(player);

            player.FargoSouls().CanAmmoCycle = true;

            player.FargoSouls().WoodEnchantDiscount = true;

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
        }

        public override void UpdateInventory(Player player) => PassiveEffect(player);
        public override void UpdateVanity(Player player) => PassiveEffect(player);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PassiveEffect(player);

            FargoSoulsPlayer modPlayer = player.FargoSouls();

            modPlayer.Eternity = true;
            player.AddEffect<EternityTin>(Item);

            //寰宇之魂
            modPlayer.UniverseSoul = true;
            modPlayer.UniverseCore = true;
            player.GetDamage(DamageClass.Generic) += 2.5f;
            player.AddEffect<UniverseSpeedEffect>(Item);
            player.maxMinions += 30;
            player.maxTurrets += 20;

            //原版饰品效果
            player.counterWeight = 556 + Main.rand.Next(6);
            player.yoyoGlove = true;
            player.yoyoString = true;

            player.AddEffect<SniperScopeEffect>(Item);
            player.manaFlower = true;
            player.manaMagnet = true;
            player.magicCuffs = true;
            player.manaCost -= 0.5f;

            //维度之魂
            player.statLifeMax2 *= 5;
            player.buffImmune[BuffID.ChaosState] = true;
            ColossusSoulNew.AddEffects(player, Item, 0, 0.4f, 15);
            SupersonicSoulNew.AddEffects(player, Item, hideVisual);
            FlightMasterySoulNew.AddEffects(player, Item);
            TrawlerSoulNew.AddEffects(player, Item, hideVisual);
            WorldShaperSoulNew.AddEffects(player, Item, hideVisual);

            //泰拉之魂
            ModContent.GetInstance<TerrariaSoulNew>().UpdateAccessory(player, hideVisual);
            //大师之魂
            ModContent.GetInstance<MasochistSoulNew>().UpdateAccessory(player, hideVisual);
            //暴君之魂
            ModContent.GetInstance<CalamitySoul>().UpdateAccessory(player, hideVisual);
            //永恒之力
            ModContent.GetInstance<EternityForce>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<UniverseSoulNew>()
                .AddIngredient<DimensionSoulNew>()
                .AddIngredient<TerrariaSoulNew>()
                .AddIngredient<MasochistSoulNew>()
                .AddIngredient<CalamitySoul>()
                .AddIngredient<EternityForce>()
                .AddIngredient<EternalEnergy>(30)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }

        public class EternitySoulSystem : ModSystem
        {
            public static List<string> Tooltips = new();
            public static List<string> TooltipLines = new();
            public override void OnLocalizationsLoaded()
            {
                Tooltips.Clear();
                PostAddRecipes();
            }
            public override void PostAddRecipes()
            {
                string text = Language.GetTextValue("Mods.yitangFargo.EternitySoulNewExtra.AllLines");
                string[] lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                Tooltips.AddRange(lines);
            }
        }
    }
}