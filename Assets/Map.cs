using UnityEngine;
using System.Collections;
using System.IO;

public class Map : MonoBehaviour
{
	public int seed;
	public int mapHeight = 100;

	public Vector3 posMultiplyer;

	public TileMap Generated;
	public TileMap Buildings;


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
			item.Generate(r, Generated);
		}
	}

	public void AddBasicBuildings()
	{
		int xMpos;
		xMpos = mapHeight / 2;

		TileTransform mainBuilding = Instantiate(GameRegystry.buildings[MainBuilding.ID].gameObject).GetComponent<TileTransform>();
		Buildings.SetTile(xMpos, xMpos, mainBuilding);

		TileTransform chest = Instantiate(GameRegystry.buildings[Chest.ID].gameObject).GetComponent<TileTransform>();
		Buildings.SetTile(xMpos+5, xMpos+5, chest);

	}

	// Update is called once per frame
	void Update()
	{

	}

}
