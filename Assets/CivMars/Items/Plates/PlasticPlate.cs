namespace CivMars
{
	class PlasticPlate : Item, IRegystratabe
	{

		public string name = "ControlCircuit";


		public PlasticPlate(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public PlasticPlate()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new Resin(4) };
			Recipe r = new Recipe("CivMars.Press", a, new PlasticPlate(3), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}