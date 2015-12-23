using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;

namespace CivMars
{
	class RadioTransmitterChip : Item, IRegystratabe
	{
		public string name = "RadioTransmitterChip";


		public RadioTransmitterChip(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public RadioTransmitterChip()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
			Item[] a = { new SiliconRod(1), new CopperIngot(1) };
			Recipe r = new Recipe("CivMars.Press", a, new RadioTransmitterChip(1), 100);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}
