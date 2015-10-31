using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CoalOreTile : OreTile
{
	public override void Generate(System.Random r, TileMap map)
	{
		chanche = 10;
		chanche2 = 120;
		chancheReduce = 20;
		distance = -1;
		base.Generate(r, map);
	}

	override public void Regystrate()
	{
		GameRegystry.RegisterWorldGen(this);
	}

	public override float GetMiningTime()
	{
		return 5f;
	}
}
