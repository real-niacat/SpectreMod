using SpectreMod.Core.DropConditions;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class QueenSlimeDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.QueenSlimeBoss) {
                npcLoot.Add(ItemDropRule.ByCondition(new QueenSlimeFragmentDropCondition(), ModContent.ItemType<QueenSlimeFragment>(), 1, 1, 1));
            }
        }
    }
}