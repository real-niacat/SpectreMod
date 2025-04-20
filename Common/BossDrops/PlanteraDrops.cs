using SpectreMod.Core.DropConditions;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class PlanteraDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.Plantera) {
                npcLoot.Add(ItemDropRule.ByCondition(new PlanteraFragmentDropCondition(), ModContent.ItemType<PlanteraFragment>(), 1, 1, 1));
            }
        }
    }
}