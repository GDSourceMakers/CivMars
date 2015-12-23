using CivMarsEngine;

namespace CivMars
{
	class Resin : Item, IRegystratabe
	{

		new public string name = "ControlCircuit";


		public Resin(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public Resin()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
		}
	}
}