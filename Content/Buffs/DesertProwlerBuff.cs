using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.Particles;
using yitangFargo.Common;

namespace yitangFargo.Content.Buffs
{
    public class DesertProwlerBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
			Main.buffNoSave[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
			player.noKnockback = true;
			player.moveSpeed *= 1.5f;
			player.aggro = (int)(player.aggro * 0.5f);
			player.endurance -= 0.3f;

			for (int i = 0; i < 2; i++)
            {
                Vector2 dustDisplace = Main.rand.NextVector2Circular(80f, 50f);
                Vector2 dustPosition = player.MountedCenter + dustDisplace;
                Vector2 dustSpeed = Main.rand.NextVector2Circular(0.5f, 0.5f) + player.velocity / 8f - Vector2.UnitY.RotatedByRandom(MathHelper.PiOver4) * 0.06f;
                dustSpeed.X += 1.4f * (float)Math.Sin(((dustDisplace.X + 80f) / 160f) * MathHelper.Pi) * (Main.rand.NextBool() ? -1 : 1);
                Particle dust = new SandyDustParticle(dustPosition, dustSpeed, Color.White, Main.rand.NextFloat(0.7f, 1.2f), Main.rand.Next(20, 50), 0.03f, Vector2.UnitY * 0.03f);
                GeneralParticleHandler.SpawnParticle(dust);
            }

            int sandSmokeCount = Main.rand.Next(2, 3);
            for (int i = 0; i < sandSmokeCount; i++)
            {
                Color startColor = new Color(173, 156, 112);
                Color endColor = new Color(143, 120, 63);
                if (Main.rand.NextBool())
                {
                    startColor = new Color(173, 139, 100);
                    endColor = new Color(149, 106, 50);
                }

                Vector3 hslStartColor = Main.rgbToHsl(startColor);
                Vector3 hslEndColor = Main.rgbToHsl(endColor);

                float valueShift = Main.rand.NextFloat(0f, 0.5f);
                float satShift = Main.rand.NextFloat(-0.1f, 0f);
                float hueShiftPercent = Main.rand.NextFloat();

                hslStartColor.Z = Math.Clamp(hslStartColor.Z + valueShift, 0f, 1f);
                hslEndColor.Z = Math.Clamp(hslEndColor.Z + valueShift, 0f, 1f);

                hslStartColor.Y = Math.Clamp(hslStartColor.Y + satShift, 0f, 1f);
                hslEndColor.Y = Math.Clamp(hslEndColor.Y + satShift, 0f, 1f);

                hslStartColor.X = MathHelper.Lerp(hslStartColor.X, 43 / 255f, hueShiftPercent);
                hslEndColor.X = MathHelper.Lerp(hslEndColor.X, 43 / 255f, hueShiftPercent);

                startColor = Main.hslToRgb(hslStartColor);
                endColor = Main.hslToRgb(hslEndColor);

                Vector2 smokeRandomPos = Main.rand.NextVector2Circular(40f, player.height);
                Vector2 smokePos = player.MountedCenter + smokeRandomPos;
                float burstAngle = MathHelper.Pi - ((smokeRandomPos.X + 40) / 80f) * MathHelper.Pi;
                Vector2 smokeSpeed = Main.rand.NextVector2Circular(1f, 0.5f) - Vector2.UnitY * 0.05f + player.velocity * 0.5f + burstAngle.ToRotationVector2() * ((1 - (float)Math.Sin(burstAngle)) * 0.9f + 0.1f) * 1.5f;
                smokeSpeed.X += (float)Math.Sin(((smokeRandomPos.X + 40) / 80f) * MathHelper.Pi) * (Main.rand.NextBool() ? -1 : 1);
                Particle smoke = new TimedSmokeParticle(smokePos, smokeSpeed, startColor, endColor, Main.rand.NextFloat(0.7f, 1.6f), Main.rand.NextFloat(0.4f, 0.55f), Main.rand.Next(20, 36), 0.01f);
                GeneralParticleHandler.SpawnParticle(smoke);
            }

            Vector2 dustDirection = Main.rand.NextVector2CircularEdge(1f, 1f);
            float dustDistance = Main.rand.NextFloat(30f);
            Vector2 dustPos = player.MountedCenter + dustDirection * dustDistance;
            int dustType = Main.rand.NextBool() ? 32 : 31;

            Dust dhusvtt = Dust.NewDustPerfect(dustPos, dustType);
            dhusvtt.noGravity = true;
            dhusvtt.fadeIn = 1f;
            Vector2 dustVelocity = dustDirection.RotatedBy(MathHelper.PiOver2) * 0.04f * dustDistance;
            dhusvtt.velocity = dustVelocity;
        }
    }
}