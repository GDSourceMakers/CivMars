using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine.Registry
{
    static class GameRegystry
	{
		//public static Dictionary<string, IRegystratabe> all = new Dictionary<string, IRegystratabe>();



		public static Dictionary<string, Tile> tiels = new Dictionary<string, Tile>();

		public static Dictionary<string, IWorldGen> worldGen = new Dictionary<string, IWorldGen>();

		public static Dictionary<string, List<Recipe>> recepies = new Dictionary<String, List<Recipe>>();

		public static Dictionary<string, Item> items = new Dictionary<String, Item>();

		public static void RegisterTile(string ID, Tile b)
		{
			if (b is Tile)
			{
				tiels.Add(ID, b);
				Debug.Log(ID);
			}
		}

		public static void RegisterItem(string ID, Item b)
		{
			if (recepies.ContainsKey(ID))
			{
				throw new System.NotImplementedException();
			}
			else
			{
				if (b is IRegystratabe)
				{
					((IRegystratabe)b).Regystrate();
				}
				items.Add(ID, b);
				Debug.Log(ID);
			}
		}

		public static void RegisterWorldGen(string ID, IWorldGen b)
		{
			worldGen.Add(ID, b);
			Debug.Log(b.ToString());
		}

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