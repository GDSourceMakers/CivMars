namespace CivMars
{
	class GoldOre : Item, IRegystratabe
	{

		public string name = "ControlCircuit";


		public GoldOre(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public GoldOre()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
		}
	}
}