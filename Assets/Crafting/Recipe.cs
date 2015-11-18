using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Recipe
{
	public string buildingID;
	public Item[] Materials;
	public Item Crafted;

	public Recipe(string ID, Item[] m, Item c)
	{
		buildingID = ID;
		Materials = m;
		Crafted = c;
	}
}

