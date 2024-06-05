using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Content.Items.Others.FuckFargoIcon
{
    public class OldVanillaEnchantIcon : ModItem
    {
        public override string Texture => "FargowiltasSouls/Content/Items/Accessories/Enchantments/AdamantiteEnchant";

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Red;
        }
    }
}
