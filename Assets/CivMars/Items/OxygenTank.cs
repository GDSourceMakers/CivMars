using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace CivMars
{
	class OxygenTank : Item, IRegystratabe
	{

		public string name = "OxygenTank";


		public OxygenTank(int am) : base(am, 3)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.OxygenTank");
			maxStackSize = 3;
		}

		public OxygenTank()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.OxygenTank");
			maxStackSize = 3;
		}

		public void Regystrate()
		{

			Item[] a = { new IronPlate(2), new GlassPlane(5), new Piston(1), new IronPipe(2) };
			Recipe r = new Recipe("CivMars.Press", a, new OxygenTank(3), 400);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}
}