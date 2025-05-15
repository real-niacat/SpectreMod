using SpectreMod.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.NPCDrops
{
    public class NebulaFloaterDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.NebulaBrain)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PinkMatter>(), 2, 1, 3));
            }
        }
    }
}