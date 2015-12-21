using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMars
{
	public class InteriorPlate : Item, IRegystratabe
	{
		public string name = "InteriorPlate";

		public InteriorPlate(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.InteriorPlate");
			maxStackSize = 30;
		}

		public InteriorPlate()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.InteriorPlate");
			maxStackSize = 30;
		}

		public void Regystrate()
		{

			Item[] a = { new IronPlate(2), new GlassPlane(1) };
			Recipe r = new Recipe("CivMars.Press", a, new InteriorPlate(5), 10);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}

}