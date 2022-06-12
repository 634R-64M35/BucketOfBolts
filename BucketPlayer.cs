using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BucketOfBolts.Items;

namespace BucketOfBolts {
	public class BucketPlayer : ModPlayer {
		public bool BucketOfBolts;
		public bool DestroyerProbe;
		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath) {
			return Player.name != "Priss" ?
				Player.name != "Ada" ?
				Player.name != "Phoebe" ?
				Player.name != "Draedon Gaming" ?
				Enumerable.Empty<Item>()
				: new[] { new Item(ModContent.ItemType<BucketOfBoltsItem>()) }
				: new[] { new Item(ModContent.ItemType<BucketOfBoltsItem>()) }
				: new[] { new Item(ModContent.ItemType<BucketOfBoltsItem>()) }
				: new[] { new Item(ModContent.ItemType<BucketOfBoltsItem>()) };
		}
		public override void Initialize() {
			DestroyerProbe = false;
			BucketOfBolts = false;
		}
	}
}