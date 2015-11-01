using UnityEngine;
using System.Collections;
using System;

public class IronOreTile : OreTile
{
	new float amount = 2f;

	static Type item = typeof(IronOre);

	public override void Generate(System.Random r, TileMap map)
	{
		chanche = 1;
		chanche2 = 40;
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
		return 7f;
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
