using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMars
{
	public class IronPipe : Item, IRegystratabe
	{
		public string name = "IronPipe";
		public IronPipe(int am) : base(am, 10)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.IronPipe");
			maxStackSize = 10;
		}

		public IronPipe()
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.IronPipe");
			maxStackSize = 10;
		}

		public void Regystrate()
		{

			Item[] a = { new IronOre(4) };
			Recipe r = new Recipe("CivMars.Furnace", a, new IronPipe(1), 20);
			GameRegystry.RegisterRecepie(r.buildingID, r);
		}
	}

}