using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;
using FargowiltasSouls.Content.Buffs.Boss;
using FargowiltasSouls.Content.Buffs.Masomode;
using FargowiltasCrossmod.Content.Calamity.Buffs;
using yitangFargo.Global.Config;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalBuff
{
    public class GlobalBuffFC : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            //移除“驾到”减益
            if (ytFargoConfig.Instance.NoBossDebuff)
            {
                player.buffImmune[ModContent.BuffType<DeviPresenceBuff>()] = true;
                player.buffImmune[ModContent.BuffType<AbomPresenceBuff>()] = true;
                player.buffImmune[ModContent.BuffType<MutantPresenceBuff>()] = true;
                player.buffImmune[ModContent.BuffType<CalamitousPresenceBuff>()] = true;
            }
        }
    }
}