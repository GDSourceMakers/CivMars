using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class SavedMapData
{
	public SavedTile[,] GeaneratedTiles;
	public SavedTile[,] BuildingTiles;
	public int height;
	public int seed;
	public string name;

	public bool generated;

	public SavedMapData(int s, string n)
	{
		seed = s;
		name = n;
	}

	public SavedMapData(int s, string n, int h)
	{
		seed = s;
		name = n;
		height = h;
		height = h;
		GeaneratedTiles = new SavedTile[h, h];
		BuildingTiles = new SavedTile[h, h];
	}

	public void SetSize(int h)
	{
		height = h;
		GeaneratedTiles = new SavedTile[h, h];
		BuildingTiles = new SavedTile[h, h];
	}

	public SavedMapData.DisplayDeteals GetDeteails()
	{
		return new SavedMapData.DisplayDeteals(this);
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

