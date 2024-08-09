using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalBuff
{
    public class MoltenEnchantFC : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            //熔岩魔石 免疫着火了减益
            if (item.type == ModContent.ItemType<MoltenEnchant>())
            {
                player.buffImmune[BuffID.OnFire] = true;
                //Player.ClearBuff(BuffID.OnFire);
            }
        }
    }
}