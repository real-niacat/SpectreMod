using SpectreMod.Core.DropConditions;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class TheDestroyerDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.TheDestroyer) {
                npcLoot.Add(ItemDropRule.ByCondition(new DestroyerFragmentDropCondition(), ModContent.ItemType<DestroyerFragment>(), 1, 1, 1));
            }
        }
    }
}