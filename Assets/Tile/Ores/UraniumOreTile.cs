using UnityEngine;
using System.Collections;

public class UraniumOreTile : OreTile
{

	public override void Generate(System.Random r, TileMap map)
	{
		chanche = 0.1f;
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
		return 14f;
	}
}