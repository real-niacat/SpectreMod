using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
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