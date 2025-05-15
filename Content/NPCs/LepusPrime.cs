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
    [AutoloadBossHead]
    public class LepusPrime : ModNPC
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/PlaceHolder";

        public int QuarterDamage { get { return NPC.damage / 4; } }

        public int HalfDamage { get { return NPC.damage / 2; } }
        public int DoubleDamage { get { return NPC.damage * 2; } }
        public int Timer = 0;
        public float KnockBackResist = 0f;
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.lifeMax = 300000;
            NPC.width = 120;
            NPC.height = 45;
            NPC.knockBackResist = KnockBackResist;
            NPC.immortal = true;

            NPC.defense = 10;
            NPC.damage = 125;
            NPC.boss = true;
            
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
           

            data = [0, 0, 0, 0, 0];
        }
        public override bool CheckActive()
        {
            return false;
        }
        public override bool? CanFallThroughPlatforms()
        {
            return true;
        }

        public static Vector2 Up(float amt) { return new Vector2(0, -amt); }
        public static Vector2 Down(float amt) { return new Vector2(0, amt); }
        public static Vector2 Left(float amt) { return new Vector2(-amt, 0); }
        public static Vector2 Right(float amt) { return new Vector2(amt, 0); }
        public static Vector2 Tiles(Vector2 toTile) { return toTile * 16; }
        public static float Radians(float degrees) { return (float)(degrees * Math.PI / 180); }
        public static Vector2 RotateCW(Vector2 from, float angle) 
        {
            double newX = (from.X * Math.Cos(Radians(angle))) - (from.Y * Math.Sin(Radians(angle)));
            double newY = (from.X * Math.Sin(Radians(angle))) + (from.Y * Math.Cos(Radians(angle)));
            return new Vector2((float)newX, (float)newY);
        }
        public Vector2 Towards(Vector2 target) { Vector2 c = target - NPC.position; c.Normalize(); return c; }


        public int[] data;
        public float gravityMult = 1f;

        public override void AI()
        {
            Timer++;
            NPC.GravityMultiplier *= gravityMult;
            gravityMult = gravityMult < 1 ? gravityMult + 0.05f : gravityMult;


            float distance;
            Player player = Main.player[NPC.FindClosestPlayer(out distance)];
            Vector2 plrpos = player.position;

            if (Timer % 60 == 0)
            {
                int chosenProjectile = ProjectileID.DeathLaser;
                int speed = 15;
                int spawnDistance = 40;
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Left(spawnDistance)), Right(speed), chosenProjectile, QuarterDamage, 0);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Right(spawnDistance)), Left(speed), chosenProjectile, QuarterDamage, 0);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Up(spawnDistance)), Down(speed), chosenProjectile, QuarterDamage, 0);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), plrpos + Tiles(Down(spawnDistance)), Up(speed), chosenProjectile, QuarterDamage, 0);
            }


            if (NPC.velocity.X > 10) { NPC.velocity.X *= 0.99f; }
            if (NPC.collideY) { NPC.velocity.X += Towards(plrpos).X; NPC.velocity.X *= 0.93f; }
            if (player.position.Y < NPC.position.Y) { NPC.velocity.Y -= 0.1f; }

            if (data[0] <= 0 && (NPC.collideX || NPC.collideY || distance > 80))
            {
                
                data[0] = Main.rand.Next(110, 220);
                gravityMult = 0.05f;
                //jump code
                Vector2 normalizedDiff = plrpos - NPC.position;
                normalizedDiff.Normalize();
                normalizedDiff.Y *= 2;
                float spd = Math.Max(15, (float)Math.Pow(distance, 0.45f));

                NPC.velocity += normalizedDiff * spd;

                for (int i = 0; i < 120; i += 15)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, RotateCW(Towards(plrpos), i-60) * spd * 1.5f, ProjectileID.DeathLaser, QuarterDamage, 0);
                }

            } else { data[0] = data[0] - 1; }
        }
    }
}
