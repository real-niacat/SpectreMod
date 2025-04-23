using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class KingSlimeDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.KingSlime) {
                npcLoot.Add(ItemDropRule.ByCondition(new SlimeFragmentDropCondition(), ModContent.ItemType<SlimeFragment>(), 1, 1, 1));
            }
        }
    }
}