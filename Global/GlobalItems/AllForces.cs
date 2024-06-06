using Terraria;
using Terraria.ModLoader;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using yitangFargo.Common;
using yitangFargo.Content.Items.Accessories.Enchantments;
using yitangFargo.Content.Items.Accessories.Souls;

namespace yitangFargo.Global.GlobalItems
{
    public class AllForces : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            yitangFargoPlayer modPlayerY = player.yitangFargo();
            //大地之力 + 添加旧版精金魔石、山铜魔石、秘银魔石的效果
            if (item.type == ModContent.ItemType<EarthForce>())
            {
                player.AddEffect<AdamantiteEffectNew>(item);
                player.AddEffect<OrichalcumEffectNew>(item);
                player.AddEffect<MythrilEffectNew>(item);
            }
            //自然之力 添加旧版猩红魔石的效果
            if (item.type == ModContent.ItemType<NatureForce>())
            {
                player.AddEffect<CrimsonEffectNew>(item);
            }
            //心灵之力 添加旧版提基魔石、远古神圣魔石的效果
            if (item.type == ModContent.ItemType<SpiritForce>())
            {
                player.AddEffect<TikiEffectNew>(item);
                player.AddEffect<AncientHallowShieldNew>(item);
                player.AddEffect<AncientHallowMinionNew>(item);
            }
            //暗影之力 添加旧版忍者魔石的效果
            if (item.type == ModContent.ItemType<ShadowForce>())
            {
                player.AddEffect<NinjaEffectNew>(item);
            }
            //宇宙之力 添加旧版流星魔石的效果
            if (item.type == ModContent.ItemType<CosmoForce>())
            {
                player.AddEffect<MeteorEffectNew>(item);
            }
            //泰拉之魂和永恒之魂 添加旧版魔石的效果
            if (item.type == ModContent.ItemType<TerrariaSoulNew>() || item.type == ModContent.ItemType<EternitySoulNew>())
            {
                player.AddEffect<AdamantiteEffectNew>(item);
                player.AddEffect<NinjaEffectNew>(item);
                player.AddEffect<CrimsonEffectNew>(item);
                player.AddEffect<TikiEffectNew>(item);
                player.AddEffect<AncientHallowShieldNew>(item);
                player.AddEffect<AncientHallowMinionNew>(item);
                player.AddEffect<MeteorEffectNew>(item);
                player.AddEffect<OrichalcumEffectNew>(item);
                player.AddEffect<MythrilEffectNew>(item);
            }
        }
    }
}