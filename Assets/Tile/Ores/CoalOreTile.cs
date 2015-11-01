using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CoalOreTile : OreTile
{
	new float amount = 2f;

	static Type item = typeof(CoalOre);

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

	public override Type GetItemType()
	{
		return item;
	}

	public override bool Mine(int remAmount)
	{
		amount -= remAmount;
		if (amount <= 0)
		{
			transform.tileMap.RemoveTile(transform.position);
			return true;
		}
		return false;
	}

	public override float GetAmountLeft()
	{
		return amount;
	}
}
