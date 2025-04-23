using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpectreMod.Common.BossDrops
{
    public class EmpressOfLightDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.HallowBoss) {
                npcLoot.Add(ItemDropRule.ByCondition(new EmpressFragmentDropCondition(), ModContent.ItemType<EmpressOfLightFragment>(), 1, 1, 1));
            }
        }
    }
}