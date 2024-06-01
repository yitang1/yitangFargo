using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Mollusk;
using CalamityMod.Projectiles.Summon;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using yitangFargo.Common.Toggler;
using yitangFargo.Content.Projectiles.Minions;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class MolluskEnchant : BaseEnchant
    {
        public override Color nameColor => new(58, 134, 167);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<MolluskEffect>(Item);
            player.AddEffect<MolluskGiantPearl>(Item);
            player.AddEffect<MolluskFAquaticEmblem>(Item);
            ModContent.GetInstance<VictideEnchant>().UpdateAccessory(player, hideVisual);

            //软壳贝盔
            if (player.HasEffect<MolluskEffect>())
            {
                player.Calamity().molluskSet = true;
            }
            //大珍珠
            if (player.HasEffect<MolluskGiantPearl>())
            {
                ModContent.GetInstance<GiantPearl>().UpdateAccessory(player, hideVisual);
            }
            //海波纹章
            if (player.HasEffect<MolluskFAquaticEmblem>())
            {
                ModContent.GetInstance<AquaticEmblem>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MolluskShellmet>()
                .AddIngredient<MolluskShellplate>()
                .AddIngredient<MolluskShelleggings>()
                .AddIngredient<VictideEnchant>()
                .AddIngredient<GiantPearl>()
                .AddIngredient<AquaticEmblem>()
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }

    public class MolluskEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<MolluskEnchant>();
        public override bool IgnoresMutantPresence => true;
        //沉沦之贝
        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(140);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<ShellfishNew>()] < 4)
                {
                    FargoSoulsUtil.NewSummonProjectile(GetSource_EffectItem(player), player.Center, Vector2.Zero,
                        ModContent.ProjectileType<ShellfishNew>(), damage, 0f, player.whoAmI);
                }
            }
        }
    }
    public class MolluskGiantPearl : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<MolluskEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class MolluskFAquaticEmblem : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<MolluskEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}