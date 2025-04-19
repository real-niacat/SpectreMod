using SpectreMod.Content.Charms;
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
                // Add the Slime Charm to the King Slime's loot table
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SlimeCharm>(), 1, 1, 1));
            }
        }
    }
}