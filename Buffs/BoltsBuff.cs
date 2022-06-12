using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using BucketOfBolts.Projectiles;

namespace BucketOfBolts.Buffs {
    public class BoltsBuff : ModBuff {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bucket Of Bolts");
            Description.SetDefault("The Night Terrors, at your command");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.buffTime[buffIndex] = 18000;

            player.GetModPlayer<BucketPlayer>().BucketOfBolts = true;
            player.GetModPlayer<BucketPlayer>().DestroyerProbe = true;
            player.petFlagSkeletronPrimePet = true;
            player.petFlagTwinsPet = true;
            player.petFlagDestroyerPet = true;

            bool skeletronPrime = player.ownedProjectileCounts[ProjectileID.SkeletronPrimePet] <= 0;
            if (skeletronPrime && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2), 
                    player.position.Y + (player.height / 2), 0f, 0f, ProjectileID.SkeletronPrimePet, 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool theDestroyer = player.ownedProjectileCounts[ProjectileID.DestroyerPet] <= 0;
            if (theDestroyer && player.whoAmI == Main.myPlayer) {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ProjectileID.DestroyerPet, 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool destroyerProbe1 = player.ownedProjectileCounts[ModContent.ProjectileType<DestroyerProbe1>()] <= 0;
            if (destroyerProbe1 && player.whoAmI == Main.myPlayer) {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DestroyerProbe1>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool destroyerProbe2 = player.ownedProjectileCounts[ModContent.ProjectileType<DestroyerProbe2>()] <= 0;
            if (destroyerProbe2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DestroyerProbe2>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool destroyerProbe3 = player.ownedProjectileCounts[ModContent.ProjectileType<DestroyerProbe3>()] <= 0;
            if (destroyerProbe3 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DestroyerProbe3>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool theTwins = player.ownedProjectileCounts[ProjectileID.TwinsPet] <= 0;
            if (theTwins && player.whoAmI == Main.myPlayer) {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ProjectileID.TwinsPet, 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
