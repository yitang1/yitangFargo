using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Security.Cryptography;
using FargowiltasSouls.Content.Projectiles.BossWeapons;
using yitangFargo.Global.Config;
using CalamityMod.Projectiles.Magic;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Projectiles.Typeless;
using FargowiltasCrossmod.Core.Calamity;
using CalamityMod;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalProj
{
    public class GlobalProjectileFC : GlobalProjectile
    {
        public override void OnHitNPC(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                if (proj.type == ModContent.ProjectileType<SlimeBall>())
                {
                    target.AddBuff(BuffID.Oiled, 240);
                }
            }
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                if (projectile.type == ModContent.ProjectileType<BlushieStaffProj>())
                    modifiers.FinalDamage /= 0.7f;
                if (CalDLCSets.Projectiles.EternityBookProj[projectile.type]
                    || (projectile.type == ModContent.ProjectileType<DirectStrike>()
                    && Main.player[projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<EternityBook>()] > 0))
                    modifiers.FinalDamage /= 0.4f;
                if (CalDLCSets.Projectiles.AngelAllianceProj[projectile.type])
                {
                    modifiers.FinalDamage /= 0.2f;
                }
                if (projectile.type == ModContent.ProjectileType<AndromedaDeathRay>())
                {
                    modifiers.FinalDamage /= 0.45f;
                }
                if (projectile.type == ModContent.ProjectileType<AndromedaRegislash>())
                {
                    modifiers.FinalDamage /= 0.8f;
                }
                if (CalDLCSets.Projectiles.ProfanedCrystalProj[projectile.type] && Main.player[projectile.owner].Calamity().profanedCrystal)
                {
                    modifiers.FinalDamage /= 0.4f;
                    for (int i = 0; i < Main.player[projectile.owner].ownedProjectileCounts.Length; i++)
                    {
                        if (ContentSamples.ProjectilesByType[i].minionSlots > 0 && Main.player[projectile.owner].ownedProjectileCounts[i] > 0)
                        {
                            modifiers.FinalDamage /= 0.3f;
                        }
                    }
                }
            }
        }
    }
}