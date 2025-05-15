using SpectreMod.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.NPCDrops
{
    public class StarCellBigDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.StardustCellBig)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarCells>(), 2, 2, 3));
            }
            if (npc.type == NPCID.StardustCellSmall)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarCells>(), 4, 1, 2));
            }
        }
    }
}