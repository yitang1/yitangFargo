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
        public bool FargoSoulsRecipe;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool CalamityFargoRecipe;

        [Header("FCBalance")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool FuckBalance;

        [Header("FCItems")]
        [DefaultValue(true)]
        public bool OldVanillaEnchant;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool OldCalamityEnchant;

        [Header("FCNPC")]
        [DefaultValue(true)]
        public bool FCNPC;

        [Header("FCBuff")]
        [DefaultValue(false)]
        public bool NullCurseBuff;

        [DefaultValue(false)]
        public bool NoBossDebuff;

    }
}