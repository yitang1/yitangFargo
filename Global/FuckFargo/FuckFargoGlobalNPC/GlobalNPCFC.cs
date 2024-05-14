using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.NPCs.ExoMechs;
using CalamityMod.NPCs.SupremeCalamitas;
using FargowiltasSouls.Content.Bosses.AbomBoss;
using FargowiltasSouls.Content.Bosses.DeviBoss;
using FargowiltasSouls.Content.Bosses.MutantBoss;
using yitangFargo.Content.Buffs;
using yitangFargo.Global.Config;
using CalamityMod.Events;

namespace yitangFargo.Global.FuckFargo.FuckFargoGlobalNPC
{
    public class GlobalNPCFC : GlobalNPC
    {
        public override bool PreAI(NPC npc)
        {
            //免疫月之诅咒的Buff
            if (ytFargoConfig.Instance.NullCurseBuff && npc.type == NPCID.MoonLordCore
                && Main.LocalPlayer.active && !Main.LocalPlayer.dead && !Main.LocalPlayer.ghost)
            {
                Main.LocalPlayer.AddBuff(ModContent.BuffType<NullCurseNoBuff>(), 2);
            }
            //免疫“驾到”减益的Buff
            if (ytFargoConfig.Instance.NoBossDebuff
                && Main.LocalPlayer.active && !Main.LocalPlayer.dead && !Main.LocalPlayer.ghost
                && (npc.type == ModContent.NPCType<DeviBoss>() || npc.type == ModContent.NPCType<AbomBoss>()
                || npc.type == ModContent.NPCType<MutantBoss>()
                || npc.type == ModContent.NPCType<Draedon>() || npc.type == ModContent.NPCType<SupremeCalamitas>()
                /*|| BossRushEvent.BossRushActive*/))
            {
                Main.LocalPlayer.AddBuff(ModContent.BuffType<BossAbsence>(), 2);
            }
            return true;
        }
    }
}
