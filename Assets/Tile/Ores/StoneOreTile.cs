using UnityEngine;
using System.Collections;

public class StoneOreTile : OreTile
{

	static float miningTime = 0.2f;

	override public void Regystrate()
	{
		GameRegystry.RegisterWorldGen(this);
	}

	public override void Generate(System.Random r, TileMap map)
	{
		chanche = 20;
		chanche2 = 220;
		chancheReduce = 20;
		distance = -1;
		base.Generate(r, map);
	}

	public override float GetMiningTime()
	{
		return 4.5f;
	}

}
