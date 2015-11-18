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

	public static Dictionary<String, List<Recipe>> recepies = new Dictionary<String, List<Recipe>>();

	public static void RegisterRecepie(string ID, Recipe b)
	{
		if (recepies.ContainsKey(ID))
		{
			recepies[ID].Add(b);
		}
		else
		{
			recepies.Add(ID, new List<Recipe>());
			recepies[ID].Add(b);
		}
	}

	public static Dictionary<String, Item> items = new Dictionary<String, Item>();

	public static void RegisterItem(string ID, Item b)
	{
		if (recepies.ContainsKey(ID))
		{
			throw new System.NotImplementedException();
		}
		else
		{
			if (b is IRegystratabe)
				((IRegystratabe)b).Regystrate();
			items.Add(ID, b);
		}
	}
}

