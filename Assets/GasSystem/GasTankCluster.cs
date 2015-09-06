using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GasTankCluster
{
	GasTank[] tanks;

	public int size;

	public GasTankCluster(int i, float[] max)
	{
		tanks = new GasTank[i];
		size = i;
		for (int k = 0; k < i; k++)
		{
			tanks[k] = new GasTank(max[k]);
		}
	}

	public float AddGas(float rAmount, GasType t)
	{
		float size = rAmount;

		foreach (GasTank item in tanks)
		{

			if (item.gasType != GasType.Null)
			{

				if (item.gasType == t)
				{
					Debug.Log(item.gasType);

					size = item.AddAmount(rAmount);

					Debug.Log("Inventory added: " + item.gasType + " Amount: " + item.amount);
					if (size == 0)
					{
						return 0;
					}
					rAmount = size;
				}
			}
		}

		for (int i = 0; i < 10; i++)
		{
			if (tanks[i] == null)
			{
				tanks[i].AddAmount(rAmount);
				return rAmount;
			}
		}
		if (rAmount == 0)
		{
			return 0;
		}
		else
		{
			return rAmount;
		}
	}


	public GasTank GetTank(int i)
	{
		return tanks[i];
	}

	public GasTank GetTank(GasType i)
	{
		foreach (var item in tanks)
		{
			if (item.gasType == i)
			{
				return item;
			}
		}
		return null;
		
	}

	public List<GasTank> GetTanks(GasType i)
	{
		List<GasTank> a = new List<GasTank>();

		foreach (var item in tanks)
		{
			if (item.gasType == i)
			{
				a.Add(item);
			}
		}
		if (a.Count == 0)
		{
			return null;
		}
		return a;

	}
}
