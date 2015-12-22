using CivMarsEngine;

namespace CivMars
{
	class GoldIngot : Item, IRegystratabe
	{

		public string name = "ControlCircuit";


		public GoldIngot(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public GoldIngot()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new GoldOre(4) };
			Recipe r = new Recipe("CivMars.Furnace", a, new GoldIngot(1), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}