using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
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