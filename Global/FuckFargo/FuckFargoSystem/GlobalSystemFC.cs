using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;
using FargowiltasSouls.Core.Systems;

namespace yitangFargo.Global.FuckFargo.FuckFargoSystem
{
    public class GlobalSystemFC : ModSystem
    {
        public static EModeChange EmodeBalance(ref Item item, ref float balanceNumber, ref string[] balanceTextKeys, ref string extra)
        {
            switch (item.type)
            {
                //恶魔锄刀↓
                case ItemID.DemonScythe:
                    {
                        if (!NPC.downedBoss2)
                        {
                            balanceTextKeys = new string[] { "DemonScythe", "DamageNoTooltip", "SpeedNoTooltip" };
                            balanceNumber = 0.6f;
                            return EModeChange.Nerf;
                        }
                        return EModeChange.None;
                    }
                //剃刀松↓
                case ItemID.Razorpine:
                    balanceTextKeys = new string[] { "Damage" };
                    balanceNumber = 0.8f;
                    return EModeChange.Nerf;
                //暴雪法杖↓
                case ItemID.BlizzardStaff:
                    balanceTextKeys = new string[] { "Damage", "Speed" };
                    balanceNumber = 0.7f;
                    return EModeChange.Nerf;
                //魔法飞刀↓
                case ItemID.MagicDagger:
                    {
                        if (!Main.hardMode)
                        {
                            balanceTextKeys = new string[] { "Damage" };
                            balanceNumber = 0.5f;
                            return EModeChange.Nerf;
                        }
                        return EModeChange.None;
                    }
                //月亮传送门法杖↓
                case ItemID.MoonlordTurretStaff:
                    balanceTextKeys = new string[] { "Damage" };
                    balanceNumber = 0.5f;
                    return EModeChange.Nerf;
                //七彩水晶法杖↓
                case ItemID.RainbowCrystalStaff:
                    balanceTextKeys = new string[] { "Damage" };
                    balanceNumber = 0.6f;
                    return EModeChange.Nerf;
                default:
                    return EModeChange.None;
            }
        }

        public static void BalanceWeaponStats(Player player, Item item, ref StatModifier damage)
        {
            if (!WorldSavingSystem.EternityMode)
                return;
            string extra = string.Empty;
            float balanceNumber = -1;
            string[] balanceTextKeys = null;
            EmodeBalance(ref item, ref balanceNumber, ref balanceTextKeys, ref extra);
            if (balanceTextKeys != null)
            {
                for (int i = 0; i < balanceTextKeys.Length; i++)
                {
                    switch (balanceTextKeys[i])
                    {
                        case "Damage":
                        case "DamageNoTooltip":
                            {
                                damage /= balanceNumber;
                                break;
                            }
                        case "Speed":
                        case "SpeedNoTooltip":
                            {
                                player.FargoSouls().AttackSpeed /= balanceNumber;
                                break;
                            }

                    }
                }
            }
        }
        public enum EModeChange
        {
            None,
            Nerf,
            Buff,
            Neutral
        }
    }
}
