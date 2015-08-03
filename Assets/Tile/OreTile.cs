
public class OreTile : Tile
{
    public float amount;
    public float[] miningTime = {0,4,4.5f,5,7,14,3,3};

    public Tile[,] Spread(Tile[,] map, float h, System.Random rnd, float reduce, float amountReduce)
    {
        int l = (int)System.Math.Sqrt(map.Length);

        float amountnext = amount;

        if (x != l - 1)
        {
            if ((int)map[x + 1, y].type < (int)base.type)
            {
                if (rnd.Next(0, 100) >= h)
                {
                    map[x + 1, y] = null;
                    map[x + 1, y] = new OreTile(base.type, x + 1, y, amountnext);

                    map = ((OreTile)map[x + 1, y]).Spread(map, h + reduce, rnd, reduce,amountReduce);
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
                    map[x - 1, y] = new OreTile(base.type, x - 1, y, amountnext);

                    map = ((OreTile)map[x - 1, y]).Spread(map, h + reduce, rnd, reduce, amountReduce);
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
                    map[x, y + 1] = new OreTile(base.type, x, y + 1, amountnext);

                    map = ((OreTile)map[x, y + 1]).Spread(map, h + reduce, rnd, reduce, amountReduce);
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
                    map[x, y - 1] = new OreTile(base.type, x, y - 1, amountnext);

                    map = ((OreTile)map[x, y - 1]).Spread(map, h + reduce, rnd, reduce, amountReduce);
                }
            }
        }

        return map;
    }

    public bool Mine(float minedAmount)
    {
        this.amount -= minedAmount;
        if (this.amount <= 0)
        {
            this.type = OreType.Surface;
            return true;
        }
        return false;
    }



    public OreTile(OreType gettype, int xpos, int ypos, float amountSet)
        : base(xpos, ypos)
    {
        this.type = gettype;
        this.amount = amountSet;
    }

    public OreTile(System.Random rnk, int xpos, int ypos, float amountSet)
        : base(xpos, ypos)
    {
        this.type = (OreType)rnk.Next(1, 6);
        this.amount = rnk.Next(1,(int)amountSet);


    }

   
}
