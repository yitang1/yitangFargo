using Terraria.ModLoader;
using FargowiltasSouls.Core.Toggler.Content;
using yitangFargo.Content.Items.Calamity.Forces;
using yitangFargo.Content.Items.Calamity.Souls;
using yitangFargo.Content.Items.Fargo;

namespace yitangFargo.Common.Toggler
{
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
