using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Buffs
{
    public class MagmatingDebuff : ModBuff
    {

        public override string Texture => "SpectreMod/Common/PlaceHolders/PlaceHolder";
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.IsATagBuff[Type] = true;
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
        public static Color MagmatingColor = new Color(0.968f, 0.255f, 0.0667f);
        public override void ResetEffects(NPC npc)
        {
            debuffed = false;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            
            if (debuffed)
            {
                Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Flare);
                d.scale = 1.5f;
                drawColor = MagmatingColor;
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (debuffed)
            {
                npc.lifeRegen = npc.lifeRegen > 0 ? 0 : npc.lifeRegen;

                if (npc.boss)
                {
                    npc.lifeRegen -= 1 + (int)(npc.life * 0.035f);
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
        public static Color MagmatingColor = new Color(0.968f, 0.255f, 0.0667f);
        public override void ResetEffects()
        {
            debuffed = false;
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (debuffed)
            {
                Dust d = Dust.NewDustDirect(Player.position, Player.width, Player.height, DustID.Flare);
                d.scale = 1.5f;
                fullBright = true;
                r = MagmatingColor.R / 255f;
                g = MagmatingColor.G / 255f;
                b = MagmatingColor.B / 255f;
            }
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
