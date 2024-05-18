using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;
using CalamityMod.Items.Accessories;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using yitangFargo.Content.Items.Accessories.Souls;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Global.GlobalItems
{
    public class AllSouls : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            //巨像之魂
            if (item.type == ModContent.ItemType<ColossusSoulNew>()
                || item.type == ModContent.ItemType<DimensionSoulNew>()
                || item.type == ModContent.ItemType<EternitySoulNew>())
            {
                //阿斯加德之庇护
                if (player.AddEffect<AsgardianAegisEffect>(item))
                {
                    ModContent.GetInstance<AsgardianAegis>().UpdateAccessory(player, hideVisual);
                    player.FargoSouls().HasDash = true;
                }
            }
            //捕鱼之魂
            if (item.type == ModContent.ItemType<TrawlerSoulNew>()
                || item.type == ModContent.ItemType<DimensionSoulNew>()
                || item.type == ModContent.ItemType<EternitySoulNew>())
            {
                //深渊潜游服
                if (player.AddEffect<AbyssalDivingSuitEffect>(item))
                {
                    ModContent.GetInstance<AbyssalDivingSuit>().UpdateAccessory(player, hideVisual);
                }
            }
        }
    }
}
