using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
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