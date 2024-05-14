using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Rarities;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using yitangFargo.Common.Toggler;

namespace yitangFargo.Content.Items.Calamity.Souls
{
    public class BrandoftheWitchNew : SoulsItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.value = Item.buyPrice(2, 50, 0, 0);
            Item.rare = ModContent.RarityType<Violet>();
            Item.defense = 50;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //元灵之心
            if (player.AddEffect<AHeartElements>(Item))
            {
                ModContent.GetInstance<HeartoftheElements>().UpdateAccessory(player, hideVisual);
            }
            //痴愚金龙干细胞
            if (player.AddEffect<BCells>(Item))
            {
                ModContent.GetInstance<DynamoStemCells>().UpdateAccessory(player, hideVisual);
            }
            //灾劫之尖啸
            ModContent.GetInstance<Affliction>().UpdateAccessory(player, hideVisual);
            //玄秘颅冠
            if (player.AddEffect<CSkullCrown>(Item))
            {
                ModContent.GetInstance<OccultSkullCrown>().UpdateAccessory(player, hideVisual);
            }
            //星云之核
            if (player.AddEffect<DNebulousCore>(Item))
            {
                ModContent.GetInstance<NebulousCore>().UpdateAccessory(player, hideVisual);
            }
            //嘉登之心
            if (player.AddEffect<EDraedonsHeart>(Item))
            {
                ModContent.GetInstance<DraedonsHeart>().UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<HeartoftheElements>()
                .AddIngredient<DynamoStemCells>()
                .AddIngredient<Affliction>()
                .AddIngredient<OccultSkullCrown>()
                .AddIngredient<NebulousCore>()
                .AddIngredient<DraedonsHeart>()
                .AddIngredient<ShadowspecBar>(5)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }

    public abstract class BrandWitchEffect : AccessoryEffect
    {
        public override Header ToggleHeader => Header.GetHeader<BrimstoneWitchHeader>();
    }
    public class AHeartElements : BrandWitchEffect
    {
        public override int ToggleItemType => ModContent.ItemType<HeartoftheElements>();
        public override bool IgnoresMutantPresence => true;
    }
    public class BCells : BrandWitchEffect
    {
        public override int ToggleItemType => ModContent.ItemType<DynamoStemCells>();
        public override bool IgnoresMutantPresence => true;
    }
    public class CSkullCrown : BrandWitchEffect
    {
        public override int ToggleItemType => ModContent.ItemType<OccultSkullCrown>();
        public override bool IgnoresMutantPresence => true;
    }
    public class DNebulousCore : BrandWitchEffect
    {
        public override int ToggleItemType => ModContent.ItemType<AsgardianAegis>();
        public override bool IgnoresMutantPresence => true;
    }
    public class EDraedonsHeart : BrandWitchEffect
    {
        public override int ToggleItemType => ModContent.ItemType<DraedonsHeart>();
        public override bool IgnoresMutantPresence => true;
    }
}