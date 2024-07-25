using Terraria.ModLoader;
using FargowiltasSouls.Core.Toggler.Content;
using yitangFargo.Content.Items.Calamity.Forces;
using yitangFargo.Content.Items.Calamity.Souls;
using FargowiltasSouls.Content.Items.Accessories.Souls;

namespace yitangFargo.Common.Toggler
{
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
    public class MiracleHeader : EnchantHeader
    {
        public override int Item => ModContent.ItemType<MiracleForce>();
        public override float Priority => 20.6f;
    }
}