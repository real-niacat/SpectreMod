using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class EyeOfCthulhuDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.EyeofCthulhu) {
                npcLoot.Add(ItemDropRule.ByCondition(new EoCFragmentDropCondition(), ModContent.ItemType<EoCFragment>(), 1, 1, 1));
            }
        }
    }
}