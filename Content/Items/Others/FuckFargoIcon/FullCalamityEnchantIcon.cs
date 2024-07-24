using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Content.Items.Others.FuckFargoIcon
{
	public class FullCalamityEnchantIcon : ModItem
	{
		public override string Texture => "yitangFargo/Content/Items/Calamity/Enchantments/AuricEnchant";

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.White;
		}
	}
}
