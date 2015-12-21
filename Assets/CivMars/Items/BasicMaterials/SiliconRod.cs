using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivMars
{
	class SiliconRod : Item, IRegystratabe
	{
		public string name = "ControlCircuit";


		public SiliconRod(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public SiliconRod()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new SandOre(2) };
			Recipe r = new Recipe("CivMars.Press", a, new SiliconRod(1), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}
