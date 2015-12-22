using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;

namespace CivMars
{
	class Transistor : Item, IRegystratabe
	{
		public string name = "Transistor";


		public Transistor(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public Transistor()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new SiliconRod(2)};
			Recipe r = new Recipe("CivMars.Press", a, new Transistor(1), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}
