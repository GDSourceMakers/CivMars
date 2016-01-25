using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace CivMarsEngine
{
	public class GasTank: IGasTank
	{
		public GasType gasType;

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

		public bool CanAccept(Gas g)
		{
			if (gas.GetType() == g.GetType())
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
			if (g.GetType() == gas.GetType() || gas.GetType() == null)
			{
				amount += g.amount;
				if (amount <= maxAmount)
				{
					g.amount = 0;
					return g;
				}
				else
				{
					float reamaining = amount - maxAmount;
					amount = maxAmount;

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
				float old = amount;
				amount -= g.amount;
				if (amount >= 0)
				{
					g.amount = 0;
                    return g;
				}
				else
				{
					float reamaining = g.amount - old;
					amount = 0;
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

		public void SetLocked(bool a)
		{
			locked = a;
		}

		public int GetTankCount()
		{
			return 1;
		}

		public string GetInventoryName()
		{
			return "asd";
		}

		public bool HasCustomInventoryName()
		{
			return true;
		}

		/*
		public GasTank GetTank(int index)
		{
			throw new NotImplementedException();
		}
		*/

		public bool IsGasValidForSlot(int slot, Gas givenGas)
		{
			throw new NotImplementedException();
		}

		public bool IsUseableByPlayer(Player p)
		{
			throw new NotImplementedException();
		}

		public void TransferGas(IGasTank ToInv, int index, int thisIndex)
		{
			throw new NotImplementedException();
		}
	}
}