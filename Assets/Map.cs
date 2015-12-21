using UnityEngine;
using System.Collections;
using System.IO;

public class Map : MonoBehaviour
{
	public int seed;
	public int mapHeight = 100;

	public Vector3 posMultiplyer;

	public TileMap Generated;
	public TileMap GeneratedReloaded;
	public TileMap Buildings;

	public SavedMapData mapData;

	// Use this for initialization
	void Start()
	{
		//mapGenerated = new GeneratedTile[mapHeight, mapHeight];

		//mapBuilt = new Building[mapHeight, mapHeight];
	}



	public void BuildMap()
	{
		//987, 
		System.Random r = new System.Random(mapData.seed);

		foreach (IWorldGen item in GameRegystry.ores.Values)
		{
			item.Generate(r, Generated);
		}

		/*
		SavedMap a = new SavedMap(this);
		a.Save("./Map.bin");

		SavedMap b = new SavedMap("./Map.bin", this);
		b.LoadFromSave();
		*/

	}

	public void AddBasicBuildings()
	{
		int xMpos;
		xMpos = mapHeight / 2;

		TileTransform mainBuilding = Instantiate(GameRegystry.buildings[CivMars.MainBuilding.ID].gameObject).GetComponent<TileTransform>();
		Buildings.SetTile(xMpos, xMpos, mainBuilding);

		TileTransform chest = Instantiate(GameRegystry.buildings[CivMars.Chest.ID].gameObject).GetComponent<TileTransform>();
		Buildings.SetTile(xMpos+5, xMpos+5, chest);

	}


	public SavedMapData Save()
	{
		for (int i = 0; i < mapHeight; i++)
		{
			for (int j = 0; j < mapHeight; j++)
			{
				TileTransform tile = Generated.GetTileOn(i, j);
				if (tile != null)
				{
					Tiled t = tile.GetComponent<Tiled>();

					if (t is ISaveble)
					{
						mapData.GeaneratedTiles[i, j] = ((ISaveble)t).Save();
					}
				}


				tile = Buildings.GetTileOn(i, j);
				if (tile != null)
				{
					Tiled t = tile.GetComponent<Tiled>();

					if (t is ISaveble)
					{
						mapData.BuildingTiles[i, j] = ((ISaveble)t).Save();
					}
				}
			}
		}

		return mapData;
	}

	public void LoadMap(SavedMapData savedMap)
	{
		mapData = savedMap;
		if (mapData.generated)
		{
			for (int i = 0; i < mapData.height; i++)
			{
				for (int j = 0; j < mapData.height; j++)
				{
					SavedTile tile = mapData.GeaneratedTiles[i, j];
					if (tile != null)
					{
						if (tile is SavedOre)
						{
							TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.ores[tile.ID]).GetPrefab()).GetComponent<TileTransform>();
							Generated.SetTile(i, j, trans);
						}
					}

					tile = mapData.BuildingTiles[i, j];
					if (tile != null)
					{
						TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.buildings[tile.ID]).GetPrefab()).GetComponent<TileTransform>();
						Buildings.SetTile(i, j, trans);
					}
				}
			}
		}
		else
		{
			BuildMap();
			AddBasicBuildings();
			mapData.SetSize(mapHeight);
			mapData.generated = true;
		}
	}

}
