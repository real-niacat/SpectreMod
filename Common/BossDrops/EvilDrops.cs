using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class EvilDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.EaterofWorldsTail || npc.type == NPCID.BrainofCthulhu) {
                npcLoot.Add(ItemDropRule.ByCondition(new EvilFragmentDropCondition(), ModContent.ItemType<EvilFragment>(), 1, 1, 1));
            }
        }
    }
}