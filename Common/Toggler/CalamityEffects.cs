using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;

namespace yitangFargo.Common.Toggler
{
    //阿斯加德之庇护
    public class AsgardianAegisEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ColossusHeader>();
        public override int ToggleItemType => ModContent.ItemType<AsgardianAegis>();
        public override bool IgnoresMutantPresence => true;
    }
    //深渊潜游服
    public class AbyssalDivingSuitEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<TrawlerHeader>();
        public override int ToggleItemType => ModContent.ItemType<AbyssalDivingSuit>();
        public override bool IgnoresMutantPresence => true;
    }
}
