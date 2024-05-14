using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalBuff
{
    public class MoltenEnchantFC : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            //移除【[熔岩魔石]会让玩家自身也每秒受到着火了减益的影响】
            if (player.HasEffect<MoltenEffect>())
            {
                player.buffImmune[BuffID.OnFire] = true;
                //Player.ClearBuff(BuffID.OnFire);
            }
        }
    }
}
