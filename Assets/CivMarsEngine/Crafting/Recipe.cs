﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivMarsEngine
{
	public class Recipe
	{
		public string buildingID;
		public Item[] Materials;
		public Item Crafted;
		public float time;


		public Recipe(string ID, Item[] m, Item c, float t)
		{
			buildingID = ID;
			Materials = m;
			Crafted = c;
			time = t;
		}
	}
}