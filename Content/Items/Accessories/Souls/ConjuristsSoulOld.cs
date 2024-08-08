using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Weapons.Summon;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using yitangFargo.Global.Config;

namespace yitangFargo.Content.Items.Accessories.Souls
{
    public class ConjuristsSoulOld : BaseSoul
    {
        public static readonly Color ItemColor = new(0, 255, 255);
        protected override Color? nameColor => ItemColor;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.FargoSouls().SummonSoul = true;
            player.GetDamage(DamageClass.Summon) += 0.3f;
            player.GetCritChance(DamageClass.Summon) += 15;

            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.2f;
            player.whipRangeMultiplier += 0.15f;

            player.GetKnockback(DamageClass.Summon) += 3f;

            player.maxMinions += 5;
            player.maxTurrets += 5;
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
                    .AddIngredient(ItemID.ApprenticeScarf)
                    .AddIngredient(ItemID.SquireShield)
                    .AddIngredient(ItemID.MonkBelt)
                    .AddIngredient(ItemID.HuntressBuckler)
                    .AddIngredient(ItemID.PygmyNecklace)
                    .AddIngredient(ItemID.PapyrusScarab)

                    .AddIngredient<EtherealSubjugator>()
                    .AddIngredient<GuidelightofOblivion>()
                    .AddIngredient<EndoHydraStaff>()
                    .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                    .Register();
            }
        }
    }
}