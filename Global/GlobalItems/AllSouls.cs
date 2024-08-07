using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using yitangFargo.Common;
using yitangFargo.Common.Toggler;
using yitangFargo.Global.Config;
using yitangFargo.Content.Items.Calamity.Souls;
using yitangFargo.Content.Items.Accessories.Souls;

namespace yitangFargo.Global.GlobalItems
{
    public class AllSouls : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                FargoSoulsPlayer fargoPlayer = player.FargoSouls();
                //狂战士之魂
                if (item.type == ModContent.ItemType<BerserkerSoulOld>() || item.type == ModContent.ItemType<UniverseSoulOld>()
                    || item.type == ModContent.ItemType<EternitySoulOld>())
                {
                    //猎魂鲨齿项链
                    if (player.AddEffect<ReaperToothEffect>(item))
                    {
                        ModContent.GetInstance<ReaperToothNecklace>().UpdateAccessory(player, hideVisual);
                    }
                }

                //神枪手之魂
                if (item.type == ModContent.ItemType<SnipersSoulOld>() || item.type == ModContent.ItemType<UniverseSoulOld>()
                    || item.type == ModContent.ItemType<EternitySoulOld>())
                {
                    //虚无箭袋
                    if (player.AddEffect<QuiverofNihilityEffect>(item))
                    {
                        ModContent.GetInstance<QuiverofNihility>().UpdateAccessory(player, hideVisual);
                    }
                    //痴愚金龙干细胞
                    if (player.AddEffect<StemCellsEffect>(item))
                    {
                        ModContent.GetInstance<DynamoStemCells>().UpdateAccessory(player, hideVisual);
                    }
                }

				//巨像之魂
				if (item.type == ModContent.ItemType<ColossusSoulOld>() || item.type == ModContent.ItemType<DimensionSoulOld>()
					|| item.type == ModContent.ItemType<EternitySoulOld>())
				{
					//聚合之脑
					if (player.AddEffect<AmalgamEffect>(item))
					{
						ModContent.GetInstance<TheAmalgam>().UpdateAccessory(player, hideVisual);
					}
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
				if (item.type == ModContent.ItemType<SupersonicSoulOld>() || item.type == ModContent.ItemType<DimensionSoulOld>()
					|| item.type == ModContent.ItemType<EternitySoulOld>())
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
				if (item.type == ModContent.ItemType<TrawlerSoulOld>() || item.type == ModContent.ItemType<DimensionSoulOld>()
					|| item.type == ModContent.ItemType<EternitySoulOld>())
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
}