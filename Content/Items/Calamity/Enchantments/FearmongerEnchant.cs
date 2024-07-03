using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Buffs.StatDebuffs;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Fearmonger;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Rarities;
using CalamityMod.Tiles.Furniture.CraftingStations;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.Toggler;
using yitangFargo.Common.Toggler;
using yitangFargo.Content.Items.Calamity.Souls;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class FearmongerEnchant : BaseEnchant
    {
        public override Color nameColor => new(83, 86, 149);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<DarkBlue>();
            Item.value = Item.buyPrice(0, 70, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<FearmongerEffect>(Item);
            player.AddEffect<FearmongerFSkullCrown>(Item);
            player.AddEffect<FearmongerNucleogenesis>(Item);

            //神惧者盔甲套装效果
            if (player.HasEffect<FearmongerEffect>())
            {
                player.Calamity().fearmongerSet = true;
                int[] immuneDebuffs = { BuffID.OnFire,
                    BuffID.Frostburn,
                    BuffID.CursedInferno,
                    BuffID.ShadowFlame,
                    BuffID.Daybreak,
                    BuffID.Burning,
                    ModContent.BuffType<Shadowflame>(),
                    ModContent.BuffType<BrimstoneFlames>(),
                    ModContent.BuffType<HolyFlames>(),
                    ModContent.BuffType<GodSlayerInferno>(),
                    BuffID.Chilled,
                    BuffID.Frozen,
                    ModContent.BuffType<GlacialState>() };
                for (var i = 0; i < immuneDebuffs.Length; ++i)
                {
                    player.buffImmune[immuneDebuffs[i]] = true;
                }
                Lighting.AddLight(player.Center, 0.3f, 0.18f, 0f);
            }
            //玄秘颅冠
            if (player.HasEffect<FearmongerFSkullCrown>())
            {
                ModContent.GetInstance<OccultSkullCrown>().UpdateAccessory(player, hideVisual);
            }
            //核子之源
            if (player.HasEffect<FearmongerNucleogenesis>())
            {
                ModContent.GetInstance<Nucleogenesis>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<FearmongerGreathelm>()
                .AddIngredient<FearmongerPlateMail>()
                .AddIngredient<FearmongerGreaves>()
                .AddIngredient<CorvidHarbringerStaff>()
                .AddIngredient<OccultSkullCrown>()
                .AddIngredient<Nucleogenesis>()
                .AddTile<CosmicAnvil>()
                .Register();
        }
    }

    public class FearmongerEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<FearmongerEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class FearmongerFSkullCrown : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<FearmongerEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class FearmongerNucleogenesis : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<FearmongerEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}