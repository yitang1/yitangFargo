using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Security.Cryptography;
using Terraria.DataStructures;
using CalamityMod;
using CalamityMod.Projectiles.Magic;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Projectiles.Typeless;
using FargowiltasCrossmod.Core.Calamity;
using FargowiltasSouls.Content.Projectiles.BossWeapons;
using FargowiltasSouls.Content.Projectiles;
using yitangFargo.Global.Config;
using yitangFargo.Global.FuckFargo.FuckFargoGlobalItem;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalProj
{
    public class GlobalProjectileFC : GlobalProjectile
    {
        public override void OnHitNPC(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                //粘液盾
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

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                if (projectile.TryGetGlobalProjectile(out FargoSoulsGlobalProjectile fargoProj))
                {
                    if (fargoProj.TungstenScale != 1)
                    {
                        Player player = Main.player[projectile.owner];
                        Item item = player.HeldItem;
                        if (item != null && (item.DamageType == ModContent.GetInstance<TrueMeleeDamageClass>()
                            || item.DamageType == ModContent.GetInstance<TrueMeleeNoSpeedDamageClass>()))
                        {
                            float scale = CalamityFargoGlobalItem.TrueMeleeTungstenScaleUnNerf(player);
                            projectile.position = projectile.Center;
                            projectile.width = (int)(projectile.width * scale);
                            projectile.height = (int)(projectile.height * scale);
                            projectile.Center = projectile.position;
                            projectile.scale *= scale;
                        }
                    }
                }
            }
        }
    }
}