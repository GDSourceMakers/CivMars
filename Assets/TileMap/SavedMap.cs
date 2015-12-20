/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

class SavedMap
{
	Map RealMap;
	SavedMapData mapdata;

	public SavedMap(Map m)
	{
		RealMap = m;
		//mapdata = new SavedMapData();
		mapdata.height = m.mapHeight;
		mapdata.GeaneratedTiles = new SavedTile[m.mapHeight, m.mapHeight];
	}

	public SavedMap(string path, Map map)
	{
		RealMap = map;
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		SavedMapData obj = (SavedMapData)formatter.Deserialize(stream);
		mapdata = obj;
		stream.Close();
	}

	public void Refresh()
	{
		for (int i = 0; i < RealMap.mapHeight; i++)
		{
			for (int j = 0; j < RealMap.mapHeight; j++)
			{
				TileTransform tile = RealMap.Generated.GetTileOn(i, j);
				if (tile != null)
				{
					Tiled t = tile.GetComponent<Tiled>();

					if (t is ISaveble)
					{
						mapdata.GeaneratedTiles[i, j] = ((ISaveble)t).Save();
					}
				}


				tile = RealMap.Buildings.GetTileOn(i, j);
				if (tile != null)
				{
					Tiled t = tile.GetComponent<Tiled>();

					if (t is ISaveble)
					{
						mapdata.BuildingTiles[i, j] = ((ISaveble)t).Save();
					}
				}
			}
		}
	}

	public void LoadFromSave()
	{
		for (int i = 0; i < mapdata.height; i++)
		{
			for (int j = 0; j < mapdata.height; j++)
			{
				SavedTile tile = mapdata.GeaneratedTiles[i, j];
				if (tile != null)
				{
					if (tile is SavedOre)
					{
						TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.ores[tile.ID]).GetPrefab()).GetComponent<TileTransform>();
                        RealMap.GeneratedReloaded.SetTile(i, j, trans);
					}
				}

				tile = mapdata.BuildingTiles[i, j];
				if (tile != null)
				{
					TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.ores[tile.ID]).GetPrefab()).GetComponent<TileTransform>();
					RealMap.Buildings.SetTile(i, j, trans);
				}
			}
		}
	}

	public void Save(string path)
	{
		Refresh();

		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
		formatter.Serialize(stream, mapdata);
		stream.Close();
	}
}

*/