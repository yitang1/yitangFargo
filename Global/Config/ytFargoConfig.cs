using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace yitangFargo.Global.Config
{
    public class ytFargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        public static ytFargoConfig Instance;

		[Header("FCRecipes")]
		[ReloadRequired]
		[DefaultValue(false)]
		public bool FargoSoulsRecipe { get; set; }

		[ReloadRequired]
		[DefaultValue(true)]
		public bool CalamityFargoRecipe { get; set; }

		[Header("FCBalance")]
		[ReloadRequired]
		[DefaultValue(true)]
		public bool FuckBalance { get; set; }

		[Header("FCItems")]
		[DefaultValue(true)]
		public bool OldVanillaEnchant { get; set; }

		[ReloadRequired]
		[DefaultValue(true)]
		public bool OldCalamityEnchant { get; set; }

		[DefaultValue(false)]
		public bool FullCalamityEnchant { get; set; }

		[Header("FCNPC")]
		[DefaultValue(true)]
		public bool FCNPC { get; set; }

		[Header("FCBuff")]
		[DefaultValue(false)]
		public bool NullCurseBuff { get; set; }

		[DefaultValue(false)]
		public bool NoBossDebuff { get; set; }

	}
}