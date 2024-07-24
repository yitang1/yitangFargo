using Terraria;
using Terraria.ModLoader;
using CalamityMod.Rarities;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using yitangFargo.Content.Items.Calamity.Enchantments;

namespace yitangFargo.Content.Items.Calamity.Forces
{
    public class ExaltationForce : BaseForce
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = Item.buyPrice(1, 0, 0, 0);
        }
        /*大部分月后魔石里的配方都会出现跨时期的材料，
         因为相比肉前和肉后，月后的盔甲套装更迭频率大幅降低且盔甲数量很少，
         所以如果每个时期再用当前时期唯一的盔甲合成魔石，那玩家就没得穿了，而且重复合成也会感到繁琐，
         因此月后魔石就设定成：当前时期更换了新的盔甲后，可以顺带合成上个时期的魔石，然后考虑是否穿戴。
         (然而无论如何都无法避免的是——要制作古圣金源魔石就必须要合成至少两次的4个月后盔甲……)
         (但是还有反转：本模组的NPC商店表示，“What are you talking about, bro？能直接购买的事为什么要手动合成呢？”)*/
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //龙蒿魔石
            ModContent.GetInstance<TarragonEnchant>().UpdateAccessory(player, hideVisual);
            //血炎魔石
            ModContent.GetInstance<BloodflareEnchant>().UpdateAccessory(player, hideVisual);
            //弑神者魔石
            ModContent.GetInstance<GodSlayerEnchant>().UpdateAccessory(player, hideVisual);
            //始源林海魔石
            ModContent.GetInstance<SilvaEnchant>().UpdateAccessory(player, hideVisual);
            //古圣金源魔石
            ModContent.GetInstance<AuricEnchant>().UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<TarragonEnchant>()
                .AddIngredient<BloodflareEnchant>()
                .AddIngredient<GodSlayerEnchant>()
                .AddIngredient<SilvaEnchant>()
                .AddIngredient<AuricEnchant>()
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}