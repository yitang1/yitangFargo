using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Souls;

namespace yitangFargo.Common.Toggler
{
    //虚无箭袋
    public class QuiverofNihilityEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<CalamitySnipersHeader>();
        public override int ToggleItemType => ModContent.ItemType<QuiverofNihility>();
        public override bool IgnoresMutantPresence => true;
    }
    //痴愚金龙干细胞
    public class StemCellsEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<CalamitySnipersHeader>();
        public override int ToggleItemType => ModContent.ItemType<DynamoStemCells>();
        public override bool IgnoresMutantPresence => true;
    }
    //阿斯加德之庇护
    public class AsgardianAegisEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ColossusHeader>();
        public override int ToggleItemType => ModContent.ItemType<AsgardianAegis>();
        public override bool IgnoresMutantPresence => true;
    }
    //神之壁垒
    public class RampartofDeitiesEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<ColossusHeader>();
        public override int ToggleItemType => ModContent.ItemType<RampartofDeities>();
        public override bool IgnoresMutantPresence => true;
    }
    //至高统治之盾
    public class ShieldHighRulerEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<SupersonicHeader>();
        public override int ToggleItemType => ModContent.ItemType<ShieldoftheHighRuler>();
        public override bool IgnoresMutantPresence => true;
    }
    //斯塔提斯的虚空饰带
    public class StatisVoidSashEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<SupersonicHeader>();
        public override int ToggleItemType => ModContent.ItemType<StatisVoidSash>();
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
