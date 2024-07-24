using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using CalamityMod.Items.Materials;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Content.Items.Accessories.Expert;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using yitangFargo.Common.Rarities;
using yitangFargo.Common;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class UniverseSoulNew : BaseSoul, ILocalizedModType
    {
        public new string LocalizationCategory => "Items";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 7));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override int NumFrames => 7;

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = Item.buyPrice(5, 0, 0, 0);
            Item.rare = ModContent.RarityType<Rainbow>();
            Item.defense = 4;
            Item.width = 5;
            Item.height = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            DamageClass damageClass = player.ProcessDamageTypeFromHeldItem();
            player.GetDamage(damageClass) += 0.66f;
            player.GetCritChance(damageClass) += 25;

            FargoSoulsPlayer modPlayer = player.FargoSouls();
            //各项数据加成
            modPlayer.UniverseSoul = true;
            modPlayer.UniverseCore = true;

            player.AddEffect<UniverseSpeedNewEffect>(Item);

            player.maxMinions += 6;
            player.maxTurrets += 6;
            player.whipRangeMultiplier += 0.15f;
            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.2f;

            player.AddEffect<MagmaStoneEffect>(Item);
            player.kbGlove = true;
            player.autoReuseGlove = true;
            player.meleeScaleGlove = true;

            player.counterWeight = 556 + Main.rand.Next(6);
            player.yoyoGlove = true;
            player.yoyoString = true;
            //天界壳
            player.wolfAcc = true;
            player.accMerman = true;

            if (hideVisual)
            {
                player.hideMerman = true;
                player.hideWolf = true;
            }

            player.lifeRegen += 2;

            player.AddEffect<SniperScopeEffect>(Item);

            player.manaFlower = true;
            player.manaMagnet = true;
            player.magicCuffs = true;
            //调用盗贼的职业魂效果
            ModContent.GetInstance<VagabondsSoulNew>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<UniverseCore>()
                .AddIngredient<BerserkerSoulNew>()
                .AddIngredient<SnipersSoulNew>()
                .AddIngredient<ArchWizardsSoulNew>()
                .AddIngredient<ConjuristsSoulNew>()
                .AddIngredient<VagabondsSoulNew>()
                .AddIngredient<AbomEnergy>(10)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }

	public class UniverseSpeedNewEffect : AccessoryEffect
	{
		public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
		public override int ToggleItemType => ModContent.ItemType<UniverseSoul>();
		public override void PostUpdateEquips(Player player)
		{
			float speed = player.FargoSouls().Eternity ? 2.5f : 0.5f;
			player.FargoSouls().AttackSpeed += speed;

			Item item = player.HeldItem;
			if (item.DamageType == DamageClass.Summon && !ProjectileID.Sets.IsAWhip[player.HeldItem.shoot]
				|| item.damage <= 0)
			{
				player.FargoSouls().AttackSpeed -= speed;
			}
		}
	}
}