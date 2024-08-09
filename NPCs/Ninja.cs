using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using CalamityMod;
using FargowiltasSouls.Core.Systems;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Content.Items.BossBags;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Essences;
using FargoDLC = FargowiltasCrossmod.Content.Calamity.Items.Accessories.Enchantments;
using yitangFargo.Global.Config;
using yitangFargo.Content.Items.Calamity.Enchantments;
using yitangFargo.Content.Items.Calamity.Souls;
using static yitangFargo.yitangFargo;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Souls;
using yitangFargo.Content.Items.LOM;
using System;

namespace yitangFargo.NPCs
{
    [AutoloadHead]
    public class Ninja : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 300;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 20;
            NPCID.Sets.AttackAverageChance[Type] = 10;
            NPCID.Sets.HatOffsetY[Type] = 0;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            NPC.Happiness
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Like)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Love)
                .SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Like)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
            bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("一个神秘的忍者，从史莱姆王的身体里被救出来。尽管他不愿谈论此事，但他很乐意提供各种实用的装备和技术。"));
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
        }

        //public override bool CanTownNPCSpawn(int numTownNPCs)
        //{
        //    return NPC.downedSlimeKing;
        //}

        public override List<string> SetNPCNameList()
        {
            return new List<string> { "Sam", "Raiden", "Dale" };
        }

        public override string GetChat()
        {
            if (Main.bloodMoon)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return "除非你有足够的勇气把今晚当作练习的机会，否则现在我不建议你到屋子外面……";
                }
            }
            if (Main.raining && !Main.IsItStorming)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return "啊，是的，雨声听起来很舒缓。更好的是，它还可以掩盖你的脚步声。";
                }
            }
            if (BirthdayParty.PartyIsUp)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return "我们忍者更喜欢生活在阴影和寂静中，但偶尔来点喧嚣和欢乐放松一下也是不错的。";
                }
            }
            if (NPC.downedQueenSlime)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return "什么，你是说还有第二只皇家史莱姆？嗯……我很高兴现在两者都被打败了，干得好！朋友。";
                }
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return "泰拉人，感谢你为我的自由所做的一切。";
                case 1:
                    return "啊，欢迎。请让我用我的商品来回报你的英勇。";
                case 2:
                    return "为什么每个人都问我是否卖拉面？我为什么会卖拉面……难不成他们见过喜欢吃拉面的忍者？";
                case 3:
                    return "呃，我的衣服上貌似还有史莱姆粘液的残留物……";
                case 4:
                    return "你知道有些人认为远程武器和投掷武器是一样的吗？这……这很荒谬。";
                case 5:
                    return "你有没有听说过“稽古衣”，它又被称为“剑道衣”，真想穿一穿看看是什么感觉呢。";
                case 6:
                    return "我在世界各处的角落里找到了一些灰白色的魔石，或许你可以试试能用它们做些什么东西？";
                default:
                    return "你有没有听说过一位传奇忍者的名字——斯塔提斯，说实话，我只在他人讲述的古老传说中听到过。";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "原版魂石";
            button2 = "模组魂石";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "VanillaES";
            }
            else
            {
                shop = "ModsES";
            }

        }

        public override void AddShops()
        {
            var vanillaES = new NPCShop(Type, "VanillaES");
            var modsES = new NPCShop(Type, "ModsES");

            #region Condition条件

            #region 灾厄Mod的Boss击败条件
            Condition DownedDesertScourge = new Condition("DesertScourge", () => DownedBossSystem.downedDesertScourge);
            Condition DownedCrabulon = new Condition("Crabulon", () => DownedBossSystem.downedCrabulon);
            Condition DownedPerfs = new Condition("Perfs", () => DownedBossSystem.downedPerforator);
            Condition DownedHiveMind = new Condition("HiveMind", () => DownedBossSystem.downedHiveMind);
            Condition DownedPerfsHiveMind = new Condition("PerfsHiveMind", () => DownedBossSystem.downedPerforator || DownedBossSystem.downedHiveMind);
            Condition DownedSlimeGod = new Condition("SlimeGod", () => DownedBossSystem.downedSlimeGod);

            Condition DownedCryogen = new Condition("Cryogen", () => DownedBossSystem.downedCryogen);
            Condition DownedAquaticScourge = new Condition("AquaticScourge", () => DownedBossSystem.downedAquaticScourge);
            Condition DownedBrimstoneElemental = new Condition("BrimstoneElemental", () => DownedBossSystem.downedBrimstoneElemental);
            Condition DownedCloneCalamitas = new Condition("CalClone", () => DownedBossSystem.downedCalamitasClone);
            Condition DownedPlanteraCalClone = new Condition("PlanteraCalClone", () => DownedBossSystem.downedCalamitasClone || NPC.downedPlantBoss);
            Condition DownedLeviathan = new Condition("Leviathan", () => DownedBossSystem.downedLeviathan);
            Condition DownedAureus = new Condition("Aureus", () => DownedBossSystem.downedAstrumAureus);
            Condition DownedPlague = new Condition("Plague", () => DownedBossSystem.downedPlaguebringer);
            Condition DownedRavager = new Condition("Ravager", () => DownedBossSystem.downedRavager);
            Condition DownedDeus = new Condition("Deus", () => DownedBossSystem.downedAstrumDeus);

            Condition DownedDragonfolly = new Condition("Dragonfolly", () => DownedBossSystem.downedDragonfolly);
            Condition DownedGuardians = new Condition("Guardians", () => DownedBossSystem.downedGuardians);
            Condition DownedProvidence = new Condition("Providence", () => DownedBossSystem.downedProvidence);
            Condition DownedPolterghast = new Condition("Polterghast", () => DownedBossSystem.downedPolterghast);
            Condition DownedOldDuke = new Condition("OldDuke", () => DownedBossSystem.downedBoomerDuke);
            Condition DownedStormWeaver = new Condition("StormWeaver", () => DownedBossSystem.downedStormWeaver);
            Condition DownedCeaselessVoid = new Condition("CeaselessVoid", () => DownedBossSystem.downedCeaselessVoid);
            Condition DownedSignus = new Condition("Signus", () => DownedBossSystem.downedSignus);
            Condition DownedTheThree = new Condition("Three", () => DownedBossSystem.downedStormWeaver && DownedBossSystem.downedCeaselessVoid && DownedBossSystem.downedSignus);
            Condition DownedDevourerOfGods = new Condition("DoG", () => DownedBossSystem.downedDoG);
            Condition DownedYharon = new Condition("Yharon", () => DownedBossSystem.downedYharon);
            Condition DownedExoMechs = new Condition("ExoMechs", () => DownedBossSystem.downedExoMechs);
            Condition DownedSuperCalamitas = new Condition("SCal", () => DownedBossSystem.downedCalamitas);
            Condition DownedExoOrCal = new Condition("ExoOrCal", () => DownedBossSystem.downedExoMechs || DownedBossSystem.downedCalamitas);
            Condition DownedExoAndCal = new Condition("ExoAndCal", () => DownedBossSystem.downedExoMechs && DownedBossSystem.downedCalamitas);
            #endregion

            #region Fargo的Boss击败条件
            Condition DownedDeviantt = new Condition("DownedDeviantt", () => WorldSavingSystem.DownedDevi);
            Condition DownedAbom = new Condition("DownedAbom", () => WorldSavingSystem.DownedAbom);
            Condition DownedMutant = new Condition("DownedMutant", () => WorldSavingSystem.DownedMutant);
            Condition DownedTimberChampion = new Condition("DownedTimber", () => WorldSavingSystem.DownedBoss[0]);
            Condition DownedTerraChampion = new Condition("DownedTerra", () => WorldSavingSystem.DownedBoss[1]);
            Condition DownedEarthChampion = new Condition("DownedEarth", () => WorldSavingSystem.DownedBoss[2]);
            Condition DownedNatureChampion = new Condition("DownedNature", () => WorldSavingSystem.DownedBoss[3]);
            Condition DownedLifeChampion = new Condition("DownedLife", () => WorldSavingSystem.DownedBoss[4]);
            Condition DownedShadowChampion = new Condition("DownedShadow", () => WorldSavingSystem.DownedBoss[5]);
            Condition DownedSpiritChampion = new Condition("DownedSpirit", () => WorldSavingSystem.DownedBoss[6]);
            Condition DownedWillChampion = new Condition("DownedWill", () => WorldSavingSystem.DownedBoss[7]);
            Condition DownedCosmosChampion = new Condition("DownedCosmos", () => WorldSavingSystem.DownedBoss[8]);
            Condition DownedTrojanSquirrel = new Condition("DownedTrojanSquirrel", () => WorldSavingSystem.DownedBoss[9]);
            Condition DownedLifelight = new Condition("DownedLifelight", () => WorldSavingSystem.DownedBoss[10]);
            Condition DownedCursedCoffin = new Condition("DownedCursedCoffin", () => WorldSavingSystem.DownedBoss[11]);
            Condition DownedBanishedBaron = new Condition("DownedBanishedBaron", () => WorldSavingSystem.DownedBoss[12]);
            Condition DownedMagmaw = new Condition("DownedMagmaw", () => WorldSavingSystem.DownedBoss[13]);
            #endregion

            Condition HasClassEssences = new Condition("HasClassEssences", () =>
            Main.LocalPlayer.HasItem(ItemType<BarbariansEssence>())
            || Main.LocalPlayer.HasItem(ItemType<SharpshootersEssence>())
            || Main.LocalPlayer.HasItem(ItemType<ApprenticesEssence>())
            || Main.LocalPlayer.HasItem(ItemType<OccultistsEssence>())
            || Main.LocalPlayer.HasItem(ItemType<OutlawsEssence>())
            || Main.LocalPlayer.HasItem(ItemType<UniverseSoul>()));

            #region 开启【配方修改-适配灾法双开】选项后
            //已击败丛林龙，且物品栏内有任意一个寰宇之魂下级
            Condition HasClassSoulsCalamity = new Condition("HasClassSoulsCalamity", () =>
            DownedBossSystem.downedYharon && (Main.LocalPlayer.HasItem(ItemType<BerserkerSoul>())
            || Main.LocalPlayer.HasItem(ItemType<SnipersSoul>())
            || Main.LocalPlayer.HasItem(ItemType<ArchWizardsSoul>())
            || Main.LocalPlayer.HasItem(ItemType<ConjuristsSoul>())
            || Main.LocalPlayer.HasItem(ItemType<VagabondsSoul>())
            || Main.LocalPlayer.HasItem(ItemType<UniverseSoul>())));

            //已击败丛林龙，且物品栏内有任意一个维度之魂下级
            Condition HasDimeSoulsCalamity = new Condition("HasDimeSoulsCalamity", () =>
            DownedBossSystem.downedYharon && (Main.LocalPlayer.HasItem(ItemType<ColossusSoul>())
            || Main.LocalPlayer.HasItem(ItemType<SupersonicSoul>())
            || Main.LocalPlayer.HasItem(ItemType<FlightMasterySoul>())
            || Main.LocalPlayer.HasItem(ItemType<TrawlerSoul>())
            || Main.LocalPlayer.HasItem(ItemType<WorldShaperSoul>())
            || Main.LocalPlayer.HasItem(ItemType<DimensionSoul>())));
            #endregion

            #region 开启【配方修改-Fargo魂本体】选项后
            //月后，且物品栏内有任意一个寰宇之魂下级 (不包括盗贼魂)
            Condition HasClassSoulsFargo = new Condition("HasClassSoulsFargo", () =>
            Main.LocalPlayer.HasItem(ItemType<BerserkerSoul>())
            || Main.LocalPlayer.HasItem(ItemType<SnipersSoul>())
            || Main.LocalPlayer.HasItem(ItemType<ArchWizardsSoul>())
            || Main.LocalPlayer.HasItem(ItemType<ConjuristsSoul>())
            || Main.LocalPlayer.HasItem(ItemType<UniverseSoul>()));

            //月后，且物品栏内有任意一个维度之魂下级
            Condition HasDimeSoulsFargo = new Condition("HasDimeSoulsFargo", () =>
            Main.LocalPlayer.HasItem(ItemType<ColossusSoul>())
            || Main.LocalPlayer.HasItem(ItemType<SupersonicSoul>())
            || Main.LocalPlayer.HasItem(ItemType<FlightMasterySoul>())
            || Main.LocalPlayer.HasItem(ItemType<TrawlerSoul>())
            || Main.LocalPlayer.HasItem(ItemType<WorldShaperSoul>())
            || Main.LocalPlayer.HasItem(ItemType<DimensionSoul>()));
            #endregion

            Condition HasMasochistSoul = new Condition("HasMasochistSoul", () =>
            Main.LocalPlayer.HasItem(ItemType<MasochistSoul>()));

            Condition HasEternitySoul = new Condition("HasEternitySoul", () =>
            Main.LocalPlayer.HasItem(ItemType<EternitySoul>()));

            #endregion

            #region 魂相关饰品
            vanillaES.Add(CustomPrice(ItemType<BarbariansEssence>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { HasClassEssences })
                .Add(CustomPrice(ItemType<SharpshootersEssence>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { HasClassEssences })
                .Add(CustomPrice(ItemType<ApprenticesEssence>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { HasClassEssences })
                .Add(CustomPrice(ItemType<OccultistsEssence>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { HasClassEssences })
                .Add(CustomPrice(ItemType<OutlawsEssence>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { HasClassEssences });

            #region 寰宇之魂下级
            //if (ytFargoConfig.Instance.CalamityFargoRecipe)
            //{
            vanillaES.Add(CustomPrice(ItemType<BerserkerSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasClassSoulsCalamity })
                .Add(CustomPrice(ItemType<SnipersSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasClassSoulsCalamity })
                .Add(CustomPrice(ItemType<ArchWizardsSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasClassSoulsCalamity })
                .Add(CustomPrice(ItemType<ConjuristsSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasClassSoulsCalamity })
                .Add(CustomPrice(ItemType<VagabondsSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasClassSoulsCalamity });
            //}
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                vanillaES.Add(CustomPrice(ItemType<BerserkerSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasClassSoulsFargo })
                    .Add(CustomPrice(ItemType<SnipersSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasClassSoulsFargo })
                    .Add(CustomPrice(ItemType<ArchWizardsSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasClassSoulsFargo })
                    .Add(CustomPrice(ItemType<ConjuristsSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasClassSoulsFargo })
                    .Add(CustomPrice(ItemType<VagabondsSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasClassSoulsCalamity });
            }
            #endregion

            #region 维度之魂下级
            //if (ytFargoConfig.Instance.CalamityFargoRecipe)
            //{
            vanillaES.Add(CustomPrice(ItemType<ColossusSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasDimeSoulsCalamity })
                .Add(CustomPrice(ItemType<SupersonicSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasDimeSoulsCalamity })
                .Add(CustomPrice(ItemType<FlightMasterySoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasDimeSoulsCalamity })
                .Add(CustomPrice(ItemType<TrawlerSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasDimeSoulsCalamity })
                .Add(CustomPrice(ItemType<WorldShaperSoul>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasDimeSoulsCalamity });
            //}
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                vanillaES.Add(CustomPrice(ItemType<ColossusSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasDimeSoulsFargo })
                    .Add(CustomPrice(ItemType<SupersonicSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasDimeSoulsFargo })
                    .Add(CustomPrice(ItemType<FlightMasterySoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasDimeSoulsFargo })
                    .Add(CustomPrice(ItemType<TrawlerSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasDimeSoulsFargo })
                    .Add(CustomPrice(ItemType<WorldShaperSoul>(), Item.buyPrice(0, 65, 0, 0)), new Condition[] { HasDimeSoulsFargo });
            }
			#endregion

			#region 大师之魂下级
			vanillaES.Add(CustomPrice(ItemType<SinisterIcon>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul })
				.Add(CustomPrice(ItemType<SupremeDeathbringerFairy>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul })
				.Add(CustomPrice(ItemType<BionomicCluster>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul })
				.Add(CustomPrice(ItemType<DubiousCircuitry>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul })
				.Add(CustomPrice(ItemType<PureHeart>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul })
				.Add(CustomPrice(ItemType<LumpOfFlesh>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul })
				.Add(CustomPrice(ItemType<ChaliceoftheMoon>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul })
				.Add(CustomPrice(ItemType<HeartoftheMasochist>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { HasMasochistSoul });
			#endregion

			vanillaES.Add(CustomPrice(ItemType<UniverseSoul>(), Item.buyPrice(5, 0, 0, 0)), new Condition[] { HasEternitySoul })
				.Add(CustomPrice(ItemType<DimensionSoul>(), Item.buyPrice(5, 0, 0, 0)), new Condition[] { HasEternitySoul })
				.Add(CustomPrice(ItemType<TerrariaSoul>(), Item.buyPrice(5, 0, 0, 0)), new Condition[] { HasEternitySoul })
				.Add(CustomPrice(ItemType<MasochistSoul>(), Item.buyPrice(5, 0, 0, 0)), new Condition[] { HasEternitySoul })
				.Add(CustomPrice(ItemType<CalamitySoul>(), Item.buyPrice(5, 0, 0, 0)), new Condition[] { HasEternitySoul });

            #endregion

            #region 原版魂石
            //森林之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<WoodEnchant>(), Item.buyPrice(0, 1, 0, 0)), new Condition[] { DownedTimberChampion });
            vanillaES.Add(CustomPrice(ItemType<BorealWoodEnchant>(), Item.buyPrice(0, 1, 0, 0)), new Condition[] { DownedTimberChampion });
            vanillaES.Add(CustomPrice(ItemType<RichMahoganyEnchant>(), Item.buyPrice(0, 1, 0, 0)), new Condition[] { DownedTimberChampion });
            vanillaES.Add(CustomPrice(ItemType<EbonwoodEnchant>(), Item.buyPrice(0, 1, 0, 0)), new Condition[] { DownedTimberChampion });
            vanillaES.Add(CustomPrice(ItemType<ShadewoodEnchant>(), Item.buyPrice(0, 1, 0, 0)), new Condition[] { DownedTimberChampion });
            vanillaES.Add(CustomPrice(ItemType<PalmWoodEnchant>(), Item.buyPrice(0, 1, 0, 0)), new Condition[] { DownedTimberChampion });
            vanillaES.Add(CustomPrice(ItemType<PearlwoodEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedTimberChampion });
            //泰拉之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<CopperEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            vanillaES.Add(CustomPrice(ItemType<TinEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            vanillaES.Add(CustomPrice(ItemType<IronEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            vanillaES.Add(CustomPrice(ItemType<LeadEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            vanillaES.Add(CustomPrice(ItemType<SilverEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            vanillaES.Add(CustomPrice(ItemType<TungstenEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            vanillaES.Add(CustomPrice(ItemType<AshWoodEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            vanillaES.Add(CustomPrice(ItemType<ObsidianEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedTerraChampion });
            //大地之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<AncientCobaltEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedEarthChampion });
            vanillaES.Add(CustomPrice(ItemType<CobaltEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedEarthChampion });
            vanillaES.Add(CustomPrice(ItemType<PalladiumEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedEarthChampion });
            vanillaES.Add(CustomPrice(ItemType<MythrilEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedEarthChampion });
            vanillaES.Add(CustomPrice(ItemType<OrichalcumEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedEarthChampion });
            vanillaES.Add(CustomPrice(ItemType<AdamantiteEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedEarthChampion });
            vanillaES.Add(CustomPrice(ItemType<TitaniumEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedEarthChampion });
            //自然之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<CrimsonEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedNatureChampion });
            vanillaES.Add(CustomPrice(ItemType<MoltenEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedNatureChampion });
            vanillaES.Add(CustomPrice(ItemType<RainEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedNatureChampion });
            vanillaES.Add(CustomPrice(ItemType<SnowEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedNatureChampion });
            vanillaES.Add(CustomPrice(ItemType<FrostEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedNatureChampion });
            vanillaES.Add(CustomPrice(ItemType<JungleEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedNatureChampion });
            vanillaES.Add(CustomPrice(ItemType<ChlorophyteEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedNatureChampion });
            vanillaES.Add(CustomPrice(ItemType<ShroomiteEnchant>(), Item.buyPrice(0, 10, 0, 0)), new Condition[] { DownedNatureChampion });
            //生命之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<PumpkinEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedLifeChampion });
            vanillaES.Add(CustomPrice(ItemType<BeeEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedLifeChampion });
            vanillaES.Add(CustomPrice(ItemType<SpiderEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedLifeChampion });
            vanillaES.Add(CustomPrice(ItemType<CactusEnchant>(), Item.buyPrice(0, 1, 0, 0)), new Condition[] { DownedLifeChampion });
            vanillaES.Add(CustomPrice(ItemType<TurtleEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedLifeChampion });
            vanillaES.Add(CustomPrice(ItemType<BeetleEnchant>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { DownedLifeChampion });
            //心灵之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<FossilEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedSpiritChampion });
            vanillaES.Add(CustomPrice(ItemType<ForbiddenEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedSpiritChampion });
            vanillaES.Add(CustomPrice(ItemType<HallowEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedSpiritChampion });
            vanillaES.Add(CustomPrice(ItemType<AncientHallowEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedSpiritChampion });
            vanillaES.Add(CustomPrice(ItemType<TikiEnchant>(), Item.buyPrice(0, 10, 0, 0)), new Condition[] { DownedSpiritChampion });
            vanillaES.Add(CustomPrice(ItemType<SpectreEnchant>(), Item.buyPrice(0, 10, 0, 0)), new Condition[] { DownedSpiritChampion });
            //暗影之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<ShadowEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<AncientShadowEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<NinjaEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<CrystalAssassinEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<SpookyEnchant>(), Item.buyPrice(0, 10, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<MonkEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<ShinobiEnchant>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<ApprenticeEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<DarkArtistEnchant>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { DownedShadowChampion });
            vanillaES.Add(CustomPrice(ItemType<NecroEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedShadowChampion });
            //意志之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<GoldEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedWillChampion });
            vanillaES.Add(CustomPrice(ItemType<PlatinumEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedWillChampion });
            vanillaES.Add(CustomPrice(ItemType<GladiatorEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedWillChampion });
            vanillaES.Add(CustomPrice(ItemType<HuntressEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedWillChampion });
            vanillaES.Add(CustomPrice(ItemType<RedRidingEnchant>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { DownedWillChampion });
            vanillaES.Add(CustomPrice(ItemType<SquireEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedWillChampion });
            vanillaES.Add(CustomPrice(ItemType<ValhallaKnightEnchant>(), Item.buyPrice(0, 15, 0, 0)), new Condition[] { DownedWillChampion });
            //宇宙之力的魔石↓
            vanillaES.Add(CustomPrice(ItemType<MeteorEnchant>(), Item.buyPrice(0, 3, 0, 0)), new Condition[] { DownedCosmosChampion });
            vanillaES.Add(CustomPrice(ItemType<WizardEnchant>(), Item.buyPrice(0, 5, 0, 0)), new Condition[] { DownedCosmosChampion });
            vanillaES.Add(CustomPrice(ItemType<SolarEnchant>(), Item.buyPrice(0, 30, 0, 0)), new Condition[] { DownedCosmosChampion });
            vanillaES.Add(CustomPrice(ItemType<VortexEnchant>(), Item.buyPrice(0, 30, 0, 0)), new Condition[] { DownedCosmosChampion });
            vanillaES.Add(CustomPrice(ItemType<NebulaEnchant>(), Item.buyPrice(0, 30, 0, 0)), new Condition[] { DownedCosmosChampion });
            vanillaES.Add(CustomPrice(ItemType<StardustEnchant>(), Item.buyPrice(0, 30, 0, 0)), new Condition[] { DownedCosmosChampion });

			#endregion

			#region 模组魂石
			//宝藏袋
			modsES.Add(CustomPrice(ItemType<TrojanSquirrelBag>(), Item.buyPrice(0, 10, 0, 0)), new Condition[] { DownedTrojanSquirrel })
				.Add(CustomPrice(ItemType<DeviBag>(), Item.buyPrice(0, 30, 0, 0)), new Condition[] { DownedDeviantt })
				.Add(CustomPrice(ItemType<BanishedBaronBag>(), Item.buyPrice(0, 40, 0, 0)), new Condition[] { DownedBanishedBaron })
				.Add(CustomPrice(ItemType<LifelightBag>(), Item.buyPrice(0, 50, 0, 0)), new Condition[] { DownedLifelight })
				.Add(CustomPrice(ItemType<CosmosBag>(), Item.buyPrice(0, 80, 0, 0)), new Condition[] { DownedCosmosChampion })
				.Add(CustomPrice(ItemType<AbomBag>(), Item.buyPrice(2, 50, 0, 0)), new Condition[] { DownedAbom })
				.Add(CustomPrice(ItemType<MutantBag>(), Item.buyPrice(5, 0, 0, 0)), new Condition[] { DownedMutant });

			//诡秘系列魔石
			modsES.Add(CustomPrice(ItemType<BaseBaseEnchant>(), Item.buyPrice(0, 1, 0, 0)), Array.Empty<Condition>());

			if (ytFargoConfig.Instance.OldCalamityEnchant)
            {
                //湮灭之力
                modsES.Add(ItemType<AerospecEnchant>(), new Condition[] { DownedSlimeGod })
					.Add(ItemType<StatigelEnchant>(), new Condition[] { Condition.Hardmode })
					.Add(ItemType<AtaxiaEnchant>(), new Condition[] { Condition.DownedCultist })
					.Add(ItemType<XerocEnchant>(), new Condition[] { DownedTheThree })
					.Add(ItemType<FearmongerEnchant>(), new Condition[] { DownedYharon });
                //荒芜之力
                modsES.Add(ItemType<VictideEnchant>(), new Condition[] { Condition.DownedEowOrBoc })
					.Add(ItemType<MolluskEnchant>(), new Condition[] { Condition.DownedMechBossAll })
					.Add(ItemType<SnowRuffianEnchant>(), new Condition[] { Condition.DownedEyeOfCthulhu })
					.Add(ItemType<DaedalusEnchant>(), new Condition[] { Condition.DownedMechBossAll })
					.Add(ItemType<SulphurousEnchant>(), new Condition[] { Condition.DownedMechBossAll })
					.Add(ItemType<FathomSwarmerEnchant>(), new Condition[] { Condition.DownedGolem })
					.Add(ItemType<UmbraphileEnchant>(), new Condition[] { Condition.DownedGolem })
					.Add(ItemType<TitanHeartEnchant>(), new Condition[] { Condition.DownedMechBossAny })
					.Add(ItemType<AstralEnchant>(), new Condition[] { Condition.DownedMoonLord })
					.Add(ItemType<OmegaBlueEnchant>(), new Condition[] { DownedDevourerOfGods });
                //毁灭之力
                modsES.Add(ItemType<WulfrumEnchant>(), new Condition[] { Condition.DownedEyeOfCthulhu })
					.Add(ItemType<ReaverEnchant>(), new Condition[] { Condition.DownedGolem })
					.Add(ItemType<PlagueEnchant>(), new Condition[] { Condition.DownedCultist })
					.Add(ItemType<DemonShadeEnchant>(), new Condition[] { DownedExoAndCal });
                //升华之力
                modsES.Add(ItemType<TarragonEnchant>(), new Condition[] { DownedDevourerOfGods })
					.Add(ItemType<BrimflameEnchant>(), new Condition[] { Condition.DownedCultist })
					.Add(ItemType<BloodflareEnchant>(), new Condition[] { DownedDevourerOfGods })
					.Add(ItemType<GodSlayerEnchant>(), new Condition[] { DownedYharon })
					.Add(ItemType<SilvaEnchant>(), new Condition[] { DownedYharon })
					.Add(ItemType<AuricEnchant>(), new Condition[] { DownedExoOrCal });
                //奇迹之力
                modsES.Add(ItemType<MarniteEnchant>(), new Condition[] { DownedSlimeGod })
					.Add(ItemType<DesertProwlerEnchant>(), new Condition[] { Condition.DownedEyeOfCthulhu })
					.Add(ItemType<LunicCorpsEnchant>(), new Condition[] { Condition.DownedMoonLord })
					.Add(ItemType<PrismaticEnchant>(), new Condition[] { DownedDevourerOfGods })
					.Add(ItemType<GemTechEnchant>(), new Condition[] { DownedExoAndCal });
            }

			//探索之力
			modsES.Add(ItemType<FargoDLC.WulfrumEnchant>(), new Condition[] { Condition.DownedEyeOfCthulhu })
				.Add(ItemType<FargoDLC.DesertProwlerEnchant>(), new Condition[] { Condition.DownedEyeOfCthulhu })
				.Add(ItemType<FargoDLC.MarniteEnchant>(), new Condition[] { Condition.DownedEyeOfCthulhu })
				.Add(ItemType<FargoDLC.VictideEnchant>(), new Condition[] { Condition.DownedEowOrBoc })
				.Add(ItemType<FargoDLC.SulphurEnchant>(), new Condition[] { Condition.DownedEowOrBoc })
				.Add(ItemType<FargoDLC.AerospecEnchant>(), new Condition[] { DownedSlimeGod });

			//模组材料
			modsES.Add(CustomPrice(ItemType<BrokenBlade>(), Item.buyPrice(1, 0, 0, 0)), new Condition[] { DownedDeviantt })
				.Add(CustomPrice(ItemType<BrokenHilt>(), Item.buyPrice(5, 0, 0, 0)), new Condition[] { DownedAbom })
				.Add(CustomPrice(ItemType<PhantasmalEnergy>(), Item.buyPrice(10, 0, 0, 0)), new Condition[] { DownedMutant });

            #endregion

            vanillaES.Register();
            modsES.Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 10;
            knockback = 2f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 8;
            randExtraCooldown = 8;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Shuriken;
            attackDelay = 3;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 10f;
            randomOffset = 2f;
            gravityCorrection = 16f;
        }
    }
}