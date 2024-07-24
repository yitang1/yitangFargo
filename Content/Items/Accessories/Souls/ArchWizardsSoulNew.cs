using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using yitangFargo.Global.Config;
using CalamityMod.Items.Weapons.Magic;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class ArchWizardsSoulNew : BaseSoul
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public static readonly Color ItemColor = new(255, 83, 255);
        protected override Color? nameColor => ItemColor;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.FargoSouls().MagicSoul = true;
            player.GetDamage(DamageClass.Magic) += .3f;
            player.GetCritChance(DamageClass.Magic) += 15;
            player.statManaMax2 += 200;
            //魔力花
            player.manaFlower = true;
            //星星斗篷
            player.manaMagnet = true;
            player.magicCuffs = true;
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient<ApprenticesEssence>()
                    .AddIngredient(ItemID.ManaCloak)
                    .AddIngredient(ItemID.MagnetFlower)
                    .AddIngredient(ItemID.ArcaneFlower)
                    .AddIngredient(ItemID.CelestialCuffs)
                    .AddIngredient(ItemID.CelestialEmblem)
                    .AddIngredient(ItemID.MedusaHead)
                    .AddIngredient(ItemID.SharpTears)
                    .AddIngredient(ItemID.MagnetSphere)
                    .AddIngredient(ItemID.RainbowGun)
                    .AddIngredient(ItemID.ApprenticeStaffT3)
                    .AddIngredient(ItemID.SparkleGuitar)
                    .AddIngredient(ItemID.RazorbladeTyphoon)
                    .AddIngredient(ItemID.LaserMachinegun)
                    .AddIngredient(ItemID.LastPrism)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<ApprenticesEssence>()
                    .AddIngredient(ItemID.ManaCloak)
                    .AddIngredient(ItemID.MagnetFlower)
                    .AddIngredient(ItemID.ArcaneFlower)
                    .AddIngredient(ItemID.CelestialCuffs)
                    .AddIngredient(ItemID.CelestialEmblem)

                    .AddIngredient<ChronomancersScythe>()
                    .AddIngredient<DarkSpark>()
                    .AddIngredient<Omicron>()
                    .AddIngredient<NebulousCataclysm>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}