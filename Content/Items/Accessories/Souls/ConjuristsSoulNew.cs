using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using yitangFargo.Global.Config;
using CalamityMod.Items.Weapons.Summon;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class ConjuristsSoulNew : BaseSoul
    {
        public static readonly Color ItemColor = new(0, 255, 255);
        protected override Color? nameColor => ItemColor;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.FargoSouls().SummonSoul = true;
            player.GetDamage(DamageClass.Summon) += 0.3f;
            player.maxMinions += 5;
            player.maxTurrets += 5;
            player.GetKnockback(DamageClass.Summon) += 3f;

            player.whipRangeMultiplier += 0.15f;
            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.2f;
            player.GetCritChance(DamageClass.Summon) += 15;
        }

        public override void AddRecipes()
        {
            if (ytFargoConfig.Instance.FargoSoulsRecipe)
            {
                CreateRecipe()
                    .AddIngredient<OccultistsEssence>()
                    .AddIngredient(ItemID.MonkBelt)
                    .AddIngredient(ItemID.SquireShield)
                    .AddIngredient(ItemID.HuntressBuckler)
                    .AddIngredient(ItemID.ApprenticeScarf)
                    .AddIngredient(ItemID.PygmyNecklace)
                    .AddIngredient(ItemID.PapyrusScarab)
                    .AddIngredient(ItemID.Smolstar)
                    .AddIngredient(ItemID.PirateStaff)
                    .AddIngredient(ItemID.OpticStaff)
                    .AddIngredient(ItemID.DeadlySphereStaff)
                    .AddIngredient(ItemID.StormTigerStaff)
                    .AddIngredient(ItemID.StaffoftheFrostHydra)
                    .AddIngredient(ItemID.TempestStaff)
                    .AddIngredient(ItemID.RavenStaff)
                    .AddIngredient(ItemID.XenoStaff)
                    .AddIngredient(ItemID.EmpressBlade)
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }

            if (ytFargoConfig.Instance.CalamityFargoRecipe)
            {
                CreateRecipe()
                    .AddIngredient<OccultistsEssence>()
                    .AddIngredient(ItemID.MonkBelt)
                    .AddIngredient(ItemID.SquireShield)
                    .AddIngredient(ItemID.HuntressBuckler)
                    .AddIngredient(ItemID.ApprenticeScarf)
                    .AddIngredient(ItemID.PygmyNecklace)
                    .AddIngredient(ItemID.PapyrusScarab)
                    .AddIngredient<AncientIceChunk>()
                    .AddIngredient(ItemID.OpticStaff)
                    .AddIngredient(ItemID.DeadlySphereStaff)
                    .AddIngredient(ItemID.StormTigerStaff)
                    .AddIngredient<ResurrectionButterfly>()
                    .AddIngredient<StellarTorusStaff>()
                    .AddIngredient<EndoHydraStaff>()
                    .AddIngredient<CorvidHarbringerStaff>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}
