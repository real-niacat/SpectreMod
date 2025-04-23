using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.DropConditions;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class LunaticCultistDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.CultistBoss) {
                npcLoot.Add(ItemDropRule.ByCondition(new CultistFragmentDropCondition(), ModContent.ItemType<LunaticCultistFragment>(), 1, 1, 1));
            }
        }
    }
}