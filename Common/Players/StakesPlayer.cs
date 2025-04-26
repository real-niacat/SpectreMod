using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
//using SerousCommonLib

namespace SpectreMod.Common.Players
{
    public class StakesPlayer : ModPlayer
    {
        public float Stakes = 0;
        public bool Enabled
        {
            get
            {
                return Main.npc.Take(Main.maxNPCs).Any(n => n.active && n.boss && n.target == Player.whoAmI);
            }
        }

        public override void PostUpdate()
        {
            base.PostUpdate();
            if (Enabled)
            {
                Stakes += 1 / 60;
            } else
            {
                Stakes -= 2 / 60;
            }

            Stakes = Stakes < 0 ? 0 : Stakes;
            Stakes = Stakes > 200 ? 200 : Stakes;
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            base.DrawEffects(drawInfo, ref r, ref g, ref b, ref a, ref fullBright);
            r += Stakes / 100;
        }
    }
}
