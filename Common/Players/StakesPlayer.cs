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
//using SerousCommonLib

namespace SpectreMod.Common.Players
{
    public class StakesPlayer : ModPlayer
    {
        public float Stakes = 0;
        public static bool Enabled
        {
            get
            {
                bool spawned = false;
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    spawned |= Main.npc[i].boss;
                }
                return spawned;
                //return NPC.AnyNPCs
                //return Main.npc.Take(Main.maxNPCs).Any(n => n.active && n.boss && n.target == Player.whoAmI);
            }
        }

        public void GenericText(string text, Color textColor)
        {
            Rectangle pos = new Rectangle((int)Player.Center.X, (int)Player.Center.Y, 1, 1);
            CombatText.NewText(pos, textColor, text);
        }

        public void ClampStakes()
        {
            Stakes = Stakes < -200 ? -200 : Stakes;
            Stakes = Stakes > 200 ? 200 : Stakes;
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            base.OnHurt(info);
            if (Enabled) { 
                Stakes += (float)Math.Pow(info.Damage, 0.8f);
                ClampStakes();

                if (Stakes > 150)
                {
                    GenericText("The stakes are high...", new Color(240, 120, 120));
                }
            }
        }

        public int frameCount = 0;
        public override void PostUpdate()
        {
            frameCount++;
            base.PostUpdate();
            if (Enabled) { Stakes -= Player.lifeRegen / 10.0f; }
            if (!Enabled) { Stakes /= 0.97f; }
            ClampStakes();
            
            
            
        }
    }
}
