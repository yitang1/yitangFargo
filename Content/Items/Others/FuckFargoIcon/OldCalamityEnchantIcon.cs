using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Content.Items.Others.FuckFargoIcon
{
    public class OldCalamityEnchantIcon : ModItem
    {
        public override string Texture => "yitangFargo/Content/Items/Calamity/Enchantments/AstralEnchant";

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.White;
        }
    }
}
