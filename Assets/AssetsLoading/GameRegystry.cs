using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


static class GameRegystry
{
	public static List<IBuildable> buildings = new List<IBuildable>();

	public static void RegisterBuilding(IBuildable b)
	{
		buildings.Add(b);
	}


	public static List<IWorldGen> ores = new List<IWorldGen>();

	public static void RegisterWorldGen(IWorldGen b)
	{
		ores.Add(b);
	}
}

