using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace CivMarsEngine
{
	public class GasTank: IGasTank
	{
		public Gas gas;

		public float amount;
		public float maxAmount;
		public bool locked;

		public GasTank(float max)
		{
			this.maxAmount = max;
		}

		public GasTank(float max, bool l, Gas g)
		{
			this.maxAmount = max;
			locked = l;
			gas = g;
		}

		public bool IsGasValidForSlot(int slot, Gas givenGas)
		{
			if (gas.GetType() == givenGas.GetType())
			{
				return true;
			}
			else if (gas.GetType() == null)
			{
				return true;
			}
			return false;
		}

		public Gas AddGas(Gas g, int i)
		{
			if (gas == null || g.GetType() == gas.GetType())
			{
				if (gas == null)
				{
					gas = g;
					gas.amount = 0;
				}
				gas.amount += g.amount;
				if (gas.amount <= maxAmount)
				{
					g.amount = 0;
					return g;
				}
				else
				{
					float reamaining = gas.amount - maxAmount;
					gas.amount = maxAmount;

					g.amount = reamaining;
					return g;
                }
			}
			return g;
		}

		public Gas RemoveGas(Gas g, int i)
		{
			if (g.GetType() == gas.GetType() || gas.GetType() == null)
			{
				float old = gas.amount;
				gas.amount -= g.amount;
				if (gas.amount >= 0)
				{
					g.amount = 0;
                    return g;
				}
				else
				{
					float reamaining = g.amount - old;
					gas.amount = 0;
					if (!locked)
					{
						gas = null;
					}
					g.amount = reamaining;
					return g;
				}
			}
			return g;
		}


		public void SetLocked(bool a)
		{
			locked = a;
		}

		public int GetTankCount()
		{
			return 1;
		}

		public string GetGasInventoryName()
		{
			return "asd";
		}

		public bool HasCustomGasInventoryName()
		{
			return true;
		}

		public bool IsUseableByPlayer(Player p)
		{
			throw new NotImplementedException();
		}

		public void TransferGas(IGasTank ToInv, int index, int thisIndex)
		{
			throw new NotImplementedException();
		}

		public void TransferGasAmount(IGasTank ToInv, int toIndex, int thisIndex, int transferingAmount)
		{
			if (ToInv.IsGasValidForSlot(toIndex, this.gas))
			{
				Gas rem = (((Gas)Activator.CreateInstance(null, gas.GetType().ToString()).Unwrap()));
				rem = this.RemoveGas(rem, 0);
				if (rem.amount == 0)
				{
					rem.amount = transferingAmount;
					ToInv.AddGas(rem, toIndex);
				}
				else
				{
					ToInv.AddGas(rem, toIndex);
				}
			}
		}

		public Gas GetGas(int index)
		{
			return gas;
		}

		public float GetMaxAmount(int index)
		{
			return maxAmount;
		}
	}
}