using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace yitangFargo.Global.Config
{
    public class ytFargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static ytFargoConfig Instance;

        [Header("FCItems")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool FCRecipes;

        [DefaultValue(false)]
        public bool OldEnchant;

        [Header("FCNPC")]
        [DefaultValue(false)]
        public bool FCNPC;

        [Header("FCBuff")]
        [DefaultValue(false)]
        public bool NullCurseBuff;

        [DefaultValue(false)]
        public bool NoBossDebuff;
    }
}
