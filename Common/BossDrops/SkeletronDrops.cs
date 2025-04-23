using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class SkeletronDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.SkeletronHead) {
                npcLoot.Add(ItemDropRule.ByCondition(new SkeletronFragmentDropCondition(), ModContent.ItemType<SkeletronFragment>(), 1, 1, 1));
            }
        }
    }
}