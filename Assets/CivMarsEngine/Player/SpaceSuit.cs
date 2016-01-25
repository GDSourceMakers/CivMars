using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine
{
	class SpaceSuit : IGasTank
	{
		static float[] maxs = { 200f, 200f };
		GasTankCluster tanks = new GasTankCluster(2, maxs);

		public Gas Add(Gas i, int index)
		{
			return tanks.AddGas(i, index);
		}

		public string GetInventoryName()
		{
			return "SpaceSuit";
		}

		public GasTank GetTank(int index)
		{
			return tanks.GetTank(index);
		}

		public int GetTankCount()
		{
			return tanks.size;
		}

		public bool HasCustomInventoryName()
		{
			return true;
		}

		public bool IsGasValidForSlot(int slot, Gas givenGas)
		{
			throw new NotImplementedException();
		}

		public bool IsUseableByPlayer(Player p)
		{
			throw new NotImplementedException();
		}

		public Gas RemoveGas(Gas i, int index)
		{
			return tanks.RemoveGas(i, index);
		}

		public void TransferGas(IGasTank ToInv, int index)
		{
		}

		public void TransferGasAmount(IGasTank ToInv, int fromindex, int transferingAmount)
		{
			throw new NotImplementedException();
		}
	}
}