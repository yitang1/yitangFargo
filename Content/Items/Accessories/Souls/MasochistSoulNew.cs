using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls;
using FargowiltasSouls.Content.Buffs.Masomode;
using FargowiltasSouls.Content.Buffs.Minions;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Consumables;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    [AutoloadEquip(EquipType.Face, EquipType.Front, EquipType.Back, EquipType.Shield)]
    public class MasochistSoulNew : BaseSoul
    {
        public override bool Eternity => true;

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = Item.buyPrice(5, 0, 0, 0);
            Item.defense = 30;
            Item.useTime = 180;
            Item.useAnimation = 180;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item6;
        }
        public static readonly Color ItemColor = new(255, 51, 153, 0);
        protected override Color? nameColor => ItemColor;

        public override void UseItemFrame(Player player) => SandsofTime.Use(player);
        public override bool? UseItem(Player player) => true;

        void PassiveEffect(Player player, Item item)
        {
            BionomicCluster.PassiveEffect(player, Item);

            player.FargoSouls().CanAmmoCycle = true;
        }

        public override void UpdateInventory(Player player) => PassiveEffect(player, Item);
        public override void UpdateVanity(Player player) => PassiveEffect(player, Item);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            BionomicCluster.PassiveEffect(player, Item);

            FargoSoulsPlayer fargoPlayer = player.FargoSouls();
            fargoPlayer.MasochistSoul = true;
            fargoPlayer.MasochistSoulItem = Item;

            player.AddBuff(ModContent.BuffType<SouloftheMasochistBuff>(), 2);

            //基础数据加成
            DamageClass damageClass = player.ProcessDamageTypeFromHeldItem();
            player.GetDamage(damageClass) += 0.5f;
            player.endurance += 0.1f;
            player.GetArmorPenetration(DamageClass.Generic) += 50;
            player.statLifeMax2 += player.statLifeMax;
            if (!fargoPlayer.MutantPresence)
            {
                player.lifeRegen += 7;
                player.lifeRegenTime += 7;
                player.lifeRegenCount += 7;
            }
            fargoPlayer.WingTimeModifier += 2f;
            player.moveSpeed += 0.2f;

            player.buffImmune[BuffID.Slimed] = true;

            player.AddEffect<SlimeFallEffect>(Item);

            if (player.AddEffect<SlimyShieldEffect>(Item))
            {
                player.FargoSouls().SlimyShieldItem = Item;
            }

            //躁动晶状体
            player.AddEffect<AgitatingLensEffect>(Item);
            player.AddEffect<AgitatingLensInstall>(Item);

            //蜂后毒刺
            player.npcTypeNoAggro[210] = true;
            player.npcTypeNoAggro[211] = true;
            player.npcTypeNoAggro[42] = true;
            player.npcTypeNoAggro[176] = true;
            player.npcTypeNoAggro[231] = true;
            player.npcTypeNoAggro[232] = true;
            player.npcTypeNoAggro[233] = true;
            player.npcTypeNoAggro[234] = true;
            player.npcTypeNoAggro[235] = true;
            fargoPlayer.QueenStingerItem = Item;

            //死灵秘酿
            fargoPlayer.NecromanticBrewItem = Item;
            player.AddEffect<NecroBrewSpin>(Item);

            //至高告死精灵
            fargoPlayer.SupremeDeathbringerFairy = true;

            //纯净之心
            fargoPlayer.PureHeart = true;

            //暗黑之心
            fargoPlayer.DarkenedHeartItem = Item;
            player.AddEffect<DarkenedHeartEaters>(Item);
            player.hasMagiluminescence = true;
            if (fargoPlayer.DarkenedHeartCD > 0)
                fargoPlayer.DarkenedHeartCD -= 2;

            //破碎之心
            player.AddEffect<GuttedHeartEffect>(Item);
            player.AddEffect<GuttedHeartMinions>(Item);
            fargoPlayer.GuttedHeartCD -= 2;

            //明胶羽翼
            player.FargoSouls().GelicWingsItem = Item;
            player.AddEffect<GelicWingJump>(Item);

            //突变抗体
            player.buffImmune[BuffID.Wet] = true;
            player.buffImmune[BuffID.Rabies] = true;
            fargoPlayer.MutantAntibodies = true;
            if (player.mount.Active && player.mount.Type == MountID.CuteFishron)
                player.dripping = true;

            //血肉团
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Dazed] = true;
            fargoPlayer.SkullCharm = true;
            fargoPlayer.LumpOfFlesh = true;
            fargoPlayer.PungentEyeball = true;
            player.AddEffect<PungentEyeballCursor>(Item);
            player.buffImmune[ModContent.BuffType<CrystalSkullBuff>()] = true;

            //邪恶头骨
            player.AddEffect<SinisterIconEffect>(Item);
            player.AddEffect<SinisterIconDropsEffect>(Item);

            //飞龙之羽
            player.AddEffect<ClippedEffect>(Item);

            //寒玉
            player.buffImmune[BuffID.Frostburn] = true;

            //诅咒袋子
            player.buffImmune[BuffID.ShadowFlame] = true;
            player.buffImmune[ModContent.BuffType<ShadowflameBuff>()] = true;
            player.AddEffect<WretchedPouchEffect>(Item);

            //时之沙
            player.buffImmune[BuffID.WindPushed] = true;
            fargoPlayer.SandsofTime = true;

            //神秘头骨
            player.buffImmune[BuffID.Suffocation] = true;
            player.manaFlower = true;

            //安全钱包
            fargoPlayer.SecurityWallet = true;

            //普通的胡萝卜
            player.nightVision = true;
            player.AddEffect<MasoCarrotEffect>(Item);

            //吱吱响的玩具
            player.AddEffect<SqueakEffect>(Item);

            //部落挂坠
            player.buffImmune[BuffID.Webbed] = true;
            fargoPlayer.TribalCharm = true;
            fargoPlayer.TribalCharmEquipped = true;

            //宁芙的香水
            player.buffImmune[BuffID.Lovestruck] = true;
            player.buffImmune[BuffID.Stinky] = true;
            fargoPlayer.NymphsPerfumeRespawn = true;
            player.AddEffect<NymphPerfumeEffect>(Item);

            //蒂姆的秘药
            player.AddEffect<TimsConcoctionEffect>(Item);

            //飞龙之羽
            player.AddEffect<WyvernBalls>(Item);

            //可疑电路
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Ichor] = true;
            fargoPlayer.FusedLens = true;
            player.AddEffect<FusedLensInstall>(Item);
            player.AddEffect<GroundStickDR>(Item);
            player.noKnockback = true;
            if (player.onFire2)
                player.FargoSouls().AttackSpeed += 0.15f;
            if (player.ichor)
                player.GetCritChance(DamageClass.Generic) += 15;

            //魔法球茎
            player.buffImmune[BuffID.Venom] = true;
            fargoPlayer.MagicalBulb = true;

            //冰雪女王的皇冠
            IceQueensCrown.AddEffects(player, Item);

            //丛林蜥蜴宝藏盒
            player.buffImmune[BuffID.Burning] = true;
            fargoPlayer.LihzahrdTreasureBoxItem = Item;
            player.AddEffect<LihzahrdGroundPound>(Item);
            player.AddEffect<LihzahrdBoulders>(Item);

            //飞碟控制台
            player.buffImmune[BuffID.Electrified] = true;

            //双足翼龙之心
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            fargoPlayer.BetsysHeartItem = Item;

            //南瓜王的披肩
            player.AddEffect<PumpkingsCapeEffect>(Item);

            //天界符文
            player.AddEffect<CelestialRuneAttacks>(Item);
            if (fargoPlayer.AdditionalAttacksTimer > 0)
                fargoPlayer.AdditionalAttacksTimer -= 2;

            //月之圣杯
            fargoPlayer.MoonChalice = true;

            //银河球
            player.buffImmune[BuffID.VortexDebuff] = true;
            //player.buffImmune[BuffID.ChaosState] = true;
            fargoPlayer.GravityGlobeEXItem = Item;
            player.AddEffect<MasoGravEffect>(Item);

            //永恒者之心
            fargoPlayer.MasochistHeart = true;
            player.buffImmune[BuffID.MoonLeech] = true;

            //玲珑圣印
            fargoPlayer.PrecisionSeal = true;
            player.AddEffect<PrecisionSealHurtbox>(Item);

            //恐惧螺壳
            player.AddEffect<DreadShellEffect>(Item);

            //冰鹿爪
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.AddEffect<DeerclawpsDive>(Item);
            player.AddEffect<DeerclawpsEffect>(Item);

            //永恒Buff (免疫绝大多数减益，使用永恒能量、装备大师之魂和永恒之魂都可以获得)
            player.buffImmune[ModContent.BuffType<AnticoagulationBuff>()] = true;
            player.buffImmune[ModContent.BuffType<AntisocialBuff>()] = true;
            player.buffImmune[ModContent.BuffType<AtrophiedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<BerserkedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<BloodthirstyBuff>()] = true;
            player.buffImmune[ModContent.BuffType<ClippedWingsBuff>()] = true;
            player.buffImmune[ModContent.BuffType<CrippledBuff>()] = true;
            player.buffImmune[ModContent.BuffType<CurseoftheMoonBuff>()] = true;
            player.buffImmune[ModContent.BuffType<DefenselessBuff>()] = true;
            player.buffImmune[ModContent.BuffType<FlamesoftheUniverseBuff>()] = true;
            player.buffImmune[ModContent.BuffType<FlippedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<FlippedHallowBuff>()] = true;
            player.buffImmune[ModContent.BuffType<FusedBuff>()] = true;
            //player.buffImmune[ModContent.BuffType<GodEater>()] = true;
            player.buffImmune[ModContent.BuffType<GuiltyBuff>()] = true;
            player.buffImmune[ModContent.BuffType<HexedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<HypothermiaBuff>()] = true;
            player.buffImmune[ModContent.BuffType<InfestedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<IvyVenomBuff>()] = true;
            player.buffImmune[ModContent.BuffType<JammedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LethargicBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LihzahrdCurseBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LightningRodBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LivingWastelandBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LoosePocketsBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LovestruckBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LowGroundBuff>()] = true;
            player.buffImmune[ModContent.BuffType<MarkedforDeathBuff>()] = true;
            player.buffImmune[ModContent.BuffType<MidasBuff>()] = true;
            player.buffImmune[ModContent.BuffType<MutantNibbleBuff>()] = true;
            player.buffImmune[ModContent.BuffType<NanoInjectionBuff>()] = true;
            player.buffImmune[ModContent.BuffType<NullificationCurseBuff>()] = true;
            player.buffImmune[ModContent.BuffType<OiledBuff>()] = true;
            player.buffImmune[ModContent.BuffType<OceanicMaulBuff>()] = true;
            player.buffImmune[ModContent.BuffType<PurifiedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<ReverseManaFlowBuff>()] = true;
            player.buffImmune[ModContent.BuffType<RottingBuff>()] = true;
            player.buffImmune[ModContent.BuffType<ShadowflameBuff>()] = true;
            player.buffImmune[ModContent.BuffType<SmiteBuff>()] = true;
            player.buffImmune[ModContent.BuffType<SqueakyToyBuff>()] = true;
            player.buffImmune[ModContent.BuffType<SwarmingBuff>()] = true;
            player.buffImmune[ModContent.BuffType<StunnedBuff>()] = true;
            player.buffImmune[ModContent.BuffType<UnluckyBuff>()] = true;
            player.buffImmune[ModContent.BuffType<UnstableBuff>()] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<SinisterIcon>()
                .AddIngredient<SupremeDeathbringerFairy>()
                .AddIngredient<BionomicCluster>()
                .AddIngredient<DubiousCircuitry>()
                .AddIngredient<PureHeart>()
                .AddIngredient<LumpOfFlesh>()
                .AddIngredient<ChaliceoftheMoon>()
                .AddIngredient<HeartoftheMasochist>()
                .AddIngredient<AbomEnergy>(15)
                .AddIngredient<DeviatingEnergy>(15)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}