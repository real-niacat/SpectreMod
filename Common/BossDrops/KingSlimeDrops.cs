using SpectreMod.Core.DropConditions;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
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