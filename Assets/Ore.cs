
public class Ore : Tile
{
    public Tile[,] Spread(Tile[,] map, float h, System.Random rnd, float reduce)
    {
        int l = (int)System.Math.Sqrt(map.Length);

        if (x != l - 1)
        {
            if ((int)map[x + 1, y].type < (int)base.type)
            {
                if (rnd.Next(0, 100) >= h)
                {
                    map[x + 1, y] = null;
                    map[x + 1, y] = new Ore(base.type, x + 1, y);

                    map = ((Ore)map[x + 1, y]).Spread(map, h + reduce, rnd, reduce);
                }
            }
        }
        if (x != 0)
        {
            if ((int)map[x - 1, y].type < (int)base.type)
            {
                if (rnd.Next(0, 100) >= h)
                {
                    map[x - 1, y] = null;
                    map[x - 1, y] = new Ore(base.type, x - 1, y);

                    map = ((Ore)map[x - 1, y]).Spread(map, h + reduce, rnd, reduce);
                }
            }
        }
        if (y != l - 1)
        {
            if ((int)map[x, y + 1].type < (int)base.type)
            {
                if (rnd.Next(0, 100) >= h)
                {
                    map[x, y + 1] = null;
                    map[x, y + 1] = new Ore(base.type, x, y + 1);

                    map = ((Ore)map[x, y + 1]).Spread(map, h + reduce, rnd, reduce);
                }
            }
        }
        if (y != 0)
        {
            if ((int)map[x, y - 1].type < (int)base.type)
            {
                if (rnd.Next(0, 100) >= h)
                {
                    map[x, y - 1] = null;
                    map[x, y - 1] = new Ore(base.type, x, y - 1);

                    map = ((Ore)map[x, y - 1]).Spread(map, h + reduce, rnd, reduce);
                }
            }
        }

        return map;
    }


    public Ore(OreType gettype, int xpos, int ypos)
        : base(gettype, xpos, ypos)
    {


    }

    public Ore(System.Random rnk, int xpos, int ypos)
        : base(xpos, ypos)
    {
        this.type = (OreType)rnk.Next(1, 6);


    }
}
