using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine
{
	public class GasTankCluster: IGasTank
	{
		GasTank[] tanks;

		public int size;

		#region Constructor

		public GasTankCluster(int i, float max)
		{
			tanks = new GasTank[i];

			size = i;
			for (int k = 0; k < i; k++)
			{
				tanks[k] = new GasTank(max);
			}
		}

		public GasTankCluster(int i, float[] max)
		{
			tanks = new GasTank[i];

			size = i;
			for (int k = 0; k < i; k++)
			{
				tanks[k] = new GasTank(max[k]);
			}
		}

		public GasTankCluster(GasTank[] t)
		{
			tanks = t;
		}

		#endregion

		public Gas AddGas(Gas g, int index)
		{
			return tanks[index].AddAmount(g);
		}

		public Gas RemoveGas(Gas g, int index)
		{
			return tanks[index].RemoveAmount(g);
		}

		public GasTank GetTank(int i)
		{
			return tanks[i];
		}

		public GasTank GetTank(Gas i)
		{
			foreach (GasTank item in tanks)
			{
				if (item.gas.GetType() == i.GetType())
				{
					return item;
				}
			}
			return null;

		}

		public List<GasTank> GetTanks(Gas i)
		{
			List<GasTank> a = new List<GasTank>();

			foreach (var item in tanks)
			{
				if (item.gas.GetType() == i.GetType())
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

		public int GetTankCount()
		{
			return size;
		}

		public string GetInventoryName()
		{
			return "Unnamed gas tank";
		}

		public bool HasCustomInventoryName()
		{
			return true;
		}

		public bool IsGasValidForSlot(int slot, Gas givenGas)
		{
			return tanks[slot].CanAccept(givenGas);
		}

		public bool IsUseableByPlayer(Player p)
		{
			return true;
		}

		public void TransferGas(IGasTank ToInv, int index)
		{
			tanks[index].Transfer(ToInv, tanks[index].amount);
		}

		public void TransferGasAmount(IGasTank ToInv, int fromindex, int transferingAmount)
		{
			throw new NotImplementedException();
		}
	}
}