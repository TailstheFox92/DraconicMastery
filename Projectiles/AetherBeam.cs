using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace DraconicMastery.Projectiles
{
    public class AetherBeam : ModProjectile
    {
        public bool soundPlayed = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aether Beam");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            drawOriginOffsetY = -17;
            projectile.alpha = 255;
        }

        public override void AI()
        {
            if(!soundPlayed)
            {
                Main.PlaySound(SoundID.Item8);
                soundPlayed = true;
            }

            if (Main.rand.Next(2) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 187,
                    projectile.velocity.X, projectile.velocity.Y, 200, Scale: 1f);
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }

            if (projectile.alpha > 0)
            {
                projectile.alpha -= 15; // Decrease alpha, increasing visibility.
            }

            projectile.rotation = projectile.velocity.ToRotation(); // projectile faces sprite right
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 480);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 20; ++i)
            {
                int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0.0f, 0.0f, 100, new Color(), 1f);
                Main.dust[index2].velocity *= 1.1f;
                Main.dust[index2].scale *= 0.99f;
            }
        }
    }
}
