using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


static class GameRegystry
{
	public static Dictionary<String,Building> buildings = new Dictionary<String, Building>();

	public static void RegisterBuildableBuilding(string ID, Building b)
	{
		if (b is Building)
		{
			buildings.Add(ID, b);
		}
	}


	public static List<IWorldGen> ores = new List<IWorldGen>();

	public static void RegisterWorldGen(IWorldGen b)
	{
		ores.Add(b);
	}
}

