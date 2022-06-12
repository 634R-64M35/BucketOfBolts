using BucketOfBolts;
using BucketOfBolts.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BucketOfBolts.Projectiles {
    public class DestroyerProbe2 : ModProjectile {
        public virtual Vector2 FlyingOffset => new Vector2(72f * -Main.player[Projectile.owner].direction, -32f);
        public override string Texture => "BucketOfBolts/Projectiles/DestroyerProbe";
        public Player Owner => Main.player[Projectile.owner];
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Destroyer Probe");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults() {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }
        public override void AI() {
            if (!Owner.dead && Owner.HasBuff(ModContent.BuffType<BoltsBuff>())) {
                Projectile.timeLeft = 2;
            }

            if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) > 0) {
                Projectile.spriteDirection = Projectile.velocity.X > 0 ? -1 : 1;
            }


            Vector2 ProjectileCenter = Projectile.Center;
            Vector2 vectorToPlayer = Owner.Center - ProjectileCenter;
            float lengthToPlayer = vectorToPlayer.Length();

            if (lengthToPlayer > 1000)
            {
                Projectile.position = Owner.Center;
                Projectile.velocity *= 0.1f;
            }

            float flyingSpeed = 12f;
            float flyingInertia = 80f;

            if ((lengthToPlayer > 560f))
            {
                flyingSpeed *= 1.25f;
                flyingInertia *= 0.75f;
            }

            Projectile.tileCollide = false;
            vectorToPlayer += FlyingOffset;
            lengthToPlayer = vectorToPlayer.Length();

            if (lengthToPlayer > 30f)
            {
                vectorToPlayer.Normalize();
                vectorToPlayer *= flyingSpeed;

                if (Projectile.velocity == Vector2.Zero)
                {
                    Projectile.velocity = new Vector2(-0.15f);
                }

                if (flyingInertia != 0f && flyingSpeed != 0f)
                {
                    Projectile.velocity = (Projectile.velocity * (flyingInertia - 1) + vectorToPlayer) / flyingInertia;
                }
            }
            else
            {
                Projectile.velocity *= 1f;
            }
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 8) {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame > Main.projFrames[Projectile.type] - 1) { 
                    Projectile.frame = 0;
                }
            }
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask;
            glowMask = ModContent.Request<Texture2D>("BucketOfBolts/Projectiles/DestroyerProbeGlow").Value;
            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw
            (
                glowMask,
                Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame,
                Color.White,
                Projectile.rotation,
                new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY),
                Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0
            );
        }
    }
}
