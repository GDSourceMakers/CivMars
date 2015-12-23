using CivMarsEngine;

namespace CivMars
{
	class ControlCircuit : Item, IRegystratabe
	{

        new public string name = "ControlCircuit";


		public ControlCircuit(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public ControlCircuit()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{

			Item[] a = { new ControllChip(1), new PlasticPlate(1), new SiliconRod(2), new CopperIngot(1) };
			Recipe r = new Recipe("CivMars.Press", a, new ControlCircuit(3), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}