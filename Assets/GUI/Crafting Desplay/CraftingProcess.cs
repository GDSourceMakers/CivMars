using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CraftingProcess
{
	public Recipe recipe;
	public float status;
	//bool hasItems = false;

	int[] r_materials;
	public int[] materials
	{
		get
		{
			return r_materials;
		}

		set
		{
			r_materials = value;
			bool k = true;
			for (int i = 0; i < recipe.Materials.Length; i++)
			{
				if (r_materials[i] != 0)
				{
					k = false;
				}
			}
		}
	}

	public int amount;

	public CraftingProcess(Recipe r, int am)
	{
		recipe = r;
		status = r.time;
		materials = new int[r.Materials.Length];
		for (int i = 0; i < r.Materials.Length; i++)
		{
			materials[i] = r.Materials[i].amount;
		}
		amount = am;
	}

	public bool HasItems()
	{
		for (int i = 0; i < recipe.Materials.Length; i++)
		{
			if (r_materials[i] != 0)
			{
				return false;
			}
		}

		return true;
	}
}

