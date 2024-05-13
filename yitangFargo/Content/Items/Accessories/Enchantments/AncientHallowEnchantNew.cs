using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yitangFargo.Common;
using yitangFargo.Content.Buffs;
using yitangFargo.Content.Projectiles.Minions;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class AncientHallowEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<AncientHallowEnchant>() && ytFargoConfig.Instance.OldEnchant)
            {
                player.AddEffect<AncientHallowShieldNew>(item);
                player.AddEffect<AncientHallowMinionNew>(item);
            }
        }

        public static Color GetFairyQueenWeaponsColor(float alphaChannelMultiplier, float lerpToWhite, float rawHueOverride)
        {
            float hue = (rawHueOverride + 0.5f) % 1f;
            float saturation = 1f;
            float luminosity = 0.5f;
            Color color3 = Main.hslToRgb(hue, saturation, luminosity, byte.MaxValue);
            if (lerpToWhite != 0f)
            {
                color3 = Color.Lerp(color3, Color.White, lerpToWhite);
            }
            color3.A = (byte)((float)color3.A * alphaChannelMultiplier);
            return color3;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<AncientHallowEnchant>())
            {
                if ((player.HasEffect<AncientHallowShieldNew>() || player.HasEffect<AncientHallowMinionNew>())
                    && player.HasEffect<AncientHallowMinion>())
                {
                    tooltips.ReplaceText("[AncientHallowDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[AncientHallowOld]", "");
                    tooltips.ReplaceText("[AncientHallowNew]", "");
                }
                else if (player.HasEffect<AncientHallowMinion>())
                {
                    tooltips.ReplaceText("[AncientHallowNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.AncientHallowEnchant.New"));
                    tooltips.ReplaceText("[AncientHallowOld]", "");
                    tooltips.ReplaceText("[AncientHallowDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[AncientHallowOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.AncientHallowEnchant.Old"));
                    tooltips.ReplaceText("[AncientHallowNew]", "");
                    tooltips.ReplaceText("[AncientHallowDouble]", "");
                }
            }
        }
    }

    public class AncientHallowShieldNew : AccessoryEffect
    {
        public override int ToggleItemType => ModContent.ItemType<AncientHallowEnchant>();
        public override Header ToggleHeader => Header.GetHeader<SpiritHeader>();
        public override bool IgnoresMutantPresence => true;

        public override void PostUpdateEquips(Player player)
        {
            if (!player.FargoSouls().noDodge && !player.HasBuff(ModContent.BuffType<HallowCooldownNewBuff>()))
            {
                const int focusRadius = 50;

                for (int i = 0; i < 20; i++)
                {
                    Vector2 offset = new Vector2();
                    double angle = Main.rand.NextDouble() * 2d * Math.PI;
                    offset.X += (float)(Math.Sin(angle) * focusRadius);
                    offset.Y += (float)(Math.Cos(angle) * focusRadius);
                    Dust dust = Main.dust[Dust.NewDust(
                        player.Center + offset - new Vector2(4, 4), 0, 0,
                        DustID.GoldFlame, 0, 0, 100, Color.White, 0.5f
                        )];
                    dust.velocity = player.velocity;
                    dust.noGravity = true;
                }

                Main.projectile.Where(x => x.active && x.hostile && x.damage > 0 && Vector2.Distance(x.Center, player.Center) <= focusRadius + Math.Min(x.width, x.height) / 2 && ProjectileLoader.CanDamage(x) != false && ProjectileLoader.CanHitPlayer(x, player) && yitangFargoUtils.CanDeleteProjectile(x)).ToList().ForEach(x =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int dustId = Dust.NewDust(new Vector2(x.position.X, x.position.Y + 2f), x.width, x.height + 5, DustID.GoldFlame, x.velocity.X * 0.2f, x.velocity.Y * 0.2f, 100, default(Color), 3f);
                        Main.dust[dustId].noGravity = true;
                    }

                    x.hostile = false;
                    x.friendly = true;
                    x.owner = player.whoAmI;

                    x.velocity *= -1f;

                    if (x.Center.X > player.Center.X)
                    {
                        x.direction = 1;
                        x.spriteDirection = 1;
                    }
                    else
                    {
                        x.direction = -1;
                        x.spriteDirection = -1;
                    }

                    x.netUpdate = true;

                    player.AddBuff(ModContent.BuffType<HallowCooldownNewBuff>(), 600, true, false);
                });
            }
        }
    }

    public class AncientHallowMinionNew : AccessoryEffect
    {
        public override int ToggleItemType => ModContent.ItemType<AncientHallowEnchant>();
        public override Header ToggleHeader => Header.GetHeader<SpiritHeader>();
        public override bool IgnoresMutantPresence => true;

        public override void PostUpdateEquips(Player player)
        {
            int baseDamage = 50;
            if (player.FargoSouls().ForceEffect<AncientHallowEnchant>())
            {
                baseDamage = 150;
            }
            int swordDamage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(baseDamage);
            player.yitangFargo().AddMinion(EffectItem(player), true, ModContent.ProjectileType<HallowSwordNew>(), swordDamage, 2f);
        }
    }
}
