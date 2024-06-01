using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.NPCs.TownNPCs;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalNPC
{
    public class CalamityFargoNPCText : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            //大法师NPC
            if (npc.type == ModContent.NPCType<DILF>())
            {
                switch (chat)
                {
                    case "You clearly possess great skill! My thanks to you for freeing me, and providing an opportunity to defrost my fighting abilities.":
                        chat = "嗯，你显然有着高超的技术和实力！我由衷地感谢你解救了我，并为我提供了一个解除封印后伸展筋骨的机会。";
                        break;
                    case "Aah, a good round of sparring. I need the exercise, so thanks for that.":
                        chat = "啊……打得很好，看来我自身还是有着不足之处，需要多加锻炼。总而言之，一切都已结束，谢谢你了。";
                        break;
                }
            }
        }
    }
}