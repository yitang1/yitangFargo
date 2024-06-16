using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using yitangFargo.Common;
using yitangFargo.Global.Config;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;

namespace yitangFargo.Content.Items.Accessories.Enchantments
{
    public class MeteorEnchantNew : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<MeteorEnchant>() && ytFargoConfig.Instance.OldVanillaEnchant)
            {
                player.AddEffect<MeteorEffectNew>(item);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            if (item.type == ModContent.ItemType<MeteorEnchant>())
            {
                if (player.HasEffect<MeteorEffectNew>() && player.HasEffect<MeteorEffect>())
                {
                    tooltips.ReplaceText("[MeteorDouble]", Language.GetTextValue("Mods.yitangFargo.OtherItems.EnchantDouble"));
                    tooltips.ReplaceText("[MeteorOld]", "");
                    tooltips.ReplaceText("[MeteorNew]", "");
                }
                else if (player.HasEffect<MeteorEffect>() || !ytFargoConfig.Instance.OldVanillaEnchant)
				{
                    tooltips.ReplaceText("[MeteorNew]", Language.GetTextValue("Mods.yitangFargo.OtherItems.MeteorEnchant.New"));
                    tooltips.ReplaceText("[MeteorOld]", "");
                    tooltips.ReplaceText("[MeteorDouble]", "");
                }
                else
                {
                    tooltips.ReplaceText("[MeteorOld]", Language.GetTextValue("Mods.yitangFargo.OtherItems.MeteorEnchant.Old"));
                    tooltips.ReplaceText("[MeteorNew]", "");
                    tooltips.ReplaceText("[MeteorDouble]", "");
                }
            }
        }
    }

    public class MeteorEffectNew : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<CosmoHeader>();
        public override int ToggleItemType => ModContent.ItemType<MeteorEnchant>();
        public override bool IgnoresMutantPresence => true;
        public override bool ExtraAttackEffect => true;

        public override void PostUpdateEquips(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.HasEffect<MeteorEffectNew>())
            {
                FargoSoulsPlayer modPlayerF = player.FargoSouls();
                yitangFargoPlayer modPlayerY = player.yitangFargo();
                bool forceEffectMeteor = modPlayerF.ForceEffect<MeteorEnchant>();

                int damage = forceEffectMeteor ? 50 : 20;
                if (modPlayerY.MeteorShower)
                {
                    if (modPlayerY.MeteorTimer % (forceEffectMeteor ? 2 : 4) == 0)
                    {
                        Vector2 pos = new Vector2(player.Center.X + Main.rand.NextFloat(-1000f, 1000f), player.Center.Y - 1000f);
                        Vector2 vel = new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(8f, 12f));
                        if (Main.rand.NextBool())
                        {
                            List<NPC> targetables = (from n in Main.npc
                                                     where n.CanBeChasedBy(null, false) && n.Distance(player.Center) < 900f
                                                     select n).ToList<NPC>();
                            if (targetables.Count > 0)
                            {
                                NPC target = targetables[Main.rand.Next(targetables.Count)];
                                pos.X = target.Center.X + Main.rand.NextFloat(-32f, 32f);
                                Vector2 predictive = Main.rand.NextFloat(10f, 30f) * target.velocity;
                                pos.X += predictive.X;
                                Vector2 targetPos = target.Center + predictive;
                                if (pos.Y < targetPos.Y)
                                {
                                    Vector2 accurateVel = vel.Length() * pos.DirectionTo(targetPos);
                                    vel = Vector2.Lerp(vel, accurateVel, Main.rand.NextFloat());
                                }
                            }
                        }
                        Projectile.NewProjectile(GetSource_EffectItem(player), pos, vel, Main.rand.Next(424, 427), yitangFargoUtils.HighestDamageTypeScaling(player, damage), 0.5f, player.whoAmI, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f, 0f);
                    }
                    int num = modPlayerY.MeteorTimer - 1;
                    modPlayerY.MeteorTimer = num;
                    if (num <= 0)
                    {
                        modPlayerY.MeteorShower = false;
                        modPlayerY.MeteorCD = (forceEffectMeteor ? 240 : 480);
                        return;
                    }
                }
                else
                {
                    modPlayerY.MeteorTimer = 150 + 450 / (forceEffectMeteor ? 1 : 2);
                    if (modPlayerF.WeaponUseTimer > 0)
                    {
                        int num = modPlayerY.MeteorCD - 1;
                        modPlayerY.MeteorCD = num;
                        if (num <= 0)
                        {
                            modPlayerY.MeteorShower = true;
                            return;
                        }
                    }
                    else if (modPlayerY.MeteorCD < 150)
                    {
                        modPlayerY.MeteorCD++;
                    }
                }
            }
        }
    }
}