using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Empyrean;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class XerocEnchant : BaseEnchant
    {
        public override Color nameColor => new(129, 91, 101);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Red;
            Item.value = Item.buyPrice(0, 30, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<XerocEffect>(Item);
            player.AddEffect<XerocEtherealExtorter>(Item);
            player.AddEffect<XerocSpectralVeil>(Item);

            //皇天盔甲
            if (player.HasEffect<XerocEffect>())
            {
                player.Calamity().xerocSet = true;
                if (player.statLife <= (int)(player.statLifeMax2 * 0.5))
                {
                    player.AddBuff(ModContent.BuffType<EmpyreanWrath>(), 2);
                    player.AddBuff(ModContent.BuffType<EmpyreanRage>(), 2);
                }
            }
            //虚空掠夺者
            if (player.HasEffect<XerocEtherealExtorter>())
            {
                ModContent.GetInstance<EtherealExtorter>().UpdateAccessory(player, hideVisual);
            }
            //幽灵披风
            if (player.HasEffect<XerocSpectralVeil>())
            {
                ModContent.GetInstance<SpectralVeil>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<EmpyreanMask>()
                .AddIngredient<EmpyreanCloak>()
                .AddIngredient<EmpyreanCuisses>()
                .AddIngredient<CelestialReaper>()
                .AddIngredient<EtherealExtorter>()
                .AddIngredient<SpectralVeil>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class XerocEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<XerocEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class XerocEtherealExtorter : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<XerocEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class XerocSpectralVeil : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<AnnihilationHeader>();
        public override int ToggleItemType => ModContent.ItemType<XerocEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}