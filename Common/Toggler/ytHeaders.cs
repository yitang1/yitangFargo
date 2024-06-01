using Terraria.ModLoader;
using FargowiltasSouls.Core.Toggler.Content;
using yitangFargo.Content.Items.Calamity.Forces;
using yitangFargo.Content.Items.Calamity.Souls;
using yitangFargo.Content.Items.Fargo;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using yitangFargo.Content.Items.Accessories.Souls;

namespace yitangFargo.Common.Toggler
{
    //狂战士之魂
    public class CalamityBerserkerHeader : SoulHeader
    {
        public override int Item => ModContent.ItemType<BerserkerSoulNew>();
        public override float Priority => 2.11f;
    }
    //神枪手之魂
    public class CalamitySnipersHeader : SoulHeader
    {
        public override int Item => ModContent.ItemType<SnipersSoulNew>();
        public override float Priority => 2.12f;
    }
    public class BrimstoneWitchHeader : SoulHeader
    {
        public override int Item => ModContent.ItemType<BrandoftheWitchNew>();
        public override float Priority => 20.1f;
    }
    public class AnnihilationHeader : EnchantHeader
    {
        public override int Item => ModContent.ItemType<AnnihilationForce>();
        public override float Priority => 20.2f;
    }
    public class DesolationHeader : EnchantHeader
    {
        public override int Item => ModContent.ItemType<DesolationForce>();
        public override float Priority => 20.3f;
    }
    public class DevastationHeader : EnchantHeader
    {
        public override int Item => ModContent.ItemType<DevastationForce>();
        public override float Priority => 20.4f;
    }
    public class ExaltationHeader : EnchantHeader
    {
        public override int Item => ModContent.ItemType<ExaltationForce>();
        public override float Priority => 20.5f;
    }
    public class EternityHeader : EnchantHeader
    {
        public override int Item => ModContent.ItemType<EternityForce>();
        public override float Priority => 21.1f;
    }
    //public class PetHeader : EnchantHeader
    //{
    //    public override int Item => ModContent.ItemType<VoidSoul>();
    //    public override float Priority => 21.2f;
    //}
}