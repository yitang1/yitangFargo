using Terraria;
using Terraria.ModLoader;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class SpiderEnchantFC : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            FargoSoulsPlayer modPlayerF = player.FargoSouls();
            //蜘蛛魔石的仆从暴击伤害变成2倍
            if (player.HasEffect<SpiderEffect>())
            {
                player.GetModPlayer<yitangFargoPlayer>().MinionCritsYT = true;
            }
            //蜘蛛魔石的仆从造成酸性毒液减益
            if (modPlayerF.ForceEffect<SpiderEnchant>())
            {
                player.GetModPlayer<yitangFargoPlayer>().VenomMinions = true;
            }
        }
    }
}