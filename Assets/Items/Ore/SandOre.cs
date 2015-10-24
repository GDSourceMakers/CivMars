using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SandOre : Item
{

	public SandOre(int am) : base(am)
	{
		maxStackSize = 4;
	}

	public SandOre()
	{
		maxStackSize = 4;
	}
}
