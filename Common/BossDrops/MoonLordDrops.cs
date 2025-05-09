using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class MoonLordDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.MoonLordCore) {
                npcLoot.Add(ItemDropRule.ByCondition(new MoonLordFragmentDropCondition(), ModContent.ItemType<MoonLordFragment>(), 1, 1, 1));
            }
        }
    }
}