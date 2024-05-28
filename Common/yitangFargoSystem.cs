using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangFargo.Common
{
    public class yitangFargoSystem : ModSystem
    {
        public override void OnWorldLoad()
        {
            /*当前世界未击败过史莱姆王时，字段才会被重置为0。字段为0时，会触发忍者NPC第一次生成时的初次对话。
            而只有创建的新世界存档，才会满足“未击败过史莱姆王”这个条件，因为NPC生成的条件必须是至少击败过一次史王，
            因此这个条件是限定了只有在新世界存档第一次生成忍者NPC时，才会触发其初次对话。*/
            if (!NPC.downedSlimeKing)
            {
                hasChatedNinja = 0;
            }
        }
        public static int hasChatedNinja = 0;
    }
}
