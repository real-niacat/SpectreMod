using SpectreMod.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.NPCDrops
{
    public class NebulaBeastDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.NebulaBeast)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PinkMatter>(), 2, 1, 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NebulaBeastClaw>(), 2, 1, 3));
            }
        }
    }
}