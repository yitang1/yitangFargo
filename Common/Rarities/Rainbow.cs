using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace yitangFargo.Common.Rarities
{
	public class Rainbow : ModRarity
	{
		//彩虹色稀有度
		public override Color RarityColor => new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
	}
}