using Terraria;
using Terraria.ModLoader;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class HallowEnchantFC : GlobalItem
    {
        //神圣魔石拥有神圣套的闪避效果
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (player.HasEffect<HallowEffect>())
            {
                player.onHitDodge = true;
            }
        }
    }
}