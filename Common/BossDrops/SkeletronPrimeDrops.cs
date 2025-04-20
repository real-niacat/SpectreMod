using SpectreMod.Core.DropConditions;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class SkeletronPrimeDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.SkeletronPrime) {
                npcLoot.Add(ItemDropRule.ByCondition(new SkeletronPrimeFragmentDropCondition(), ModContent.ItemType<SkeletronPrimeFragment>(), 1, 1, 1));
            }
        }
    }
}