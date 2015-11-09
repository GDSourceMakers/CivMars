using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class CoalOre : Item
{
	public CoalOre(int am) : base(am, 4)
	{
		maxStackSize = 4;
	}

	public CoalOre()
	{
		maxStackSize = 4;
	}

}

