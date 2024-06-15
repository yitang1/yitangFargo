using Terraria;
using Terraria.ModLoader;

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
    }
}