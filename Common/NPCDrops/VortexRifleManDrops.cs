using SpectreMod.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Common.NPCDrops
{
    public class VortexRifleManDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.VortexRifleman)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VortexGunMechanism>(), 2, 1, 3));
            }
        }
    }
}