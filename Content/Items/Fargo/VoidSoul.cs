//using System;
//using Terraria;
//using Terraria.ModLoader;
//using FargowiltasSouls.Core.Toggler;
//using FargowiltasSouls.Core.Toggler.Content;
//using FargowiltasSouls.Core.AccessoryEffectSystem;
//using FargowiltasSouls.Content.Items.Accessories.Souls;
//using Terraria.GameContent.UI;
//using Terraria.ID;
//using FargowiltasSouls;
//using Terraria.DataStructures;
//using Microsoft.Xna.Framework;

//namespace yitangFargo.Content.Items.Fargo
//{
//    public class VoidSoul : BaseSoul
//    {
//        public override void SetDefaults()
//        {
//            base.SetDefaults();
//            Item.rare = ItemRarityID.Expert;
//            Item.value = Item.buyPrice(1, 0, 0, 0);
//        }

//        public override void UpdateAccessory(Player player, bool hideVisual)
//        {

//        }

//        public static void AddPet(Player player, int petId, IEntitySource source)
//        {
//            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[petId] < 1)
//            {
//                FargoSoulsUtil.NewSummonProjectile(source, player.Center, Vector2.Zero, petId, 0, 0f, Main.myPlayer, 0f, 0f);
//            }
//        }

//    }

//    //public class VoidSoulEffect : AccessoryEffect
//    //{
//    //    public override Header ToggleHeader => Header.GetHeader<PetHeader>();
//    //    public override int ToggleItemType => ModContent.ItemType<VoidSoul>();
//    //}
//}
