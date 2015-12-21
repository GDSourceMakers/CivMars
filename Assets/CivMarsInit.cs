using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMars
{
	[Mod]
	public static class CivMarsInit
	{
		public const string ModSpace = "CivMars";
		public const string BlockSpace = "CivMars.block";
		public const string ItemSpace = "CivMars.item";

		[ModInit]
		public static void Init()
		{
			GameRegystry.RegisterItem("CivMars.IronIngot", new IronIngot());
			GameRegystry.RegisterItem("CivMars.IronPlate", new IronPlate());
			GameRegystry.RegisterItem("CivMars.GlassPlane", new GlassPlane());
			GameRegystry.RegisterItem("CivMars.IronPipe", new IronPipe());
			//GameRegystry.RegisterItem("CivMars.StoneBrick", new StoneBrick());
			//GameRegystry.RegisterItem("CivMars.InteriorPlate", new InteriorPlate());
			//GameRegystry.RegisterItem("CivMars.Roof", new Roof());
			//GameRegystry.RegisterItem("CuvMars.ControlCircuit", new ControlCircuit());
			//GameRegystry.RegisterItem("CuvMars.Piston", new Piston());
			//GameRegystry.RegisterItem("CuvMars.OxygenTank", new OxygenTank());

			GameObject[] goBuild = Resources.LoadAll<GameObject>("Buildings");

			foreach (GameObject item in goBuild)
			{
				IRegystratabe a = item.GetComponent<IRegystratabe>();

				if (a != null)
				{
					a.Regystrate();
				}
			}

			GameObject[] goTiles = Resources.LoadAll<GameObject>("GeneratedTiles");

			foreach (GameObject item in goTiles)
			{
				IRegystratabe a = item.GetComponent<IRegystratabe>();

				if (a != null)
				{
					a.Regystrate();
				}
			}
		}


	}

}