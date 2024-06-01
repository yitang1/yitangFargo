using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Victide;
using FargowiltasSouls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Content.Buffs.Masomode;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class VictideEnchant : BaseEnchant
    {
        public override Color nameColor => new(156, 192, 202);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 2, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<MolluskVictideEffect>(Item);
            player.AddEffect<MolluskVictideESnail>(Item);
            player.AddEffect<MolluskVictideLuxors>(Item);
            player.AddEffect<MolluskVictideSpark>(Item);

            //胜潮盔甲
            if (player.HasEffect<MolluskVictideEffect>())
            {
                player.Calamity().victideSet = true;
                player.ignoreWater = true;
            }
            //海蜗牛
            if (player.HasEffect<MolluskVictideESnail>())
            {
                player.Calamity().victideSummoner = true;
            }
            //卢克索的礼物
            if (player.HasEffect<MolluskVictideLuxors>())
            {
                ModContent.GetInstance<LuxorsGift>().UpdateAccessory(player, hideVisual);
            }
            //阿米迪亚斯电火花石
            if (player.HasEffect<MolluskVictideSpark>())
            {
                ModContent.GetInstance<AmidiasSpark>().UpdateAccessory(player, hideVisual);
            }
            //海之盾
            /*(由于在实际游戏过程中，玩家几乎很少出现同时穿戴胜潮盔甲+佩戴胜潮魔石的情况，
            在未穿戴全套胜潮盔甲的情况下，如果直接调用海之盾的效果，那仅仅只会生效溺水加成的效果。
            所以在这里魔石的效果改为【无论是否穿戴全套胜潮盔甲，都能获得海之盾的移速和生命再生加成】
            因为胜潮魔石本身就包含了全套胜潮盔甲
            当然，因为这个饰品的效果全是正面数值加成，所以不添加开关选项，而是常时生效。)*/
            if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
            {
                player.statDefense += 5;
            }
            if ((player.armor[0].type != ModContent.ItemType<VictideHeadMelee>() || player.armor[0].type != ModContent.ItemType<VictideHeadRanged>() ||
                player.armor[0].type != ModContent.ItemType<VictideHeadMagic>() || player.armor[0].type != ModContent.ItemType<VictideHeadSummon>() ||
                player.armor[0].type != ModContent.ItemType<VictideHeadRogue>()) ||
                player.armor[1].type != ModContent.ItemType<VictideBreastplate>() || player.armor[2].type != ModContent.ItemType<VictideGreaves>())
            {
                player.moveSpeed += 0.1f;
                player.lifeRegen += 2;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("yitangFargo:AnyVictide")
                .AddIngredient<VictideBreastplate>()
                .AddIngredient<VictideGreaves>()
                .AddIngredient<ShieldoftheOcean>()
                .AddIngredient<LuxorsGift>()
                .AddIngredient<AmidiasSpark>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class MolluskVictideEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<VictideEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class MolluskVictideESnail : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<VictideEnchant>();
        public override bool IgnoresMutantPresence => true;
        //海蜗牛
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(7);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<VictideSeaSnail>()] < 1)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<VictideSeaSnail>(), damage, 0f, player.whoAmI, 0f, 0f);
                }
            }
        }
    }
    public class MolluskVictideLuxors : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<VictideEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class MolluskVictideSpark : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<VictideEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}