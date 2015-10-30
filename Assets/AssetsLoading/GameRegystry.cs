using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


static class GameRegystry
{
	public static List<IBuildable> buildableBuildings = new List<IBuildable>();

	public static void RegisterBuildableBuilding(IBuildable b)
	{
		buildableBuildings.Add(b);
	}


	public static List<IWorldGen> ores = new List<IWorldGen>();

	public static void RegisterWorldGen(IWorldGen b)
	{
		ores.Add(b);
	}

	public static List<Tiled> buildings = new List<Tiled>();

	public static void RegisterBuilding(Tiled b)
	{
		buildings.Add(b);
	}
}

