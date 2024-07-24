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
using yitangFargo.Content.Items.Accessories.Enchantments;
using yitangFargo.Global.FuckFargo.FuckFargoSystem;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Common
{
    public class yitangFargoPlayer : ModPlayer
    {
        public override void ResetEffects()
        {
            MinionCritsYT = false;
            //AttackSpeed = 1f;
            VenomMinions = false;
            VenomNecklace = false;
            IamNinja = false;
            DesertProwlerBonus = false;
			LunicCorpsShield = false;
        }

		public override void UpdateDead()
		{
			DesertProwlerBonus = false;
		}

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
			if (Player == Main.LocalPlayer)
			{
				//雷神之锤魔石
				if (LunicCorpsShield)
				{
					modifiers.FinalDamage -= (int)50;
				}
			}
        }

        public override void OnHurt(Player.HurtInfo info)
        {
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

        public bool IamNinja = false;
        public bool DesertProwlerBonus;
		public int DesertProwlerCooldown;
		public bool LunicCorpsShield;
		public int LunicCorpsCooldown;
	}
}