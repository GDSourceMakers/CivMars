using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace CivMarsEngine
{
	public class GasTank
	{
		public GasType gasType;
		public float amount;
		public float maxAmount;
		public bool locked;

		public GasTank(float max)
		{
			this.maxAmount = max;
		}

		public bool CanAccept()
		{
			return true;
		}

		public float AddAmount(float addAmount)
		{
			amount += addAmount;
			if (amount <= maxAmount)
			{
				return 0;
			}
			else
			{
				float reamaining = amount - maxAmount;
				amount = maxAmount;
				return reamaining;
			}
		}

		public float AddAmount(float addAmount, GasType t)
		{
			if (t == gasType)
			{
				return AddAmount(addAmount);
			}
			else if (amount == 0 && gasType == GasType.Null)
			{
				gasType = t;
				return AddAmount(addAmount);
			}
			return -1;
		}

		public float RemoveAmount(float remAmount)
		{
			float old = amount;
			amount -= remAmount;
			if (amount >= 0)
			{
				return 0;
			}
			else
			{
				float reamaining = remAmount - old;
				amount = 0;
				if (!locked)
				{
					gasType = GasType.Null;
				}
				return reamaining;
			}
		}

		public void RemoveAmount(float remAmount, GasType t)
		{
			if (t == gasType)
			{
				RemoveAmount(remAmount);
			}
		}

		public void Transfer(GasTank other, float transAmount)
		{
			GasType b = gasType;
			if (other.gasType == gasType || other.gasType == GasType.Null)
			{
				float rem = this.RemoveAmount(transAmount);
				if (rem == 0)
				{
					other.AddAmount(transAmount, b);
				}
				else
				{
					Debug.Log(rem);
					other.AddAmount(rem, b);
				}
			}
		}

		public void SetLocked(bool a)
		{
			locked = a;
		}
	}
}