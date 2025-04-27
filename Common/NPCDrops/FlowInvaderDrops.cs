using SpectreMod.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.NPCDrops
{
    public class FlowInvaderDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.StardustJellyfishBig)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StardustTendril>(), 2, 2, 3));
            }
            if (npc.type == NPCID.StardustJellyfishSmall)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StardustTendril>(), 4, 1, 2));
            }
        }
    }
}