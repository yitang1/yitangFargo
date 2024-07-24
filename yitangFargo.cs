global using LumUtils = Luminance.Common.Utilities.Utilities;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace yitangFargo
{
    public class yitangFargo : Mod
    {
        public static Item CustomPrice(int type, int price)
        {
            var item = new Item();
            item.SetDefaults(type);
            item.shopCustomPrice = price;
            return item;
        }
    }
}