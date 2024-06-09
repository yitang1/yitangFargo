using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Accessories;
using FargowiltasSouls.Content.Patreon.Duck;
using FargowiltasSouls.Content.Items.Weapons.SwarmDrops;
using FargowiltasSouls.Content.Patreon.GreatestKraken;
using FargowiltasSouls.Content.Items.Weapons.FinalUpgrades;
using FargowiltasSouls.Content.Patreon.DemonKing;
using yitangFargo.Global.Config;
using yitangFargo.Common;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items;
using CalamityMod.Projectiles.Melee;
using FargowiltasCrossmod.Core.Calamity;
using FargowiltasCrossmod.Core.Common;
using CalamityMod;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalItem
{
    public class CalamityFargoGlobalItem : GlobalItem
    {
        public static float FuckBalanceChange(Item item)
        {
            if (item.type == ItemType<MechanicalLeashOfCthulhu>())
                return 0.5f;
            if (item.type == ItemType<Blender>())
                return 1f;
            if (item.type == ItemType<NukeFishron>() || item.type == ItemType<GolemTome2>()
                || item.type == ItemType<DestroyerGun2>() || item.type == ItemType<RefractorBlaster2>())
            {
                return 2f;
            }
            //憎恶后武器
            if (DLCSets.GetValue(DLCSets.Items.AbomTierFargoWeapon, item.type))
                return 1.5f;
            //英灵后武器
            if (DLCSets.GetValue(DLCSets.Items.ChampionTierFargoWeapon, item.type))
            {
                return 0.8f;
            }

            //魔影系列物品
            if (item.type == ItemType<IridescentExcalibur>()) return 0.5f;
            if (item.type == ItemType<IllustriousKnives>()) return 0.8f;
            if (item.type == ItemType<Azathoth>()) return 0.9f;
            if (item.type == ItemType<RedSun>()) return 1.5f;
            if (item.type == ItemType<SomaPrime>()) return 1.2f;
            if (item.type == ItemType<Svantechnical>()) return 1.1f;
            if (item.type == ItemType<Voidragon>()) return 1.1f;
            if (item.type == ItemType<StaffofBlushie>()) return 0.7f;
            if (item.type == ItemType<Eternity>()) return 0.4f;
            if (item.type == ItemType<TheDanceofLight>()) return 0.5f;
            if (item.type == ItemType<RainbowPartyCannon>()) return 0.6f;
            if (item.type == ItemType<NanoblackReaper>()) return 0.4f;
            if (item.type == ItemType<ScarletDevil>()) return 0.4f;
            if (item.type == ItemType<TemporalUmbrella>()) return 0.35f;
            if (item.type == ItemType<Endogenesis>()) return 0.35f;
            if (item.type == ItemType<UniverseSplitter>()) return 0.5f;
            if (item.type == ItemType<Metastasis>()) return 0.5f;
            if (item.type == ItemType<FlamsteedRing>()) return 0.45f;
            if (item.type == ItemType<AngelicAlliance>()) return 0.2f;
            if (item.type == ItemType<ProfanedSoulCrystal>()) return 0.4f;
            if (item.type == ItemType<Fabstaff>()) return 0.6f;

            //突变体后物品
            if (item.type == ItemType<PhantasmalLeashOfCthulhu>()) return 0.2f;
            if (item.type == ItemType<GuardianTome>()) return 0.2f;
            if (item.type == ItemType<SlimeRain>()) return 0.08f;
            if (item.type == ItemType<TheBiggestSting>()) return 0.3f;

            return 1;
        }

        public override void SetDefaults(Item item)
        {
            if (ytFargoConfig.Instance.FuckBalance)
            {
                float balance = FuckBalanceChange(item);
                if (balance != 1)
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
            }
        }

        public static float TrueMeleeTungstenScaleNerf(Player player)
        {
            FargoSoulsPlayer fargoPlayer = player.FargoSouls();
            return player.HasEffect<TungstenEffect>() && fargoPlayer.ForceEffect<TungstenEnchant>() ? 2f : 1.5f;
        }
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            FargoSoulsPlayer fargoPlayer = player.FargoSouls();
            if (player.HasEffect<TungstenEffect>() && !item.IsAir && item.damage > 0
                && (!item.noMelee || FargoGlobalItem.TungstenAlwaysAffects.Contains(item.type))
                && item.pick == 0 && item.axe == 0 && item.hammer == 0)
            {
                if (DLCSets.GetValue(CalDLCSets.Items.TungstenExclude, item.type))
                {
                    float tungScale = 1f + (fargoPlayer.ForceEffect<TungstenEnchant>() ? 2f : 1f);
                    //scale /= tungScale;
                }
                else if (item != null && (item.DamageType == GetInstance<TrueMeleeDamageClass>()
                    || item.DamageType == GetInstance<TrueMeleeNoSpeedDamageClass>()))
                {
                    scale *= TrueMeleeTungstenScaleNerf(player);
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