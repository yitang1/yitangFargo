using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using CalamityMod;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.Systems;
using FargowiltasCrossmod.Core.Calamity.Globals;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Common;
using yitangFargo.Content.Buffs;
using yitangFargo.Content.Items.Others;
using yitangFargo.Global.FuckFargo.FuckFargoSystem;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Common
{
    public class yitangFargoPlayer : ModPlayer
    {
        public override void ResetEffects()
        {
			VenomNecklace = false;
			IamNinja = false;
            DesertProwlerBonus = false;
        }

		public override void UpdateDead()
		{
			DesertProwlerBonus = false;
		}

        public override void OnHurt(Player.HurtInfo info)
        {
			//雷神之锤魔石
			if (Player.HasEffect<DLunicCorpsEffect>())
			{
				LunicCorpsCooldown = 420;
			}
        }

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (CalamityKeybinds.ArmorSetBonusHotKey.JustPressed)
			{
				//沙漠巡游者魔石
				if (DesertProwlerBonus && DesertProwlerCooldown <= 0)
				{
					if (Player.whoAmI == Main.myPlayer)
					{
						Player.AddBuff(ModContent.BuffType<DesertProwlerBuff>(), 600, false);
						DesertProwlerCooldown = 2100;
					}
				}
			}
		}

		public override void PreUpdate()
		{
			if (DesertProwlerCooldown > 0)
			{
				DesertProwlerCooldown--;
			}
			if (LunicCorpsCooldown > 0)
			{
				LunicCorpsCooldown--;
			}
		}

		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Player.whoAmI != Main.myPlayer)
				return;

			NPCDebuffs(target, item.CountsAsClass<MeleeDamageClass>(),
				item.CountsAsClass<RangedDamageClass>(),
				item.CountsAsClass<MagicDamageClass>(),
				item.CountsAsClass<SummonDamageClass>(),
				item.CountsAsClass<ThrowingDamageClass>(),
				item.CountsAsClass<SummonMeleeSpeedDamageClass>());
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Player.whoAmI != Main.myPlayer)
				return;

			if (!proj.npcProj && !proj.trap && proj.friendly)
			{
				NPCDebuffs(target, proj.CountsAsClass<MeleeDamageClass>(),
					proj.CountsAsClass<RangedDamageClass>(),
					proj.CountsAsClass<MagicDamageClass>(),
					proj.CountsAsClass<SummonDamageClass>(),
					proj.CountsAsClass<ThrowingDamageClass>(),
					proj.CountsAsClass<SummonMeleeSpeedDamageClass>(), true, proj.noEnchantments);
			}
		}

		public void NPCDebuffs(NPC target, bool melee, bool ranged, bool magic, bool summon, bool rogue, bool whip, bool proj = false, bool noFlask = false)
		{
			//恼怒项链
			if (VenomNecklace)
			{
				target.AddBuff(BuffID.Venom, 120);
			}
		}

		public bool VenomNecklace = false;
		public bool IamNinja = false;
        public bool DesertProwlerBonus;
		public int DesertProwlerCooldown;
		public int LunicCorpsCooldown;
	}
}