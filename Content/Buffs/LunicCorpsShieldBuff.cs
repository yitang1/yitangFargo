using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangFargo.Common;

namespace yitangFargo.Content.Buffs
{
	public class LunicCorpsShieldBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 50;
		}
	}
}