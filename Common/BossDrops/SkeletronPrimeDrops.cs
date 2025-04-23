using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
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