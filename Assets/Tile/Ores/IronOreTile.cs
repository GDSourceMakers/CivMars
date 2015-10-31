using UnityEngine;
using System.Collections;

public class IronOreTile : OreTile
{

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
}
