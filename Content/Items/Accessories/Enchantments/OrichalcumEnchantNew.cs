using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;
using FargowiltasSouls;
using FargowiltasSouls.Content.Buffs.Souls;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using yitangFargo.Common;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class OrichalcumEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<OrichalcumEnchant>() && ytFargoConfig.Instance.OldVanillaEnchant)
            {
                player.AddEffect<OrichalcumEffectNew>(item);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<OrichalcumEnchant>())
            {
                if (player.HasEffect<OrichalcumEffectNew>() && player.HasEffect<OrichalcumEffect>())
                {
                    tooltips.ReplaceText("[OrichalcumDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[OrichalcumOld]", "");
                    tooltips.ReplaceText("[OrichalcumNew]", "");
                }
                else if (player.HasEffect<OrichalcumEffect>())
                {
                    tooltips.ReplaceText("[OrichalcumNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.OrichalcumEnchant.New"));
                    tooltips.ReplaceText("[OrichalcumOld]", "");
                    tooltips.ReplaceText("[OrichalcumDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[OrichalcumOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.OrichalcumEnchant.Old"));
                    tooltips.ReplaceText("[OrichalcumNew]", "");
                    tooltips.ReplaceText("[OrichalcumDouble]", "");
                }
            }
        }
    }

    public class OrichalcumEffectNew : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<EarthHeader>();
        public override int ToggleItemType => ModContent.ItemType<OrichalcumEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;

        public static void OriDotModifier(NPC npc, Player player, ref int damage)
        {
            float multiplier = 3f;

            if (player.FargoSouls().ForceEffect<OrichalcumEnchant>())
            {
                multiplier = 5f;
            }

            npc.lifeRegen = (int)(npc.lifeRegen * multiplier);
            damage = (int)(damage * multiplier);

            if (npc.daybreak)
            {
                npc.lifeRegen /= 2;
                damage /= 2;
            }
        }

        public override void PostUpdateEquips(Player player)
        {
            player.onHitPetal = true;
        }

        public override void OnHitNPCWithProj(Player player, Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (proj.type == ProjectileID.FlowerPetal)
            {
                target.AddBuff(ModContent.BuffType<OriPoisonBuff>(), 300);
                target.immune[proj.owner] = 2;
            }
        }
    }
}