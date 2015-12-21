using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMars
{
	public class StoneBrick : Item, IRegystratabe
	{
		public string name = "StoneBrick";


		public StoneBrick(int am) : base(am, 100)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.StoneBrick");
			maxStackSize = 100;
		}

		public StoneBrick()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.StoneBrick");
			maxStackSize = 100;
		}

		public void Regystrate()
		{

			Item[] a = { new StoneOre(1) };
			Recipe r = new Recipe("CivMars.Furnace", a, new StoneBrick(10), 10);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}