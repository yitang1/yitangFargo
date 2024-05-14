using FargowiltasSouls.Core.AccessoryEffectSystem;
using Terraria;
using Terraria.ModLoader;
using yitangFargo.Content.Items.Accessories.Enchantments;

namespace yitangFargo.Common
{
    public class yitangFargoNPC : GlobalNPC
    {
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            Player player = Main.player[Main.myPlayer];
            //山铜魔石
            if (player.HasEffect<OrichalcumEffectNew>() && npc.lifeRegen < 0)
            {
                OrichalcumEffectNew.OriDotModifier(npc, player, ref damage);
            }
        }
    }
}
