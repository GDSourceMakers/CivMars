
using CivMarsEngine;

namespace CivMars
{
	class CopperOre : Item, IRegystratabe
	{

		public string name = "ControlCircuit";


		public CopperOre(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public CopperOre()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
		}
	}
}
