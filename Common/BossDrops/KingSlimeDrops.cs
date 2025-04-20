using SpectreMod.Core.DropConditions;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace SpectreMod.Common.BossDrops
{
    public class KingSlimeDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (npc.type == NPCID.KingSlime) {
                npcLoot.Add(ItemDropRule.ByCondition(new CharmDropCondition(), ModContent.ItemType<SlimeCharm>(), 1, 1, 1));
            }
        }
    }
}