using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Accessories;
using CalamityMod.Projectiles.Melee;
using FargowiltasSouls;
using FargowiltasSouls.Content.Patreon.Duck;
using FargowiltasSouls.Content.Items.Weapons.SwarmDrops;
using FargowiltasSouls.Content.Patreon.GreatestKraken;
using FargowiltasSouls.Content.Items.Weapons.FinalUpgrades;
using FargowiltasSouls.Content.Patreon.DemonKing;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Content.Items;
using FargowiltasCrossmod.Core.Calamity;
using FargowiltasCrossmod.Core.Common;
using yitangFargo.Global.Config;
using yitangFargo.Common;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class CalamityFargoGlobalItem : GlobalItem
    {
        public static float FuckBalanceChange(Item item)
        {
            if (item.type == ModContent.ItemType<MechanicalLeashOfCthulhu>())
                return 0.5f;
            if (item.type == ModContent.ItemType<Blender>())
                return 1f;
            if (item.type == ModContent.ItemType<NukeFishron>() || item.type == ModContent.ItemType<GolemTome2>()
                || item.type == ModContent.ItemType<DestroyerGun2>() || item.type == ModContent.ItemType<RefractorBlaster2>())
                return 2f;
            //憎恶后武器
            if (DLCSets.GetValue(DLCSets.Items.AbomTierFargoWeapon, item.type))
                return 1.5f;
            //英灵后武器
            if (DLCSets.GetValue(DLCSets.Items.ChampionTierFargoWeapon, item.type))
            {
                return 0.8f;
            }

            //魔影系列物品
            if (item.type == ModContent.ItemType<IridescentExcalibur>()) return 0.5f;
            if (item.type == ModContent.ItemType<IllustriousKnives>()) return 0.8f;
            if (item.type == ModContent.ItemType<Azathoth>()) return 0.9f;
            if (item.type == ModContent.ItemType<RedSun>()) return 1.5f;
            if (item.type == ModContent.ItemType<SomaPrime>()) return 1.2f;
            if (item.type == ModContent.ItemType<Svantechnical>()) return 1.1f;
            if (item.type == ModContent.ItemType<Voidragon>()) return 1.1f;
            if (item.type == ModContent.ItemType<StaffofBlushie>()) return 0.7f;
            if (item.type == ModContent.ItemType<Eternity>()) return 0.4f;
            if (item.type == ModContent.ItemType<TheDanceofLight>()) return 0.5f;
            if (item.type == ModContent.ItemType<RainbowPartyCannon>()) return 0.6f;
            if (item.type == ModContent.ItemType<NanoblackReaper>()) return 0.4f;
            if (item.type == ModContent.ItemType<ScarletDevil>()) return 0.4f;
            if (item.type == ModContent.ItemType<TemporalUmbrella>()) return 0.35f;
            if (item.type == ModContent.ItemType<Endogenesis>()) return 0.35f;
            if (item.type == ModContent.ItemType<UniverseSplitter>()) return 0.5f;
            if (item.type == ModContent.ItemType<Metastasis>()) return 0.5f;
            if (item.type == ModContent.ItemType<FlamsteedRing>()) return 0.45f;
            if (item.type == ModContent.ItemType<AngelicAlliance>()) return 0.2f;
            if (item.type == ModContent.ItemType<ProfanedSoulCrystal>()) return 0.4f;
            if (item.type == ModContent.ItemType<Fabstaff>()) return 0.6f;

            //突变体后物品
            if (item.type == ModContent.ItemType<PhantasmalLeashOfCthulhu>()) return 0.2f;
            if (item.type == ModContent.ItemType<GuardianTome>()) return 0.2f;
            if (item.type == ModContent.ItemType<SlimeRain>()) return 0.08f;
            if (item.type == ModContent.ItemType<TheBiggestSting>()) return 0.3f;

            return 1;
        }

        public override void SetDefaults(Item item)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                float balance = FuckBalanceChange(item);
                if (balance < 1)
                {
                    item.damage = (int)(item.damage / balance);
                }
            }
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                //魔法飞刀
                if (item.type == ItemID.MagicDagger && !Main.hardMode)
                {
                    damage /= 0.51f;
                    item.shootSpeed = 30;
                }
                //肉后新三矿武器
                if (item.type == ItemID.CobaltSword || item.type == ItemID.PalladiumSword
                    || item.type == ItemID.MythrilSword || item.type == ItemID.OrichalcumSword)
                {
                    player.FargoSouls().AttackSpeed *= 1.5f;
                }
                if (item.type == ItemID.OrichalcumSword || item.type == ItemID.OrichalcumHalberd)
                {
                    damage /= 0.725f;
                }
            }
        }

		//钨魔石
        public static float TrueMeleeTungstenScaleUnNerf(Player player)
        {
            FargoSoulsPlayer fargoPlayer = player.FargoSouls();
            return player.HasEffect<TungstenEffect>() && fargoPlayer.ForceEffect<TungstenEnchant>() ? 1.6f : 1.6f;
        }
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                FargoSoulsPlayer fargoPlayer = player.FargoSouls();
                if (player.HasEffect<TungstenEffect>() && !item.IsAir && item.damage > 0
                    && (!item.noMelee || FargoGlobalItem.TungstenAlwaysAffects.Contains(item.type))
                    && item.pick == 0 && item.axe == 0 && item.hammer == 0)
                {
                    if (DLCSets.GetValue(CalDLCSets.Items.TungstenExclude, item.type))
                    {
                        float tungScale = 1f + (fargoPlayer.ForceEffect<TungstenEnchant>() ? 2f : 1f);
						scale *= tungScale;
					}
                    else if (item != null && item.DamageType.CountsAsClass(DamageClass.Melee))
                    {
                        scale *= TrueMeleeTungstenScaleUnNerf(player);
                    }
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            float balance = FuckBalanceChange(item);

            if (balance > 1)
            {
                tooltips.Replace($"Damage increased by {Math.Round((balance - 1) * 100)}%.", "");
            }
            else if (balance < 1)
            {
                tooltips.Replace($"Damage decreased by {Math.Round((1 - balance) * 100)}%.", "");
            }
        }
    }
}