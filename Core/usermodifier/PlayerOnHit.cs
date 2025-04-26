using Microsoft.Xna.Framework;
using MonoMod.Cil;
using SpectreMod.Content.Items.Charms;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SpectreMod.Core.usermodifier
{
    public partial class SpectrePlayermod : ModPlayer
    {
        public static readonly float DefaultMeleeSize = 0f;
        public float MeleeSizeMod = DefaultMeleeSize;
        public bool charmSol = false;
        public bool charmStardust = false;
        public bool charmVortex = false;
        public override void OnHitNPC( NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Player.whoAmI != Main.myPlayer)
                return;
            if (charmSol)
            {
                Player.GetModPlayer<CharmSolPlayer>().AccumulateDamageModifier(damageDone);
            }
            if (charmStardust)
            {
                Player.GetModPlayer<CharmStardustPlayer>().AccumulateDamageModifier(damageDone);
            }
            if (charmVortex)
            {
                Player.GetModPlayer<CharmVortexPlayer>().AccumulateDamageModifier(damageDone);
            }
        }
    }
}