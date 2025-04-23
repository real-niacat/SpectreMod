using SpectreMod.Content.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.NPCDrops
{
    public class DrakomireDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.SolarDrakomire)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DrakomireScale>(), 2, 1, 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DrakomireFang>(), 4, 1, 2));
            }
        }
    }
}