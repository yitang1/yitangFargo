using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Cooldowns;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.OmegaBlue;
using CalamityMod.Rarities;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Enchantments
{
    public class OmegaBlueEnchant : BaseEnchant
    {
        public override Color nameColor => new(68, 139, 218);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<PureGreen>();
            Item.value = Item.buyPrice(0, 40, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<OmegaBlueEffect>(Item);
            player.AddEffect<OmegaBluePhantomic>(Item);

            //蓝色欧米茄盔甲
            CalamityPlayer calamityPlayer = player.Calamity();
            if (player.HasEffect<OmegaBlueEffect>())
            {
                calamityPlayer.omegaBlueSet = true;

                var hasOmegaBlueCooldown = calamityPlayer.cooldowns.TryGetValue(CalamityMod.Cooldowns.OmegaBlue.ID, out var cd);
                if (hasOmegaBlueCooldown && cd.timeLeft > 1500)
                {
                    var d = Dust.NewDust(player.position, player.width, player.height, 20, 0, 0, 100, Color.Transparent, 1.6f);
                    Main.dust[d].noGravity = true;
                    Main.dust[d].noLight = true;
                    Main.dust[d].fadeIn = 1f;
                    Main.dust[d].velocity *= 3f;
                }
            }
            //幻魂神物
            if (player.HasEffect<OmegaBluePhantomic>())
            {
                ModContent.GetInstance<PhantomicArtifact>().UpdateAccessory(player, hideVisual);
            }
            //惧魂神物
            ModContent.GetInstance<EldritchSoulArtifact>().UpdateAccessory(player, hideVisual);
            //灾劫之尖啸
            ModContent.GetInstance<Affliction>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<OmegaBlueHelmet>()
                .AddIngredient<OmegaBlueChestplate>()
                .AddIngredient<OmegaBlueTentacles>()
                .AddIngredient<PhantomicArtifact>()
                .AddIngredient<EldritchSoulArtifact>()
                .AddIngredient<Affliction>()
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    public class OmegaBlueEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<OmegaBlueEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
    public class OmegaBluePhantomic : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<DesolationHeader>();
        public override int ToggleItemType => ModContent.ItemType<OmegaBlueEnchant>();
        public override bool IgnoresMutantPresence => true;
    }
}