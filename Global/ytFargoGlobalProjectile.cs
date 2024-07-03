using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Content.Items.Accessories.Enchantments;

namespace yitangFargo.Global
{
    public class ytFargoGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public int AdamModifier;
        public int NinjaSpeedupNew;
        public bool NinjaCanSpeedup = true;

        public override void SetDefaults(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.MechanicalPiranha:
                    NinjaCanSpeedup = false;
                    break;
            }
        }

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (WorldGen.generatingWorld)
            {
                return;
            }

            if (projectile.owner < 0 || projectile.owner >= Main.maxPlayers)
                return;

            Player player = Main.player[projectile.owner];
            FargoSoulsPlayer modPlayerF = player.FargoSouls();

            //精金魔石旧版
            if (player.HasEffect<AdamantiteEffectNew>() && !player.HasEffect<AdamantiteEffect>()
                && FargoSoulsUtil.OnSpawnEnchCanAffectProjectile(projectile, false)
                && projectile.FargoSouls().CanSplit && Array.IndexOf(NoSplit, projectile.type) <= -1
                && projectile.aiStyle != ProjAIStyleID.Spear)
            {
                if (projectile.owner == Main.myPlayer
                    && !(modPlayerF.Player.heldProj == projectile.whoAmI)
                    && (FargoSoulsUtil.IsProjSourceItemUseReal(projectile, source)
                    || source is EntitySource_Parent parent && parent.Entity is Projectile sourceProj && (sourceProj.aiStyle == ProjAIStyleID.Spear || sourceProj.minion || sourceProj.sentry || ProjectileID.Sets.IsAWhip[sourceProj.type] && !ProjectileID.Sets.IsAWhip[projectile.type])))
                {
                    projectile.ArmorPenetration += projectile.damage / 2;
                    AdamantiteEffectNew.AdamantiteSplitNew(projectile, player, 8);
                }
                AdamModifier = modPlayerF.ForceEffect<AdamantiteEnchant>() ? 3 : 2;
            }

            //忍者魔石旧版
            if (player.HasEffect<NinjaEffectNew>()
                && FargoSoulsUtil.OnSpawnEnchCanAffectProjectile(projectile, true)
                && projectile.type != ProjectileID.WireKite
                && projectile.whoAmI != player.heldProj
                && NinjaCanSpeedup
                && projectile.aiStyle != 190
                && !projectile.minion)
            {
                NinjaEffectNew.NinjaSpeedSetupNew(player, projectile, this);
            }
        }

        public static int[] NoSplit => new int[] {
            ProjectileID.LastPrism,
            ProjectileID.LastPrismLaser,
            ProjectileID.WireKite,
            ProjectileID.Xenopopper
        };

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            int AccountForDefenseShred(int modifier)
            {
                int defenseIgnored = projectile.ArmorPenetration;
                if (target.ichor)
                    defenseIgnored += 15;
                if (target.betsysCurse)
                    defenseIgnored += 40;

                int actualDefenseIgnored = Math.Min(defenseIgnored, target.defense);
                int effectOnDamage = actualDefenseIgnored / 2;

                return effectOnDamage / modifier;
            }
            if (AdamModifier != 0)
            {
                modifiers.FinalDamage /= AdamModifier;
                modifiers.FinalDamage.Flat -= AccountForDefenseShred(AdamModifier);
            }
            //钱币枪
            switch (projectile.type)
            {
                case ProjectileID.SilverCoin:
                    modifiers.FinalDamage /= 0.9f;
                    break;
                case ProjectileID.GoldCoin:
                    modifiers.FinalDamage /= 0.47f;
                    break;
                case ProjectileID.PlatinumCoin:
                    modifiers.FinalDamage /= 0.275f;
                    break;
            }
        }

        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            if (NinjaSpeedupNew > 0 && player.heldProj != projectile.whoAmI)
            {
                projectile.extraUpdates = Math.Max(projectile.extraUpdates, NinjaSpeedupNew);
                if (projectile.owner == Main.myPlayer && !player.HasEffect<NinjaEffectNew>())
                {
                    projectile.Kill();
                }
            }
        }
    }
}