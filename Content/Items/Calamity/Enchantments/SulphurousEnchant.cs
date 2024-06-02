﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.ExtraJumps;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Sulphurous;
using CalamityMod.Items.Weapons.Summon;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class SulphurousEnchant : BaseEnchant
    {
        public override Color nameColor => new(173, 142, 91);

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
            player.AddEffect<FathomSulphurousEffect>(Item);
            player.AddEffect<FathomSulphurousSand>(Item);
            player.AddEffect<FathomSulphurousSpine>(Item);

            //硫磺盔甲
            if (player.HasEffect<FathomSulphurousEffect>())
            {
                player.Calamity().sulphurSet = true;
                player.GetJumpState<SulphurJump>().Enable();
                player.ignoreWater = true;
            }
            //沙尘披风
            if (player.HasEffect<FathomSulphurousSand>())
            {
                ModContent.GetInstance<SandCloak>().UpdateAccessory(player, hideVisual);
            }
            //腐蚀脊椎
            if (player.HasEffect<FathomSulphurousSpine>())
            {
                ModContent.GetInstance<CorrosiveSpine>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<SulphurousHelmet>()
                .AddIngredient<SulphurousBreastplate>()
                .AddIngredient<SulphurousLeggings>()
                .AddIngredient<CausticCroakerStaff>()
                .AddIngredient<SandCloak>()
                .AddIngredient<CorrosiveSpine>()
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    public class FathomSulphurousEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SulphurousEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class FathomSulphurousSand : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SulphurousEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class FathomSulphurousSpine : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<SulphurousEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}