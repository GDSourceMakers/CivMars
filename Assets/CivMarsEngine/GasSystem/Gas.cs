using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivMarsEngine
{
	public class Gas : IRegystratabe
	{
		public string ID;
		public string name;

		public float amount;

		public Gas()
		{

		}

		public Gas(float setAmount)
		{
			amount = setAmount;
		}

		public void Regystrate() { }
	}
}
