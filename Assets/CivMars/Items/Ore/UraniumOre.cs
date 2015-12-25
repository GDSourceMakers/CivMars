using CivMarsEngine;

namespace CivMars
{
	public class UraniumOre : Item
	{
		public string name = "Uranium" + "Ore";

		public UraniumOre(int am) : base(am, 4)
		{
			maxStackSize = 4;
		}

		public UraniumOre() : base(4)
		{
			maxStackSize = 4;
		}

	}
}

