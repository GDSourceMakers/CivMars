using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CraftingProcess
{
	public Recipe recipe;
	public float status;
	public bool hasItems;
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
				if (r_materials[i] == 0 && k != false)
				{
					k = true;
				}
				else
				{
					k = false;
				}
			}
			hasItems = k;
		}
	}

	public CraftingProcess(Recipe r)
	{
		recipe = r;
		status = r.time;
		materials = new int[r.Materials.Length];
		for (int i = 0; i < r.Materials.Length; i++)
		{
			materials[i] = r.Materials[i].amount;
		}
	}
}

