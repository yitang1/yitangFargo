using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalamityMod.Projectiles.Summon;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasCrossmod.Core;
using yitangFargo.Global.Config;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Global
{
    public class ytFargoGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];

			if (!ytFargoConfig.Instance.FullCalamityEnchant)
			{
				if (projectile.type == ModContent.ProjectileType<Shellfish>()
					&& player.HasEffect<MolluskEffect>())
				{
					projectile.Kill();
				}
				if (projectile.type == ModContent.ProjectileType<PlaguebringerSummon>()
					&& player.HasEffect<PlagueEffectBringer>())
				{
					projectile.Kill();
				}
			}
        }
    }
}