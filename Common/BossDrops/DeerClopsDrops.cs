using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops;
public class DeerClopsDrops : GlobalNPC
{
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
        if (npc.type == NPCID.Deerclops) {
            npcLoot.Add(ItemDropRule.ByCondition(new DeerClopsFragmentDropCondition(), ModContent.ItemType<DeerClopsFragment>(), 1, 1, 1));
        }
    }
}