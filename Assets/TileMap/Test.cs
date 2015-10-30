using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

	public GameObject test;
	public TileMap m;

	// Use this for initialization
	void Start()
	{
		System.Random r = new System.Random(987);
        GetComponent<AssetsLoader>().CallRegister();
		foreach (IWorldGen item in GameRegystry.ores)
		{
			item.Generate(r, m);
		}

	}

	// Update is called once per frame
	void Update()
	{

	}
}
