using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class GolemDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.Golem) {
                npcLoot.Add(ItemDropRule.ByCondition(new GolemFragmentDropCondition(), ModContent.ItemType<GolemFragment>(), 1, 1, 1));
            }
        }
    }
}