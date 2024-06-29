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
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Patreon.DemonKing;
using FargowiltasSouls.Content.Patreon.DevAesthetic;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Consumables;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Souls;
using yitangFargo.Global.Config;
using yitangFargo.Content.Items.Accessories.Souls;
using yitangFargo.Content.Items.Calamity.Souls;
using yitangFargo.Content.Items.Calamity.Enchantments;
using yitangFargo.Content.Items.Calamity.Forces;

namespace yitangFargo.Global
{
    public class ytFargoRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            #region 旧版灾厄魔石 配方组
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

			#region Fargo突变Mod
			if (ModLoader.HasMod("Fargowiltas"))
			{
				//过载能量的合成配方
				ModLoader.TryGetMod("Fargowiltas", out Mod fargowiltas);
				Recipe.Create(fargowiltas.Find<ModItem>("Overloader").Type, 1)
					.AddIngredient(ItemID.LunarBar, 5)
					.AddIngredient<GalacticaSingularity>(5)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//世界令牌
				Recipe.Create(fargowiltas.Find<ModItem>("ModeToggle").Type, 1)
					.AddRecipeGroup("Wood", 10)
					.AddIngredient(ItemID.Carrot, 1)
					.Register();

				#region 过载强化剂
				//嗡嗡强化剂(蜂王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerBee").Type, 1)
					.AddIngredient(ItemID.QueenBeeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//天龙座强化剂(双足翼龙)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerBetsy").Type, 1)
					.AddIngredient(ItemID.BossBagBetsy, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//大脑强化剂(克苏鲁之脑)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerBrain").Type, 1)
					.AddIngredient(ItemID.BrainOfCthulhuBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//癫狂强化剂(拜月教邪教徒)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerCultist").Type, 1)
					.AddIngredient(ItemID.LunarCraftingStation, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//神秘强化剂(暗黑魔法师)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDarkMage").Type, 1)
					.AddIngredient(ItemID.WarTable, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//巨鹿强化剂(独眼巨鹿)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDeer").Type, 1)
					.AddIngredient(ItemID.DeerclopsBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//毁灭强化剂(毁灭者)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDestroy").Type, 1)
					.AddIngredient(ItemID.DestroyerBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//骸骨强化剂(地牢守卫)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDG").Type, 1)
					.AddIngredient(ItemID.BoneKey, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//仙灵强化剂(光之女皇)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerEmpress").Type, 1)
					.AddIngredient(ItemID.FairyQueenBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//视觉强化剂(克苏鲁之眼)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerEye").Type, 1)
					.AddIngredient(ItemID.EyeOfCthulhuBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//猪龙鱼强化剂(猪龙鱼公爵)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerFish").Type, 1)
					.AddIngredient(ItemID.FishronBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//丛林蜥蜴强化剂(石巨人)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerGolem").Type, 1)
					.AddIngredient(ItemID.GolemBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//月亮强化剂(月亮领主)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerMoon").Type, 1)
					.AddIngredient(ItemID.MoonLordBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//绿叶强化剂(世纪之花)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerPlant").Type, 1)
					.AddIngredient(ItemID.PlanteraBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//统帅强化剂(机械骷髅王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerPrime").Type, 1)
					.AddIngredient(ItemID.SkeletronPrimeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//结晶强化剂(史莱姆皇后)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerQueenSlime").Type, 1)
					.AddIngredient(ItemID.QueenSlimeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//头骨强化剂(骷髅王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerSkele").Type, 1)
					.AddIngredient(ItemID.SkeletronBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//粘滑强化剂(史莱姆王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerSlime").Type, 1)
					.AddIngredient(ItemID.KingSlimeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//双子强化剂(双子魔眼)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerTwins").Type, 1)
					.AddIngredient(ItemID.TwinsBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//血肉强化剂(血肉之墙)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerWall").Type, 1)
					.AddIngredient(ItemID.WallOfFleshBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//蠕虫强化剂(世界吞噬怪)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerWorm").Type, 1)
					.AddIngredient(ItemID.EaterOfWorldsBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				#endregion

				#region 召唤所有城镇NPC的物品形式
				//憎恶
				Recipe.Create(fargowiltas.Find<ModItem>("Abominationn").Type, 1)
					.AddIngredient(ItemID.GoblinBattleStandard, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//渔夫
				Recipe.Create(fargowiltas.Find<ModItem>("Angler").Type, 1)
					.AddIngredient(ItemID.Seashell, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//军火商
				Recipe.Create(fargowiltas.Find<ModItem>("ArmsDealer").Type, 1)
					.AddIngredient(ItemID.MusketBall, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//服装商
				Recipe.Create(fargowiltas.Find<ModItem>("Clothier").Type, 1)
					.AddIngredient(ItemID.Bone, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//机器侠
				Recipe.Create(fargowiltas.Find<ModItem>("Cyborg").Type, 1)
					.AddIngredient(fargowiltas.Find<ModItem>("PlanterasFruit").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//爆破专家
				Recipe.Create(fargowiltas.Find<ModItem>("Demolitionist").Type, 1)
					.AddIngredient(ItemID.Bomb, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//戴薇安
				Recipe.Create(fargowiltas.Find<ModItem>("Deviantt").Type, 1)
					.AddIngredient(ItemID.PinkGel, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//树妖
				Recipe.Create(fargowiltas.Find<ModItem>("Dryad").Type, 1)
					.AddIngredient(fargowiltas.Find<ModItem>("SuspiciousEye").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//染料商
				Recipe.Create(fargowiltas.Find<ModItem>("DyeTrader").Type, 1)
					.AddIngredient(ItemID.BlackLens, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//哥布林工匠
				Recipe.Create(fargowiltas.Find<ModItem>("GoblinTinkerer").Type, 1)
					.AddIngredient(ItemID.GoblinBattleStandard, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//高尔夫球手
				Recipe.Create(fargowiltas.Find<ModItem>("Golfer").Type, 1)
					.AddIngredient(ItemID.DesertFossil, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//向导
				Recipe.Create(fargowiltas.Find<ModItem>("Guide").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//伐木工
				Recipe.Create(fargowiltas.Find<ModItem>("LumberJack").Type, 1)
					.AddRecipeGroup("Wood", 50)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//机械师
				Recipe.Create(fargowiltas.Find<ModItem>("Mechanic").Type, 1)
					.AddIngredient(ItemID.Bone, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//商人
				Recipe.Create(fargowiltas.Find<ModItem>("Merchant").Type, 1)
					.AddIngredient(ItemID.SilverCoin, 10)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//突变体
				Recipe.Create(fargowiltas.Find<ModItem>("Mutant").Type, 1)
					.AddIngredient(fargowiltas.Find<ModItem>("SlimyCrown").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//护士
				Recipe.Create(fargowiltas.Find<ModItem>("Nurse").Type, 1)
					.AddIngredient(ItemID.LifeCrystal, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//油漆工
				Recipe.Create(fargowiltas.Find<ModItem>("Painter").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//派对女孩
				Recipe.Create(fargowiltas.Find<ModItem>("PartyGirl").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//海盗
				Recipe.Create(fargowiltas.Find<ModItem>("Pirate").Type, 1)
					.AddIngredient(ItemID.PirateMap, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//圣诞老人
				Recipe.Create(fargowiltas.Find<ModItem>("SantaClaus").Type, 1)
					.AddIngredient(ItemID.SnowGlobe, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//骷髅商人
				Recipe.Create(fargowiltas.Find<ModItem>("SkeletonMerchant").Type, 1)
					.AddIngredient<AncientBoneDust>(1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//高顶礼帽松鼠
				Recipe.Create(fargowiltas.Find<ModItem>("Squirrel").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//蒸汽朋克人
				Recipe.Create(fargowiltas.Find<ModItem>("Steampunker").Type, 1)
					.AddIngredient(ItemID.HallowedBar, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//发型师
				Recipe.Create(fargowiltas.Find<ModItem>("Stylist").Type, 1)
					.AddIngredient(ItemID.Cobweb, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//酒馆老板
				Recipe.Create(fargowiltas.Find<ModItem>("Tavernkeep").Type, 1)
					.AddRecipeGroup(nameof(ItemID.TissueSample), 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//税收官
				Recipe.Create(fargowiltas.Find<ModItem>("TaxCollector").Type, 1)
					.AddIngredient(ItemID.SoulofNight, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//旅商
				Recipe.Create(fargowiltas.Find<ModItem>("TravellingMerchant").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//松露人
				Recipe.Create(fargowiltas.Find<ModItem>("Truffle").Type, 1)
					.AddIngredient(ItemID.SoulofLight, 1)
					.AddIngredient(ItemID.GlowingMushroom, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//巫医
				Recipe.Create(fargowiltas.Find<ModItem>("WitchDoctor").Type, 1)
					.AddIngredient(ItemID.BeeWax, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//巫师
				Recipe.Create(fargowiltas.Find<ModItem>("Wizard").Type, 1)
					.AddIngredient(ItemID.SoulofLight, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//动物学家
				Recipe.Create(fargowiltas.Find<ModItem>("Zoologist").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//公主
				Recipe.Create(fargowiltas.Find<ModItem>("Princess").Type, 1)
					.AddIngredient(fargowiltas.Find<ModItem>("PlanterasFruit").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//城镇狗狗
				Recipe.Create(fargowiltas.Find<ModItem>("TownDog").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//城镇猫咪
				Recipe.Create(fargowiltas.Find<ModItem>("TownCat").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//城镇兔兔
				Recipe.Create(fargowiltas.Find<ModItem>("TownBunny").Type, 1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				#endregion
			}
			#endregion

			#region Fargo魂Mod
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

                #region 配方修改-适配灾法双开
                if (ytFargoConfig.Instance.CalamityFargoRecipe)
                {
                    //一级魂的配方添加魔影锭
                    if (recipe.HasResult<UniverseSoulNew>() || recipe.HasResult<DimensionSoulNew>()
                        || recipe.HasResult<TerrariaSoulNew>() || recipe.HasResult<MasochistSoulNew>())
                    {
                        recipe.AddIngredient<ShadowspecBar>(5);
                    }
                }
                #endregion

                #region 添加旧版灾厄魔石
                if (!ytFargoConfig.Instance.OldCalamityEnchant)
                {
                    //如果没有开启这个选项，那么旧版灾厄魔石的相关合成配方都会被禁用掉。(不至于直接移除物品)
                    if (recipe.createItem.type == ModContent.ItemType<AerospecEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<StatigelEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<AtaxiaEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<XerocEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<FearmongerEnchant>()

                        || recipe.createItem.type == ModContent.ItemType<MolluskEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<VictideEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<FathomSwarmerEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<SulphurousEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<DaedalusEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<SnowRuffianEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<UmbraphileEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<AstralEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<TitanHeartEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<OmegaBlueEnchant>()

                        || recipe.createItem.type == ModContent.ItemType<WulfrumEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<ReaverEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<PlagueEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<DemonShadeEnchant>()

                        || recipe.createItem.type == ModContent.ItemType<TarragonEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<BloodflareEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<BrimflameEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<GodSlayerEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<SilvaEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<AuricEnchant>()

                        || recipe.createItem.type == ModContent.ItemType<MarniteEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<DesertProwlerEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<LunicCorpsEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<PrismaticEnchant>()
                        || recipe.createItem.type == ModContent.ItemType<GemTechEnchant>()

                        || recipe.createItem.type == ModContent.ItemType<AnnihilationForce>()
                        || recipe.createItem.type == ModContent.ItemType<DesolationForce>()
                        || recipe.createItem.type == ModContent.ItemType<DevastationForce>()
                        || recipe.createItem.type == ModContent.ItemType<ExaltationForce>()
                        || recipe.createItem.type == ModContent.ItemType<MiracleForce>()

                        || recipe.createItem.type == ModContent.ItemType<CalamitySoul>())
                    {
                        recipe.DisableRecipe();
                    }
                }
                #endregion
            }
        }
    }
}