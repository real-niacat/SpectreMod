using SpectreMod.Core.DropConditions;
using SpectreMod.Content.Items.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class DukeFishronDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.DukeFishron) {
                npcLoot.Add(ItemDropRule.ByCondition(new DukeFishronFragmentDropCondition(), ModContent.ItemType<DukeFishronFragment>(), 1, 1, 1));
            }
        }
    }
}