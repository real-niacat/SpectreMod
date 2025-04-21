using SpectreMod.Core.DropConditions;
using SpectreMod.Content.Items.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class TheTwinsDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.Spazmatism) {
                npcLoot.Add(ItemDropRule.ByCondition(new TwinsFragmentDropCondition(), ModContent.ItemType<TwinsFragment>(), 1, 1, 1));
            }
        }
    }
}