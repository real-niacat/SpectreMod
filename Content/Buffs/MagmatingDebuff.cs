using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Buffs
{
    public class MagmatingDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MagmatingDebuffPlayer>().debuffed = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MagmatingDebuffNPC>().debuffed = true;
        }
    }

    public class MagmatingDebuffNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool debuffed;
        public override void ResetEffects(NPC npc)
        {
            debuffed = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (debuffed)
            {
                npc.lifeRegen = npc.lifeRegen > 0 ? 0 : npc.lifeRegen;

                if (npc.boss)
                {
                    npc.lifeRegen -= 1 + (int)(npc.life * 0.01f);
                }
                else
                {
                    npc.lifeRegen -= 1 + (int)(npc.lifeMax * 0.05f);
                }
            }
        }
    }

    public class MagmatingDebuffPlayer : ModPlayer
    {
        public bool debuffed;
        public override void ResetEffects()
        {
            debuffed = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (debuffed)
            {
                Player.lifeRegen = Player.lifeRegen > 0 ? 0 : Player.lifeRegen;
                Player.lifeRegen -= 1 + (int)(Player.statLifeMax2 * 0.05f);
            }
        }
    }
}
