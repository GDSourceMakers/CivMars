using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class SavedMapData
{
	//TODO: Layering
	public SavedTile[,] GeaneratedTiles;
	public SavedTile[,] BuildingTiles;
	public int height;
	public int seed;
	public string name;

	public bool generated;

	public SavedMapData(int setSeed, string setName)
	{
		seed = setSeed;
		name = setName;
	}

	public SavedMapData(int setSeed, string setName, int setHeight)
	{
		seed = setSeed;
		name = setName;
		height = setHeight;
		GeaneratedTiles = new SavedTile[setHeight, setHeight];
		BuildingTiles = new SavedTile[setHeight, setHeight];
	}

	public void SetSize(int h)
	{
		height = h;
		GeaneratedTiles = new SavedTile[h, h];
		BuildingTiles = new SavedTile[h, h];
	}

	public DisplayDeteals GetDeteails()
	{
		return new DisplayDeteals(this);
	}

	[Serializable]
	public class DisplayDeteals
	{
		public string name;
		public int height;
		public int seed;
		public DateTime lastPlayed;
		public string path;

		public DisplayDeteals(SavedMapData m)
		{
			name = m.name;
			seed = m.seed;
			height = m.height;
			path = "./saves/" + m.name + "/" + m.name + ".bin";
		}    
		
	}
}

