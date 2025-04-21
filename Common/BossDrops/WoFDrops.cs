using SpectreMod.Core.DropConditions;
using SpectreMod.Content.Items.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class WoFDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.WallofFlesh) {
                npcLoot.Add(ItemDropRule.ByCondition(new WoFFragmentDropCondition(), ModContent.ItemType<WoFFragment>(), 1, 1, 1));
            }
        }
    }
}