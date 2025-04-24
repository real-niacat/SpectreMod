using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.NPCs
{
    public class LepusPrime : ModNPC
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/PlaceHolder";

        public int QuarterDamage { get { return NPC.damage / 4; } }

        public int HalfDamage { get { return NPC.damage / 2; } }
        public int DoubleDamage { get { return NPC.damage * 2; } }
        public int Timer = 0;
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.lifeMax = 300000;
            NPC.width = 20;
            NPC.height = 20;

            NPC.defense = 45;
            NPC.damage = 125;
        }

        public override bool CheckActive()
        {
            return false;
        }

        public static Vector2 Up(float amt) { return new Vector2(0, -amt); }
        public static Vector2 Down(float amt) { return new Vector2(0, amt); }
        public static Vector2 Left(float amt) { return new Vector2(-amt, 0); }
        public static Vector2 Right(float amt) { return new Vector2(amt, 0); }
        public static Vector2 Tiles(Vector2 toTile) { return toTile * 16; }

        public override void AI()
        {
            Timer++;
            float distance;
            Player player = Main.player[NPC.FindClosestPlayer(out distance)];
            Vector2 plrpos = player.position;

            if (Timer % 12 == 0)
            {
                int chosenProjectile = ProjectileID.DeathLaser;
                int speed = 15;
                int spawnDistance = 70;
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Left(spawnDistance)), Right(speed), chosenProjectile, QuarterDamage, 0);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Right(spawnDistance)), Left(speed), chosenProjectile, QuarterDamage, 0);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Up(spawnDistance)), Down(speed), chosenProjectile, QuarterDamage, 0);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Down(spawnDistance)), Up(speed), chosenProjectile, QuarterDamage, 0);
            }
        }
    }
}
