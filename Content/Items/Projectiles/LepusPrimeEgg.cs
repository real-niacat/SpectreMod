using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Items.Projectiles
{
    public class LepusPrimeEgg : ModProjectile
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/PlaceHolder";

        public Vector2 InitialVelocity;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pearl Swirl");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 1800;
            Projectile.penetrate = -1;
        }
        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0f, Projectile.Opacity * 0.5f, Projectile.Opacity * 0.5f);
            if (Projectile.frameCounter == 0f)
                InitialVelocity = Projectile.velocity;

            Projectile.frameCounter++;
            if (Projectile.ai[0] == 1f)
                Projectile.velocity = InitialVelocity.RotatedBy(-(MathHelper.TwoPi - (Math.Log(Projectile.frameCounter) * MathHelper.TwoPi + 1)));
            else
                Projectile.velocity = InitialVelocity.RotatedBy(MathHelper.TwoPi - (Math.Log(Projectile.frameCounter) * MathHelper.TwoPi + 1));

            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;

            int frame = (int)(Projectile.frameCounter / 5f);
            if (frame > 3)
                frame -= (int)Math.Floor(frame / 4f) * 4;
            Projectile.frame = frame;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;
    }
}