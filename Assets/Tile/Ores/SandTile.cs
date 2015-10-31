using UnityEngine;
using System.Collections;

public class SandTile : OreTile {

	static float miningTime = 0.2f;

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

}
