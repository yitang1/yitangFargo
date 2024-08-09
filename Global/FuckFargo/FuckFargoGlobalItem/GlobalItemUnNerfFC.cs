using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Armor;
using FargowiltasSouls.Content.Items.Accessories.Essences;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class GlobalItemUnNerfFC : GlobalItem
    {
		public static float FuckFargoSoulsDamage(Item item)
		{
			if (item.type == ItemID.StarCannon) return 0.27f;
			if (item.type == ItemID.DemonScythe && !NPC.downedBoss2) return 0.56f;
			if (item.type == ItemID.DemonScythe && NPC.downedBoss2) return 0.94f;
			if (item.type == ItemID.ObsidianSwordfish) return 0.8f;
			if (item.type == ItemID.MagicDagger && !Main.hardMode) return 0.54f;
			if (item.type == ItemID.MagicDagger && Main.hardMode) return 0.81f;
			if (item.type == ItemID.Razorpine) return 0.66f;
			if (item.type == ItemID.BlizzardStaff) return 0.49f;
			if (item.type == ItemID.Uzi) return 0.86f;
			if (item.type == ItemID.DD2SquireBetsySword) return 0.583f;
			if (item.type == ItemID.MoonlordTurretStaff) return 0.25f;
			if (item.type == ItemID.RainbowCrystalStaff) return 0.6f;

			return 1f;
		}
		public static float FuckFargoSoulsSpeed(Item item)
		{
			if (item.type == ItemID.DemonScythe && !NPC.downedBoss2) return 0.6f;
			if (item.type == ItemID.MagicDagger && !Main.hardMode) return 0.66f;
			if (item.type == ItemID.FetidBaghnakhs) return 0.75f;
			if (item.type == ItemID.BlizzardStaff) return 0.7f;

			return 1f;
		}
		public static void BalanceWeaponStats(Player player, Item item, ref StatModifier damage)
		{
			float balanceDamage = FuckFargoSoulsDamage(item);
			if (balanceDamage < 1)
			{
				damage /= balanceDamage;
			}
			float balanceSpeed = FuckFargoSoulsSpeed(item);
			if (balanceSpeed < 1)
			{
				player.FargoSouls().AttackSpeed /= balanceSpeed;
			}
		}

		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            //术士精华
            if (item.type == ModContent.ItemType<OccultistsEssence>())
            {
                player.GetCritChance(DamageClass.Summon) += 5;
            }
        }

        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            //水矢的射弹
            if (!NPC.downedBoss3 && item.type == ItemID.WaterBolt)
            {
                if (type == ProjectileID.WaterGun)
                {
                    type = ProjectileID.WaterBolt;
                    damage = 19;
                }
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ModContent.ItemType<GaiaHelmet>())
            {
                player.maxTurrets += 1;
            }
        }
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ModContent.ItemType<GaiaHelmet>()
                && body.type == ModContent.ItemType<GaiaPlate>()
                && legs.type == ModContent.ItemType<GaiaGreaves>())
            {
                return "Gaia";
            }
            return "";
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            //盖亚盔甲 套装效果
            if (set == "Gaia")
            {
                player.maxTurrets += 4;
            }
        }
        //奇怪，Fargo魂1.6.10.2版本，为什么传送杖的扣血惩罚又都没有了……
        //public override bool CanUseItem(Item item, Player player)
        //{
        //    //混沌传送杖
        //    if (item.type == ItemID.RodofDiscord && player.HasBuff(BuffID.ChaosState))
        //    {
        //        player.Heal(player.statLifeMax2 / 14);
        //    }
        //    //和谐杖
        //    if (item.type == ItemID.RodOfHarmony && LumUtils.AnyBosses())
        //    {
        //        player.Heal(player.statLifeMax2 / 7);
        //    }
        //    return base.CanUseItem(item, player);
        //}
    }
}