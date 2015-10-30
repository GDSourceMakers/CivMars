using UnityEngine;
using System.Collections;

public class SandTile : OreTile2 {

	static int chanche = 500;
	static int chanche2 = 800;
	static int chancheReduce = 100;
	static int distance = 20;

	override public void Regystrate()
	{
		GameRegystry.RegisterWorldGen(this);
	}
}
