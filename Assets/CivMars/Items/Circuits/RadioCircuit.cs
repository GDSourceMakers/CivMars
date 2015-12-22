using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;

namespace CivMars
{
	class RadioCircuit : Item, IRegystratabe
	{
		public string name = "ControlCircuit";


		public RadioCircuit(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public RadioCircuit()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new RadioTransmitterChip(1), new Transistor(5) };
			Recipe r = new Recipe("CivMars.Press", a, new SiliconRod(1), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}
