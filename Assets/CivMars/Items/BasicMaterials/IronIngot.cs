using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;
using UnityEngine;
namespace CivMars
{
	public class IronIngot : Item, IRegystratabe
	{
		public string name = "IronIngot";


		public IronIngot(int am) : base(am, 10)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.StealIngot");
			maxStackSize = 10;
		}

		public IronIngot()
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.StealIngot");
			maxStackSize = 10;
		}

		public void Regystrate()
		{

			Item[] a = { new IronOre(2) };
			Recipe r = new Recipe("CivMars.Furnace", a, new IronIngot(1), 10);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}


}