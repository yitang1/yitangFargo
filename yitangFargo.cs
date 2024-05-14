global using LumUtils = Luminance.Common.Utilities.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

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

        static float ColorTimer;

        public static Color EModeColor()
        {
            Color mutantColor = new(28, 222, 152);
            Color abomColor = new(255, 224, 53);
            Color deviColor = new(255, 51, 153);

            ColorTimer += 0.5f;

            if (ColorTimer >= 300)
                ColorTimer = 0;

            if (ColorTimer < 100)
                return Color.Lerp(mutantColor, abomColor, ColorTimer / 100);
            else if (ColorTimer < 200)
                return Color.Lerp(abomColor, deviColor, (ColorTimer - 100) / 100);
            else
                return Color.Lerp(deviColor, mutantColor, (ColorTimer - 200) / 100);
        }

    }
}