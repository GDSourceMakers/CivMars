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

}

