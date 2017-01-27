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

		public GasTankCluster(int count, float max)
		{
			tanks = new GasTank[count];

			size = count;
			for (int k = 0; k < count; k++)
			{
				tanks[k] = new GasTank(max);
			}
		}

		public GasTankCluster(int count, float[] max)
		{
			tanks = new GasTank[count];

			size = count;
			for (int k = 0; k < count; k++)
			{
				tanks[k] = new GasTank(max[k]);
			}
		}

		public GasTankCluster(GasTank[] t)
		{
			tanks = t;
		}

		#endregion


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

		#region IGasTank

		public Gas AddGas(Gas g, int index)
		{
			return tanks[index].AddGas(g,index);
		}

		public Gas RemoveGas(Gas g, int index)
		{
			return tanks[index].RemoveGas(g,index);
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

		public string GetGasInventoryName()
		{
			return "Unnamed gas tank";
		}

		public bool HasCustomGasInventoryName()
		{
			return true;
		}

		public bool IsGasValidForSlot(int slot, Gas givenGas)
		{
			return tanks[slot].IsGasValidForSlot(0,givenGas);
		}

		public bool IsUseableByPlayer(Player p)
		{
			return true;
		}

		public void TransferGas(IGasTank ToInv, int toIndex, int thisIndex)
		{
			tanks[thisIndex].TransferGas(ToInv, toIndex, thisIndex);
		}

		public void TransferGasAmount(IGasTank ToInv, int toIndex, int thisIndex, int transferingAmount)
		{
			tanks[thisIndex].TransferGasAmount(ToInv, toIndex, thisIndex, transferingAmount);
        }

		public Gas GetGas(int index)
		{
			return tanks[index].gas;
		}

		public float GetMaxAmount(int index)
		{
			return tanks[index].maxAmount;
		}

		#endregion
	}
}