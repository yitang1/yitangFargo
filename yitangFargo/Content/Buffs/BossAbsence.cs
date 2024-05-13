using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasCrossmod.Content.Calamity.Buffs;
using FargowiltasSouls.Content.Buffs.Boss;

namespace yitangFargo.Content.Buffs
{
    public class BossAbsence : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[ModContent.BuffType<DeviPresenceBuff>()] = true;
            player.buffImmune[ModContent.BuffType<AbomPresenceBuff>()] = true;
            player.buffImmune[ModContent.BuffType<MutantPresenceBuff>()] = true;
            player.buffImmune[ModContent.BuffType<CalamitousPresenceBuff>()] = true;
        }
    }
}
