using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using CalamityMod.Items.Armor.Aerospec;
using CalamityMod.Items.Armor.Auric;
using CalamityMod.Items.Armor.Bloodflare;
using CalamityMod.Items.Armor.Daedalus;
using CalamityMod.Items.Armor.GodSlayer;
using CalamityMod.Items.Armor.Hydrothermic;
using CalamityMod.Items.Armor.Plaguebringer;
using CalamityMod.Items.Armor.PlagueReaper;
using CalamityMod.Items.Armor.Reaver;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Items.Armor.Statigel;
using CalamityMod.Items.Armor.Tarragon;
using CalamityMod.Items.Armor.Victide;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables.Ores;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Content.Patreon.DemonKing;
using FargowiltasSouls.Content.Patreon.DevAesthetic;
using yitangFargo.Content.Items.Accessories.Souls;
using yitangFargo.Content.Items.Calamity.Souls;
using yitangFargo.Global.Config;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Consumables;

namespace yitangFargo.Global
{
    public class ytFargoRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            #region 灾厄魔石 配方组
            //天蓝头盔
            RecipeGroup AnyAerospec = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyAerospec"),
                ModContent.ItemType<AerospecHelmet>(), ModContent.ItemType<AerospecHelm>(),
                ModContent.ItemType<AerospecHood>(), ModContent.ItemType<AerospecHat>(),
                ModContent.ItemType<AerospecHeadgear>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyAerospec", AnyAerospec);
            //斯塔提斯头盔
            RecipeGroup AnyStatigel = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyStatigel"),
                ModContent.ItemType<StatigelHeadSummon>(), ModContent.ItemType<StatigelHeadMelee>(),
                ModContent.ItemType<StatigelHeadRanged>(), ModContent.ItemType<StatigelHeadMagic>(),
                ModContent.ItemType<StatigelHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyStatigel", AnyStatigel);
            //渊泉头盔
            RecipeGroup AnyAtaxia = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyAtaxia"),
                ModContent.ItemType<HydrothermicHeadSummon>(), ModContent.ItemType<HydrothermicHeadMelee>(),
                ModContent.ItemType<HydrothermicHeadRanged>(), ModContent.ItemType<HydrothermicHeadMagic>(),
                ModContent.ItemType<HydrothermicHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyAtaxia", AnyAtaxia);
            //胜潮头盔
            RecipeGroup AnyVictide = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyVictide"),
                ModContent.ItemType<VictideHeadSummon>(), ModContent.ItemType<VictideHeadMelee>(),
                ModContent.ItemType<VictideHeadRanged>(), ModContent.ItemType<VictideHeadMagic>(),
                ModContent.ItemType<VictideHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyVictide", AnyVictide);
            //代达罗斯头盔
            RecipeGroup AnyDaedalus = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyDaedalus"),
                ModContent.ItemType<DaedalusHeadSummon>(), ModContent.ItemType<DaedalusHeadMelee>(),
                ModContent.ItemType<DaedalusHeadRanged>(), ModContent.ItemType<DaedalusHeadMagic>(),
                ModContent.ItemType<DaedalusHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyDaedalus", AnyDaedalus);
            //掠夺者头盔
            RecipeGroup AnyReaver = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyReaver"),
                ModContent.ItemType<ReaverHeadTank>(), ModContent.ItemType<ReaverHeadMobility>(),
                ModContent.ItemType<ReaverHeadExplore>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyReaver", AnyReaver);
            //瘟疫头盔
            RecipeGroup AnyPlagueHelmet = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyPlagueHelmet"),
                ModContent.ItemType<PlaguebringerVisor>(), ModContent.ItemType<PlagueReaperMask>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyPlagueHelmet", AnyPlagueHelmet);
            //瘟疫胸甲
            RecipeGroup AnyPlagueBreastplate = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyPlagueBreastplate"),
                ModContent.ItemType<PlaguebringerCarapace>(), ModContent.ItemType<PlagueReaperVest>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyPlagueBreastplate", AnyPlagueBreastplate);
            //瘟疫长靴
            RecipeGroup AnyPlagueBoot = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyPlagueBoot"),
                ModContent.ItemType<PlaguebringerPistons>(), ModContent.ItemType<PlagueReaperStriders>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyPlagueBoot", AnyPlagueBoot);
            //龙蒿头盔
            RecipeGroup AnyTarragon = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyTarragon"),
                ModContent.ItemType<TarragonHeadSummon>(), ModContent.ItemType<TarragonHeadMelee>(),
                ModContent.ItemType<TarragonHeadRanged>(), ModContent.ItemType<TarragonHeadMagic>(),
                ModContent.ItemType<TarragonHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyTarragon", AnyTarragon);
            //血炎头盔
            RecipeGroup AnyBloodflare = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyBloodflare"),
                ModContent.ItemType<BloodflareHeadSummon>(), ModContent.ItemType<BloodflareHeadMelee>(),
                ModContent.ItemType<BloodflareHeadRanged>(), ModContent.ItemType<BloodflareHeadMagic>(),
                ModContent.ItemType<BloodflareHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyBloodflare", AnyBloodflare);
            //弑神者头盔
            RecipeGroup AnyGodSlayer = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyGodSlayer"),
                ModContent.ItemType<GodSlayerHeadMelee>(), ModContent.ItemType<GodSlayerHeadRanged>(),
                ModContent.ItemType<GodSlayerHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyGodSlayer", AnyGodSlayer);
            //始源林海头盔
            RecipeGroup AnySilva = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnySilva"),
                ModContent.ItemType<SilvaHeadSummon>(), ModContent.ItemType<SilvaHeadMagic>());
            RecipeGroup.RegisterGroup("yitangFargo:AnySilva", AnySilva);
            //古圣金源头盔
            RecipeGroup AnyAuric = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyAuric"),
                ModContent.ItemType<AuricTeslaSpaceHelmet>(), ModContent.ItemType<AuricTeslaRoyalHelm>(),
                ModContent.ItemType<AuricTeslaHoodedFacemask>(), ModContent.ItemType<AuricTeslaWireHemmedVisage>(),
                ModContent.ItemType<AuricTeslaPlumedHelm>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyAuric", AnyAuric);
            #endregion
        }

        public override void AddRecipes()
        {
            #region 添加模组物品配方
            //怒海狂涛(召唤猪鲨仆从)
            Recipe.Create(ModContent.ItemType<StaffOfUnleashedOcean>(), 1)
                .AddIngredient(ItemID.TempestStaff, 1)
                .AddIngredient(ModContent.ItemType<AbomEnergy>(), 10)
                .AddIngredient(ModContent.Find<ModItem>("Fargowiltas", "EnergizerFish"), 1)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
            //艳岚谲锋
            Recipe.Create(ModContent.ItemType<DeviousAestheticus>(), 1)
                .AddIngredient(ItemID.EmpressBlade, 1)
                .AddIngredient(ItemID.LunarBar, 20)
                .AddIngredient<GalacticaSingularity>(10)
                .AddIngredient<ExodiumCluster>(10)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
            //浓缩彩虹物质
            Recipe.Create(ModContent.ItemType<ConcentratedRainbowMatter>(), 1)
                .AddIngredient(ItemID.Gel, 25)
                .AddIngredient(ItemID.PinkGel, 25)
                .AddIngredient(ItemID.SoulofLight, 15)
                .AddTile(TileID.CrystalBall)
                .Register();
            //吱吱响的玩具
            Recipe.Create(ModContent.ItemType<SqueakyToy>(), 1)
                .AddRecipeGroup("Ducks", 1)
                .AddIngredient<BloodOrb>(10)
                .AddTile(TileID.DemonAltar)
                .Register();
            //部落挂坠
            Recipe.Create(ModContent.ItemType<TribalCharm>(), 1)
                .AddIngredient(ItemID.TikiTotem, 1)
                .AddIngredient(ItemID.PygmyNecklace, 1)
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddTile(TileID.CrystalBall)
                .Register();
            //普通的胡萝卜
            Recipe.Create(ModContent.ItemType<OrdinaryCarrot>(), 1)
                .AddRecipeGroup("Fruit", 1)
                .AddIngredient(ItemID.NightOwlPotion, 1)
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddTile(TileID.CrystalBall)
                .Register();
            #endregion
        }

        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                #region 移除Fargo魂本体的合成配方
                //移除Fargo魂Mod一些魂饰品的合成配方
                if (recipe.createItem.type == ModContent.ItemType<EternitySoul>()
                    || recipe.createItem.type == ModContent.ItemType<UniverseSoul>()
                    || recipe.createItem.type == ModContent.ItemType<DimensionSoul>()
                    || recipe.createItem.type == ModContent.ItemType<MasochistSoul>()
                    || recipe.createItem.type == ModContent.ItemType<TerrariaSoul>()
                    || recipe.createItem.type == ModContent.ItemType<ColossusSoul>()
                    || recipe.createItem.type == ModContent.ItemType<SupersonicSoul>()
                    || recipe.createItem.type == ModContent.ItemType<FlightMasterySoul>()
                    || recipe.createItem.type == ModContent.ItemType<TrawlerSoul>()
                    || recipe.createItem.type == ModContent.ItemType<WorldShaperSoul>()
                    || recipe.createItem.type == ModContent.ItemType<BerserkerSoul>()
                    || recipe.createItem.type == ModContent.ItemType<SnipersSoul>()
                    || recipe.createItem.type == ModContent.ItemType<ArchWizardsSoul>()
                    || recipe.createItem.type == ModContent.ItemType<ConjuristsSoul>()
                    || recipe.createItem.type == ModContent.ItemType<VagabondsSoul>()
                    || recipe.createItem.type == ModContent.ItemType<BrandoftheBrimstoneWitch>())
                {
                    recipe.DisableRecipe();
                }
                #endregion

                #region 配方修改-适配灾法联动

                //只有开启了一个选项才会生效配方修改，如果玩家把两个选项全开启，则默认还是Fargo魂本体的配方
                if (ytFargoConfig.Instance.CalamityFargoRecipe && !ytFargoConfig.Instance.FargoSoulsRecipe)
                {
                    //一级魂的配方添加魔影锭
                    if (recipe.HasResult<UniverseSoulNew>() || recipe.HasResult<DimensionSoulNew>()
                        || recipe.HasResult<TerrariaSoulNew>() || recipe.HasResult<MasochistSoulNew>())
                    {
                        recipe.AddIngredient<ShadowspecBar>(5);
                    }



                }
                #endregion
            }
        }
    }
}
