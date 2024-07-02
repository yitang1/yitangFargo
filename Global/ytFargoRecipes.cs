using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
using CalamityMod.Items.SummonItems.Invasion;
using FargowiltasSouls.Content.Items;
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
using CalamityMod.Items.Ammo;

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
                ItemType<AerospecHelmet>(), ItemType<AerospecHelm>(),
                ItemType<AerospecHood>(), ItemType<AerospecHat>(),
                ItemType<AerospecHeadgear>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyAerospec", AnyAerospec);
            //斯塔提斯头盔
            RecipeGroup AnyStatigel = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyStatigel"),
                ItemType<StatigelHeadSummon>(), ItemType<StatigelHeadMelee>(),
                ItemType<StatigelHeadRanged>(), ItemType<StatigelHeadMagic>(),
                ItemType<StatigelHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyStatigel", AnyStatigel);
            //渊泉头盔
            RecipeGroup AnyAtaxia = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyAtaxia"),
                ItemType<HydrothermicHeadSummon>(), ItemType<HydrothermicHeadMelee>(),
                ItemType<HydrothermicHeadRanged>(), ItemType<HydrothermicHeadMagic>(),
                ItemType<HydrothermicHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyAtaxia", AnyAtaxia);
            //胜潮头盔
            RecipeGroup AnyVictide = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyVictide"),
                ItemType<VictideHeadSummon>(), ItemType<VictideHeadMelee>(),
                ItemType<VictideHeadRanged>(), ItemType<VictideHeadMagic>(),
                ItemType<VictideHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyVictide", AnyVictide);
            //代达罗斯头盔
            RecipeGroup AnyDaedalus = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyDaedalus"),
                ItemType<DaedalusHeadSummon>(), ItemType<DaedalusHeadMelee>(),
                ItemType<DaedalusHeadRanged>(), ItemType<DaedalusHeadMagic>(),
                ItemType<DaedalusHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyDaedalus", AnyDaedalus);
            //掠夺者头盔
            RecipeGroup AnyReaver = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyReaver"),
                ItemType<ReaverHeadTank>(), ItemType<ReaverHeadMobility>(),
                ItemType<ReaverHeadExplore>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyReaver", AnyReaver);
            //瘟疫头盔
            RecipeGroup AnyPlagueHelmet = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyPlagueHelmet"),
                ItemType<PlaguebringerVisor>(), ItemType<PlagueReaperMask>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyPlagueHelmet", AnyPlagueHelmet);
            //瘟疫胸甲
            RecipeGroup AnyPlagueBreastplate = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyPlagueBreastplate"),
                ItemType<PlaguebringerCarapace>(), ItemType<PlagueReaperVest>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyPlagueBreastplate", AnyPlagueBreastplate);
            //瘟疫长靴
            RecipeGroup AnyPlagueBoot = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyPlagueBoot"),
                ItemType<PlaguebringerPistons>(), ItemType<PlagueReaperStriders>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyPlagueBoot", AnyPlagueBoot);
            //龙蒿头盔
            RecipeGroup AnyTarragon = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyTarragon"),
                ItemType<TarragonHeadSummon>(), ItemType<TarragonHeadMelee>(),
                ItemType<TarragonHeadRanged>(), ItemType<TarragonHeadMagic>(),
                ItemType<TarragonHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyTarragon", AnyTarragon);
            //血炎头盔
            RecipeGroup AnyBloodflare = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyBloodflare"),
                ItemType<BloodflareHeadSummon>(), ItemType<BloodflareHeadMelee>(),
                ItemType<BloodflareHeadRanged>(), ItemType<BloodflareHeadMagic>(),
                ItemType<BloodflareHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyBloodflare", AnyBloodflare);
            //弑神者头盔
            RecipeGroup AnyGodSlayer = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyGodSlayer"),
                ItemType<GodSlayerHeadMelee>(), ItemType<GodSlayerHeadRanged>(),
                ItemType<GodSlayerHeadRogue>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyGodSlayer", AnyGodSlayer);
            //始源林海头盔
            RecipeGroup AnySilva = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnySilva"),
                ItemType<SilvaHeadSummon>(), ItemType<SilvaHeadMagic>());
            RecipeGroup.RegisterGroup("yitangFargo:AnySilva", AnySilva);
            //古圣金源头盔
            RecipeGroup AnyAuric = new RecipeGroup(() =>
                Language.GetTextValue("Mods.yitangFargo.Common.RecipeGroups.AnyAuric"),
                ItemType<AuricTeslaSpaceHelmet>(), ItemType<AuricTeslaRoyalHelm>(),
                ItemType<AuricTeslaHoodedFacemask>(), ItemType<AuricTeslaWireHemmedVisage>(),
                ItemType<AuricTeslaPlumedHelm>());
            RecipeGroup.RegisterGroup("yitangFargo:AnyAuric", AnyAuric);
			#endregion

			#region 其他
			RecipeGroup EvilBossMaterials = new RecipeGroup(() => "任意邪恶Boss材料", ItemID.TissueSample, ItemID.ShadowScale);
			RecipeGroup.RegisterGroup(nameof(ItemID.TissueSample), EvilBossMaterials);
			#endregion
		}

		public override void AddRecipes()
        {
			#region 添加模组物品配方

			#region Fargo突变Mod
			if (ModLoader.HasMod("Fargowiltas"))
			{
				//过载能量
				ModLoader.TryGetMod("Fargowiltas", out Mod fargowiltas);
				Recipe.Create(fargowiltas.Find<ModItem>("Overloader").Type)
					.AddIngredient(ItemID.LunarBar, 5)
					.AddIngredient<GalacticaSingularity>(5)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//世界令牌
				Recipe.Create(fargowiltas.Find<ModItem>("ModeToggle").Type)
					.AddRecipeGroup("Wood", 10)
					.AddIngredient(ItemID.Carrot)
					.Register();

				#region 过载强化剂
				//嗡嗡强化剂(蜂王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerBee").Type)
					.AddIngredient(ItemID.QueenBeeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//天龙座强化剂(双足翼龙)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerBetsy").Type)
					.AddIngredient(ItemID.BossBagBetsy, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//大脑强化剂(克苏鲁之脑)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerBrain").Type)
					.AddIngredient(ItemID.BrainOfCthulhuBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//癫狂强化剂(拜月教邪教徒)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerCultist").Type)
					.AddIngredient(ItemID.FragmentSolar, 50)
					.AddIngredient(ItemID.FragmentVortex, 50)
					.AddIngredient(ItemID.FragmentNebula, 50)
					.AddIngredient(ItemID.FragmentStardust, 50)
					.AddIngredient<MeldBlob>(50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//神秘强化剂(暗黑魔法师)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDarkMage").Type)
					.AddIngredient(ItemID.WarTable, 25)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//巨鹿强化剂(独眼巨鹿)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDeer").Type)
					.AddIngredient(ItemID.DeerclopsBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//毁灭强化剂(毁灭者)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDestroy").Type)
					.AddIngredient(ItemID.DestroyerBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//骸骨强化剂(地牢守卫)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerDG").Type)
					.AddIngredient(ItemID.BoneKey, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//仙灵强化剂(光之女皇)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerEmpress").Type)
					.AddIngredient(ItemID.FairyQueenBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//视觉强化剂(克苏鲁之眼)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerEye").Type)
					.AddIngredient(ItemID.EyeOfCthulhuBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//猪龙鱼强化剂(猪龙鱼公爵)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerFish").Type)
					.AddIngredient(ItemID.FishronBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//丛林蜥蜴强化剂(石巨人)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerGolem").Type)
					.AddIngredient(ItemID.GolemBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//月亮强化剂(月亮领主)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerMoon").Type)
					.AddIngredient(ItemID.MoonLordBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//绿叶强化剂(世纪之花)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerPlant").Type)
					.AddIngredient(ItemID.PlanteraBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//统帅强化剂(机械骷髅王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerPrime").Type)
					.AddIngredient(ItemID.SkeletronPrimeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//结晶强化剂(史莱姆皇后)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerQueenSlime").Type)
					.AddIngredient(ItemID.QueenSlimeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//头骨强化剂(骷髅王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerSkele").Type)
					.AddIngredient(ItemID.SkeletronBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//粘滑强化剂(史莱姆王)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerSlime").Type)
					.AddIngredient(ItemID.KingSlimeBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//双子强化剂(双子魔眼)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerTwins").Type)
					.AddIngredient(ItemID.TwinsBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//血肉强化剂(血肉之墙)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerWall").Type)
					.AddIngredient(ItemID.WallOfFleshBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				//蠕虫强化剂(世界吞噬怪)
				Recipe.Create(fargowiltas.Find<ModItem>("EnergizerWorm").Type)
					.AddIngredient(ItemID.EaterOfWorldsBossBag, 50)
					.AddTile(TileID.LunarCraftingStation)
					.Register();
				#endregion

				#region 召唤所有城镇NPC的物品
				//憎恶
				Recipe.Create(fargowiltas.Find<ModItem>("Abominationn").Type)
					.AddIngredient(ItemID.SpikyBall)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//渔夫
				Recipe.Create(fargowiltas.Find<ModItem>("Angler").Type)
					.AddIngredient(ItemID.Seashell)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//军火商
				Recipe.Create(fargowiltas.Find<ModItem>("ArmsDealer").Type)
					.AddIngredient(ItemID.MusketBall)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//服装商
				Recipe.Create(fargowiltas.Find<ModItem>("Clothier").Type)
					.AddIngredient(ItemID.Bone)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//机器侠
				Recipe.Create(fargowiltas.Find<ModItem>("Cyborg").Type)
					.AddIngredient(ItemID.Ectoplasm)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//爆破专家
				Recipe.Create(fargowiltas.Find<ModItem>("Demolitionist").Type)
					.AddIngredient(ItemID.Bomb)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//戴薇安
				Recipe.Create(fargowiltas.Find<ModItem>("Deviantt").Type)
					.AddIngredient(ItemID.PinkGel)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//树妖
				Recipe.Create(fargowiltas.Find<ModItem>("Dryad").Type)
					.AddIngredient<SulphuricScale>()
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//染料商
				Recipe.Create(fargowiltas.Find<ModItem>("DyeTrader").Type)
					.AddIngredient(ItemID.YellowMarigold)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//哥布林工匠
				Recipe.Create(fargowiltas.Find<ModItem>("GoblinTinkerer").Type)
					.AddIngredient(ItemID.SpikyBall)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//高尔夫球手
				Recipe.Create(fargowiltas.Find<ModItem>("Golfer").Type)
					.AddIngredient(ItemID.DesertFossil)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//向导
				Recipe.Create(fargowiltas.Find<ModItem>("Guide").Type)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//伐木工
				Recipe.Create(fargowiltas.Find<ModItem>("LumberJack").Type)
					.AddRecipeGroup("Wood", 50)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//机械师
				Recipe.Create(fargowiltas.Find<ModItem>("Mechanic").Type)
					.AddIngredient(ItemID.Bone)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//商人
				Recipe.Create(fargowiltas.Find<ModItem>("Merchant").Type)
					.AddIngredient(ItemID.SilverCoin, 25)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//突变体
				Recipe.Create(fargowiltas.Find<ModItem>("Mutant").Type)
					.AddIngredient(ItemID.KingSlimeBossBag)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//护士
				Recipe.Create(fargowiltas.Find<ModItem>("Nurse").Type)
					.AddIngredient(ItemID.LifeCrystal)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//油漆工
				Recipe.Create(fargowiltas.Find<ModItem>("Painter").Type)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//派对女孩
				Recipe.Create(fargowiltas.Find<ModItem>("PartyGirl").Type)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//海盗
				Recipe.Create(fargowiltas.Find<ModItem>("Pirate").Type)
					.AddIngredient(ItemID.PirateMap)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//圣诞老人
				Recipe.Create(fargowiltas.Find<ModItem>("SantaClaus").Type)
					.AddIngredient(ItemID.SnowGlobe)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//骷髅商人
				Recipe.Create(fargowiltas.Find<ModItem>("SkeletonMerchant").Type)
					.AddIngredient<AncientBoneDust>(1)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//高顶礼帽松鼠
				Recipe.Create(fargowiltas.Find<ModItem>("Squirrel").Type)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//蒸汽朋克人
				Recipe.Create(fargowiltas.Find<ModItem>("Steampunker").Type)
					.AddIngredient(ItemID.HallowedBar)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//发型师
				Recipe.Create(fargowiltas.Find<ModItem>("Stylist").Type)
					.AddIngredient(ItemID.Cobweb)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//酒馆老板
				Recipe.Create(fargowiltas.Find<ModItem>("Tavernkeep").Type)
					.AddRecipeGroup(nameof(ItemID.TissueSample))
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//税收官
				Recipe.Create(fargowiltas.Find<ModItem>("TaxCollector").Type)
					.AddIngredient(ItemID.SoulofNight)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//旅商
				Recipe.Create(fargowiltas.Find<ModItem>("TravellingMerchant").Type)
					.AddIngredient(ItemID.GoldCoin, 5)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//松露人
				Recipe.Create(fargowiltas.Find<ModItem>("Truffle").Type)
					.AddIngredient(ItemID.SoulofLight)
					.AddIngredient(ItemID.GlowingMushroom)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//巫医
				Recipe.Create(fargowiltas.Find<ModItem>("WitchDoctor").Type)
					.AddIngredient(ItemID.BeeWax)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//巫师
				Recipe.Create(fargowiltas.Find<ModItem>("Wizard").Type)
					.AddIngredient(ItemID.SoulofLight)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//动物学家
				Recipe.Create(fargowiltas.Find<ModItem>("Zoologist").Type)
					.AddIngredient(ItemID.Bunny)
					.AddIngredient(ItemID.Penguin)
					.AddIngredient(ItemID.Buggy)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//公主
				Recipe.Create(fargowiltas.Find<ModItem>("Princess").Type)
					.AddIngredient(ItemID.Ectoplasm)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//城镇狗狗
				Recipe.Create(fargowiltas.Find<ModItem>("TownDog").Type)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//城镇猫咪
				Recipe.Create(fargowiltas.Find<ModItem>("TownCat").Type)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				//城镇兔兔
				Recipe.Create(fargowiltas.Find<ModItem>("TownBunny").Type)
					.AddIngredient(ItemID.RottenChunk, 5)
					.AddIngredient(ItemID.Vertebrae, 5)
					.AddTile(TileID.DemonAltar)
					.Register();
				#endregion
			}
			#endregion

			#region Fargo魂Mod
			//怒海狂涛(召唤猪鲨仆从)
			Recipe.Create(ItemType<StaffOfUnleashedOcean>())
                .AddIngredient(ItemID.TempestStaff)
                .AddIngredient(ItemType<AbomEnergy>(), 10)
                .AddIngredient(Find<ModItem>("Fargowiltas", "EnergizerFish"))
                .AddTile(Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
            //艳岚谲锋
            Recipe.Create(ItemType<DeviousAestheticus>())
                .AddIngredient(ItemID.EmpressBlade)
                .AddIngredient(ItemID.LunarBar, 20)
                .AddIngredient<GalacticaSingularity>(10)
                .AddIngredient<ExodiumCluster>(10)
                .AddTile(Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
            //浓缩彩虹物质
            Recipe.Create(ItemType<ConcentratedRainbowMatter>())
                .AddIngredient(ItemID.Gel, 30)
                .AddIngredient(ItemID.PinkGel, 20)
                .AddIngredient(ItemID.SoulofLight, 15)
                .AddTile(TileID.CrystalBall)
                .Register();
            //吱吱响的玩具
            Recipe.Create(ItemType<SqueakyToy>())
                .AddRecipeGroup("Ducks")
                .AddIngredient<BloodOrb>(10)
                .AddTile(TileID.DemonAltar)
                .Register();
            //部落挂坠
            Recipe.Create(ItemType<TribalCharm>())
                .AddIngredient(ItemID.TikiTotem)
                .AddIngredient(ItemID.PygmyNecklace)
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddTile(TileID.CrystalBall)
                .Register();
            //普通的胡萝卜
            Recipe.Create(ItemType<OrdinaryCarrot>())
                .AddRecipeGroup("Fruit")
                .AddIngredient(ItemID.NightOwlPotion)
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddTile(TileID.CrystalBall)
                .Register();
            //遗忘之礼
            Recipe.Create(ItemType<MasochistReal>())
                .AddIngredient<Masochist>()
                .Register();
			//突变体的礼物
			Recipe.Create(ItemType<Masochist>())
                .AddIngredient<MasochistReal>()
                .Register();
			//被遗忘的礼物
			Recipe.Create(ItemType<ForgorGift>())
                .AddIngredient<MasochistReal>()
                .AddIngredient<Masochist>()
                .Register();
			//飞龙之羽
			Recipe.Create(ItemType<WyvernFeather>())
				.AddIngredient(ItemID.Feather, 20)
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofFlight, 15)
				.AddTile(TileID.CrystalBall)
				.Register();
			//安全钱包
			Recipe.Create(ItemType<SecurityWallet>())
				.AddIngredient(ItemID.FlyingDutchmanTrophy)
				.AddTile(TileID.Solidifier)
				.Register();
			Recipe.Create(ItemType<SecurityWallet>())
				.AddIngredient(ItemID.MoneyTrough)
				.AddIngredient(ItemID.GoldCoin, 10)
				.AddIngredient<MarksmanRound>(999)
				.AddTile(TileID.CrystalBall)
				.Register();
			//诅咒袋子
			Recipe.Create(ItemType<WretchedPouch>())
				.AddIngredient(ItemID.Silk, 20)
				.AddIngredient<EssenceofHavoc>(3)
				.AddIngredient(ItemID.SoulofNight, 15)
				.AddTile(TileID.CrystalBall)
				.Register();
			//南瓜王的披肩
			Recipe.Create(ItemType<PumpkingsCape>())
				.AddIngredient(ItemID.PumpkingTrophy)
				.AddTile(TileID.Solidifier)
				.Register();
			Recipe.Create(ItemType<PumpkingsCape>())
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Pumpkin, 20)
                .AddIngredient<NightmareFuel>(20)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//冰雪女王的皇冠
			Recipe.Create(ItemType<IceQueensCrown>())
                .AddIngredient(ItemID.IceQueenTrophy)
				.AddTile(TileID.Solidifier)
				.Register();
			Recipe.Create(ItemType<IceQueensCrown>())
                .AddIngredient(ItemID.PlatinumCrown)
                .AddIngredient(ItemID.IceBlock, 20)
                .AddIngredient<EndothermicEnergy>(20)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//飞碟控制台
			Recipe.Create(ItemType<SaucerControlConsole>())
                .AddIngredient(ItemID.MartianSaucerTrophy)
				.AddTile(TileID.Solidifier)
				.Register();
			Recipe.Create(ItemType<SaucerControlConsole>())
                .AddIngredient<MartianDistressRemote>()
                .AddIngredient<ArmoredShell>(3)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//双足翼龙之心
			Recipe.Create(ItemType<BetsysHeart>())
                .AddIngredient(ItemID.BossBagBetsy)
				.AddTile(TileID.Solidifier)
				.Register();
			Recipe.Create(ItemType<BetsysHeart>())
				.AddIngredient(ItemID.Steak)
				.AddIngredient<EffulgentFeather>(10)
				.AddIngredient<DarksunFragment>(20)
				.AddTile(TileID.LunarCraftingStation)
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
                if (recipe.createItem.type == ItemType<EternitySoul>()
                    || recipe.createItem.type == ItemType<UniverseSoul>()
                    || recipe.createItem.type == ItemType<DimensionSoul>()
                    || recipe.createItem.type == ItemType<MasochistSoul>()
                    || recipe.createItem.type == ItemType<TerrariaSoul>()
                    || recipe.createItem.type == ItemType<ColossusSoul>()
                    || recipe.createItem.type == ItemType<SupersonicSoul>()
                    || recipe.createItem.type == ItemType<FlightMasterySoul>()
                    || recipe.createItem.type == ItemType<TrawlerSoul>()
                    || recipe.createItem.type == ItemType<WorldShaperSoul>()
                    || recipe.createItem.type == ItemType<BerserkerSoul>()
                    || recipe.createItem.type == ItemType<SnipersSoul>()
                    || recipe.createItem.type == ItemType<ArchWizardsSoul>()
                    || recipe.createItem.type == ItemType<ConjuristsSoul>()
                    || recipe.createItem.type == ItemType<VagabondsSoul>()
                    || recipe.createItem.type == ItemType<BrandoftheBrimstoneWitch>())
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
                    if (recipe.createItem.type == ItemType<AerospecEnchant>()
                        || recipe.createItem.type == ItemType<StatigelEnchant>()
                        || recipe.createItem.type == ItemType<AtaxiaEnchant>()
                        || recipe.createItem.type == ItemType<XerocEnchant>()
                        || recipe.createItem.type == ItemType<FearmongerEnchant>()

                        || recipe.createItem.type == ItemType<MolluskEnchant>()
                        || recipe.createItem.type == ItemType<VictideEnchant>()
                        || recipe.createItem.type == ItemType<FathomSwarmerEnchant>()
                        || recipe.createItem.type == ItemType<SulphurousEnchant>()
                        || recipe.createItem.type == ItemType<DaedalusEnchant>()
                        || recipe.createItem.type == ItemType<SnowRuffianEnchant>()
                        || recipe.createItem.type == ItemType<UmbraphileEnchant>()
                        || recipe.createItem.type == ItemType<AstralEnchant>()
                        || recipe.createItem.type == ItemType<TitanHeartEnchant>()
                        || recipe.createItem.type == ItemType<OmegaBlueEnchant>()

                        || recipe.createItem.type == ItemType<WulfrumEnchant>()
                        || recipe.createItem.type == ItemType<ReaverEnchant>()
                        || recipe.createItem.type == ItemType<PlagueEnchant>()
                        || recipe.createItem.type == ItemType<DemonShadeEnchant>()

                        || recipe.createItem.type == ItemType<TarragonEnchant>()
                        || recipe.createItem.type == ItemType<BloodflareEnchant>()
                        || recipe.createItem.type == ItemType<BrimflameEnchant>()
                        || recipe.createItem.type == ItemType<GodSlayerEnchant>()
                        || recipe.createItem.type == ItemType<SilvaEnchant>()
                        || recipe.createItem.type == ItemType<AuricEnchant>()

                        || recipe.createItem.type == ItemType<MarniteEnchant>()
                        || recipe.createItem.type == ItemType<DesertProwlerEnchant>()
                        || recipe.createItem.type == ItemType<LunicCorpsEnchant>()
                        || recipe.createItem.type == ItemType<PrismaticEnchant>()
                        || recipe.createItem.type == ItemType<GemTechEnchant>()

                        || recipe.createItem.type == ItemType<AnnihilationForce>()
                        || recipe.createItem.type == ItemType<DesolationForce>()
                        || recipe.createItem.type == ItemType<DevastationForce>()
                        || recipe.createItem.type == ItemType<ExaltationForce>()
                        || recipe.createItem.type == ItemType<MiracleForce>()

                        || recipe.createItem.type == ItemType<CalamitySoul>())
                    {
                        recipe.DisableRecipe();
                    }
                }
                #endregion
            }
        }
    }
}