using Terraria.ModLoader;

namespace BucketOfBolts {
	public class BucketOfBolts : Mod {
		public static BucketOfBolts instance;

		public override void Unload() {
			instance = null;
		}
	}
}