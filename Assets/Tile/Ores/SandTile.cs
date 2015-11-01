using UnityEngine;
using System.Collections;
using System;

public class SandTile : OreTile
{
	new float amount = 2f;

	static Type item = typeof(SandOre);

	override public void Regystrate()
	{
		GameRegystry.RegisterWorldGen(this);
	}

	public override void Generate(System.Random r, TileMap map)
	{
		chanche = 30;
		chanche2 = 150;
		chancheReduce = 20;
		distance = -1;
		base.Generate(r, map);
	}

	public override float GetMiningTime()
	{
		return 4f;
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
