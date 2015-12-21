namespace CivMars
{
	class ControllChip : Item, IRegystratabe
	{

		public string name = "ControlCircuit";


		public ControllChip(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public ControllChip()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new PlasticPlate(2),new SiliconRod(1), new CopperIngot(1), new GoldIngot(1)};
			Recipe r = new Recipe("CivMars.Press", a, new ControllChip(3), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}