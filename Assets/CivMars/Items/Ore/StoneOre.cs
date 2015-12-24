using CivMarsEngine;

namespace CivMars
{
	public class StoneOre : Item
	{
		public string name = "Stone" + "Ore";

		public StoneOre(int am) : base(am, 4)
		{
			maxStackSize = 4;
		}

		public StoneOre() : base(4)
		{
			maxStackSize = 4;
		}

	}
}