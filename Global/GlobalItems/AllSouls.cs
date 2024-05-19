using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;
using CalamityMod.Items.Accessories;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using yitangFargo.Content.Items.Accessories.Souls;
using yitangFargo.Common.Toggler;
using FargowiltasSouls.Core.ModPlayers;

namespace yitangFargo.Global.GlobalItems
{
    public class AllSouls : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            FargoSoulsPlayer fargoPlayer = player.FargoSouls();
            //巨像之魂
            if (item.type == ModContent.ItemType<ColossusSoulNew>()
                || item.type == ModContent.ItemType<DimensionSoulNew>()
                || item.type == ModContent.ItemType<EternitySoulNew>())
            {
                //阿斯加德之庇护
                if (player.AddEffect<AsgardianAegisEffect>(item))
                {
                    ModContent.GetInstance<AsgardianAegis>().UpdateAccessory(player, hideVisual);
                    fargoPlayer.HasDash = true;
                }
                //神之壁垒
                if (player.AddEffect<RampartofDeitiesEffect>(item))
                {
                    ModContent.GetInstance<RampartofDeities>().UpdateAccessory(player, hideVisual);
                }
            }

            //超音速之魂
            if (item.type == ModContent.ItemType<SupersonicSoulNew>()
                || item.type == ModContent.ItemType<DimensionSoulNew>()
                || item.type == ModContent.ItemType<EternitySoulNew>())
            {
                //至高统治之盾
                if (player.AddEffect<ShieldHighRulerEffect>(item))
                {
                    ModContent.GetInstance<ShieldoftheHighRuler>().UpdateAccessory(player, hideVisual);
                    fargoPlayer.HasDash = true;
                }
                //斯塔提斯的虚空饰带
                if (player.AddEffect<StatisVoidSashEffect>(item))
                {
                    ModContent.GetInstance<StatisVoidSash>().UpdateAccessory(player, hideVisual);
                    fargoPlayer.HasDash = true;
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
