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
            //移除神圣闪避后的Debuff
            if (player.HasBuff<HolyPriceBuff>())
            {
                player.ClearBuff(ModContent.BuffType<HolyPriceBuff>());
                //player.FargoSouls().AttackSpeed += 0.30f;
            }
            //移除混乱之脑闪避后的Debuff
            //if (player.HasBuff<BrainOfConfusionBuff>())
            //{
            //    player.ClearBuff(ModContent.BuffType<BrainOfConfusionBuff>());
            //}
            //移除“驾到”减益
            if (ytFargoConfig.Instance.NoBossDebuff)
            {
                player.buffImmune[ModContent.BuffType<DeviPresenceBuff>()] = true;
                player.buffImmune[ModContent.BuffType<AbomPresenceBuff>()] = true;
                player.buffImmune[ModContent.BuffType<MutantPresenceBuff>()] = true;
                player.buffImmune[ModContent.BuffType<CalamitousPresenceBuff>()] = true;
            }

            switch (type)
            {
                //鞭子增益可叠加
                case BuffID.ThornWhipPlayerBuff:
                case BuffID.SwordWhipPlayerBuff:
                case BuffID.ScytheWhipPlayerBuff:
                case BuffID.CoolWhipPlayerBuff:
                    if (player.Eternity().HasWhipBuff)
                    {
                        player.Eternity().HasWhipBuff = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}