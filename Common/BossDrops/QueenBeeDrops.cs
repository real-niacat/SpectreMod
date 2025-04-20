using SpectreMod.Core.DropConditions;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class QueenBeeDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.QueenBee) {
                npcLoot.Add(ItemDropRule.ByCondition(new QueenBeeFragmentDropCondition(), ModContent.ItemType<QueenBeeFragment>(), 1, 1, 1));
            }
        }
    }
}