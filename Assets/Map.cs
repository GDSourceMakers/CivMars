using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Map
{
    public int mapHeight;
    public GeneratedTile[,] mapGenerated;
    public Building[,] mapBuilt;

    public int seed;

    public Map(GeneratedTile[,] inmap)
    {
       this.mapHeight = (int)Math.Sqrt(inmap.Length);

       this.mapGenerated = new GeneratedTile[mapHeight, mapHeight];

        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                mapGenerated[i, j] = inmap[i, j];
            }
        }
        mapBuilt = new Building[mapHeight, mapHeight];

        int xMpos;
        xMpos = ((int)Math.Floor((double)mapHeight / 2));

        mapBuilt[xMpos, xMpos] = new MainBuilding(xMpos, xMpos);
    }

    public Map()
    {}
}
