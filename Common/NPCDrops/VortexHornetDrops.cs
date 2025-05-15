using SpectreMod.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.NPCDrops
{
    public class VortexHornetDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.VortexHornetQueen)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CelestialLarva>(), 2, 2, 3));
            }
            if (npc.type == NPCID.VortexHornet)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CelestialLarva>(), 4, 1, 2));
            }
        }
    }
}