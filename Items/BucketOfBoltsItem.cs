using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Content;
using System.Collections.Generic;
using BucketOfBolts.Buffs;

namespace BucketOfBolts.Items {
    public class BucketOfBoltsItem : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bucket Of Bolts");
            Tooltip.SetDefault("Draedon's old toys...");
        }

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(8, 8, 1, 9);
            Item.rare = ItemRarityID.Pink;
            Item.buffType = ModContent.BuffType<BoltsBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.SkeletronPrimePetItem)
                .AddIngredient(ItemID.TwinsPetItem)
                .AddIngredient(ItemID.DestroyerPetItem)
                .AddIngredient(ItemID.EmptyBucket)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}