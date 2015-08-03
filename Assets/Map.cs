using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Map
{
    public int mapHeight;
    public Tile[, ,] mapArray;
    public int seed;

    public Map(Tile[,] inmap)
    {
       this.mapHeight = (int)Math.Sqrt(inmap.Length);

        this.mapArray = new Tile[mapHeight, mapHeight, 2];

        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                mapArray[i, j, 0] = inmap[i, j];
            }
        }
    }

    public Map()
    {}
}
