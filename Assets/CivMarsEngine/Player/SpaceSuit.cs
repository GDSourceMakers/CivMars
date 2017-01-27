using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine
{
	//TODO: Should be an item
	public class SpaceSuit : IGasTank
	{
		static float[] maxs = { 200f, 200f };
		GasTankCluster tanks = new GasTankCluster(2, maxs);

		public SpaceSuit()
		{ }

		public Gas AddGas(Gas i, int index)
		{
			return ((IGasTank)tanks).AddGas(i, index);
		}

		public Gas GetGas(int index)
		{
			return ((IGasTank)tanks).GetGas(index);
		}

		public string GetGasInventoryName()
		{
			return ((IGasTank)tanks).GetGasInventoryName();
		}

		public float GetMaxAmount(int index)
		{
			return ((IGasTank)tanks).GetMaxAmount(index);
		}

		public int GetTankCount()
		{
			return ((IGasTank)tanks).GetTankCount();
		}

		public bool HasCustomGasInventoryName()
		{
			return ((IGasTank)tanks).HasCustomGasInventoryName();
		}

		public bool IsGasValidForSlot(int slot, Gas givenGas)
		{
			return ((IGasTank)tanks).IsGasValidForSlot(slot, givenGas);
		}

		public bool IsUseableByPlayer(Player p)
		{
			return ((IGasTank)tanks).IsUseableByPlayer(p);
		}

		public Gas RemoveGas(Gas i, int index)
		{
			return ((IGasTank)tanks).RemoveGas(i, index);
		}

		public void TransferGas(IGasTank ToInv, int index, int thisIndex)
		{
			((IGasTank)tanks).TransferGas(ToInv, index, thisIndex);
		}

		public void TransferGasAmount(IGasTank ToInv, int toIndex, int thisIndex, int transferingAmount)
		{
			((IGasTank)tanks).TransferGasAmount(ToInv, toIndex, thisIndex, transferingAmount);
		}
	}
}