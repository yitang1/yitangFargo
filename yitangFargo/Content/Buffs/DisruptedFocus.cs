using Terraria;
using Terraria.ModLoader;
using yitangFargo.Common;

namespace yitangFargo.Content.Buffs
{
    public class DisruptedFocus : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.yitangFargo().DisruptedFocus = true;
        }
    }
}