using UnityEngine;
using System.Collections;
using System;

public class StoneOreTile : OreTile
{
	public string ID = CivMarsInit.BlockSpace + ".StoneOre";

	static Type item = typeof(StoneOre);

	override public void Regystrate()
	{
		chanche = 20;
		chanche2 = 220;
		chancheReduce = 20;
		distance = -1;
		GameRegystry.RegisterWorldGen(ID, this);
	}

	public override void Generate(System.Random r, TileMap map)
	{
		base.Generate(r, map);
	}

	public override float GetMiningTime()
	{
		return 4.5f;
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
