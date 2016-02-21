using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;

namespace CivMars
{
	class Oxigen : Gas
	{
		public string ID = CivMarsInit.GasSpace + ".Oxigen";
		public string name = "Oxigen";

		public float amount;

		public Oxigen()
		{

		}

		public Oxigen(float setAmount)
		{
			amount = setAmount;
		}

		//public void Regystrate() { }
	}
}
