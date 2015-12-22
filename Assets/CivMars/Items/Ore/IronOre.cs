namespace CivMars
{
	public class IronOre : Item
	{
		public IronOre(int am) : base(am, 4)
		{
			maxStackSize = 4;
		}

		public IronOre() : base(4)
		{
			maxStackSize = 4;
		}

	}
}