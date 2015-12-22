using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine
{
	static class GameRegystry
	{
		public static Dictionary<string, IRegystratabe> all = new Dictionary<string, IRegystratabe>();

		public static Dictionary<String, Building> buildings = new Dictionary<String, Building>();

		public static void RegisterBuildableBuilding(string ID, Building b)
		{
			if (b is Building)
			{
				buildings.Add(ID, b);
				Debug.Log(ID);
			}
		}

		public static Dictionary<string, IWorldGen> ores = new Dictionary<string, IWorldGen>();
		//public static List<IWorldGen> ores = new List<IWorldGen>();

		public static void RegisterWorldGen(string ID, IWorldGen b)
		{
			ores.Add(ID, b);
			Debug.Log(b.ToString());
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
			Debug.Log(ID);
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
				Debug.Log(ID);
			}
		}

		public static Sprite GetSprite(string path, string name)
		{
			UnityEngine.Object[] a = Resources.LoadAll(path);
			foreach (UnityEngine.Object item in a)
			{

				if (item is Sprite && item.name == name)
				{
					return item as Sprite;
				}
			}

			return null;
		}
	}
}