namespace CivMars
{
	class CopperIngot : Item, IRegystratabe
	{

		public string name = "ControlCircuit";


		public CopperIngot(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public CopperIngot()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new CopperOre(2) };
			Recipe r = new Recipe("CivMars.Press", a, new CopperIngot(1), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}
