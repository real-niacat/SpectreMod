using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Content.Items.Materials;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class PlanteraDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.Plantera) {
                npcLoot.Add(ItemDropRule.ByCondition(new PlanteraFragmentDropCondition(), ModContent.ItemType<PlanteraFragment>(), 1, 1, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlanterasSeed>(), 3, 1, 1));
            }
        }
    }
}