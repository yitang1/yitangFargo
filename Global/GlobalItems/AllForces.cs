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
				player.AddEffect<AdamantiteEffectOld>(item);
				player.AddEffect<OrichalcumEffectOld>(item);
				player.AddEffect<MythrilEffectOld>(item);
			}
			//自然之力 添加旧版猩红魔石的效果
			if (item.type == ModContent.ItemType<NatureForce>())
			{
				player.AddEffect<CrimsonEffectOld>(item);
			}
			//心灵之力 添加旧版提基魔石、远古神圣魔石的效果
			if (item.type == ModContent.ItemType<SpiritForce>())
			{
				player.AddEffect<TikiEffectOld>(item);
				player.AddEffect<AncientHallowShieldOld>(item);
				player.AddEffect<AncientHallowMinionOld>(item);
			}
			//暗影之力 添加旧版忍者魔石的效果
			if (item.type == ModContent.ItemType<ShadowForce>())
			{
				player.AddEffect<NinjaEffectOld>(item);
			}
			//宇宙之力 添加旧版流星魔石的效果
			if (item.type == ModContent.ItemType<CosmoForce>())
			{
				player.AddEffect<MeteorEffectOld>(item);
			}
			//泰拉之魂和永恒之魂 添加旧版魔石的效果
			if (item.type == ModContent.ItemType<TerrariaSoulOld>() || item.type == ModContent.ItemType<EternitySoulOld>())
			{
				player.AddEffect<AdamantiteEffectOld>(item);
				player.AddEffect<NinjaEffectOld>(item);
				player.AddEffect<CrimsonEffectOld>(item);
				player.AddEffect<TikiEffectOld>(item);
				player.AddEffect<AncientHallowShieldOld>(item);
				player.AddEffect<AncientHallowMinionOld>(item);
				player.AddEffect<MeteorEffectOld>(item);
				player.AddEffect<OrichalcumEffectOld>(item);
				player.AddEffect<MythrilEffectOld>(item);
			}
		}
	}
}