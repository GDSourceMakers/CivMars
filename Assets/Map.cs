using UnityEngine;
using System.Collections;
using System.IO;

public class Map : MonoBehaviour
{
	public int seed;
	public int mapHeight = 100;

	public Vector3 posMultiplyer;
	public Tiled[,] mapBuilt = new Tiled[100, 100];

	public TileMap mapManagger;

	// Use this for initialization
	void Start()
	{
		//mapGenerated = new GeneratedTile[mapHeight, mapHeight];

		//mapBuilt = new Building[mapHeight, mapHeight];
	}



	public void BuildMap()
	{
		//987, 
		System.Random r = new System.Random(098);
		foreach (IWorldGen item in GameRegystry.ores)
		{
			item.Generate(r, mapManagger);
		}
	}

	public void AddBasicBuildings()
	{
		int xMpos;
		xMpos = ((int)Mathf.Floor((float)mapHeight / 2));

		Debug.Log(MainBuilding.ID);
		mapBuilt[xMpos, xMpos] = Instantiate(GameRegystry.buildings[MainBuilding.ID-1].gameObject).GetComponent<MainBuilding>();
		mapBuilt[xMpos, xMpos].transform.position = new Vector3(xMpos, -xMpos, -2) + posMultiplyer;
        mapBuilt[xMpos + 5, xMpos - 5] = Instantiate(GameRegystry.buildableBuildings[Chest.ID-2].GetPrefab()).GetComponent<Chest>();
		mapBuilt[xMpos + 5, xMpos - 5].transform.position = new Vector3(xMpos + 5, -(xMpos - 5),-2) +posMultiplyer;
	}

	

	// Update is called once per frame
	void Update()
	{

	}

	public void MapUpdate(int x, int y, Map map)
	{
		mapManagger.RemoveTile(x, y);
	}
}
