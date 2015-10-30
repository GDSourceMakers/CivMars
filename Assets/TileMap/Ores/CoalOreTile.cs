using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CoalOreTile : OreTile2
{
	static int chanche = 500;
	static int chanche2 = 800;
	static int chancheReduce = 100;
	static int distance = 20;

	override public void Regystrate()
	{
		GameRegystry.RegisterWorldGen(this);
	}
}
