
using UnityEngine;

public class OreTile : GeneratedTile
{
	public float amount;
	public float[] miningTime = { 0, 4, 4.5f, 5, 7, 14, 3, 3 };

	public GeneratedTile[,] Spread(GeneratedTile[,] map, float h, System.Random rnd, float reduce)
	{
		int l = (int)System.Math.Sqrt(map.Length);

		float amountnext = amount;
		#region Somehow not working :(
		/*
		for (int i = -1; i < 2; i++)
		{
			for (int j = -1; j < 2; j++)
			{
				if (i != 0 && j != 0)
				{
					Debug.Log(i + " , " + j);

					if ((x != l - 1) && (x != 0) && (y != l - 1) && (y != 0))
					{
						

						if ((map[x + i, y + j] == null) || ((int)map[x + i, y + j].type < (int)base.type))
						{
							if (rnd.Next(0, 100) >= h)
							{
								map[x + i, y + j] = null;
								map[x + i, y + j] = new OreTile(base.type, x + 1, y, amountnext);

								map = ((OreTile)map[x + i, y + j]).Spread(map, h + reduce, rnd, reduce);
							}
						}
					}
				}
			}
		}
		*/
		#endregion



		if (x != l - 1)
		{
			if ((map[x + 1, y] == null) || ((int)map[x + 1, y].type < (int)base.type))
			{
				if (rnd.Next(0, 100) >= h)
				{
					map[x + 1, y] = null;
					map[x + 1, y] = new OreTile(base.type, x + 1, y, amountnext);

					map = ((OreTile)map[x + 1, y]).Spread(map, h + reduce, rnd, reduce);
				}
			}
		}
		if (x != 0)
		{
			if ((map[x - 1, y] == null) || ((int)map[x - 1, y].type < (int)base.type))
			{
				if (rnd.Next(0, 100) >= h)
				{
					map[x - 1, y] = null;
					map[x - 1, y] = new OreTile(base.type, x - 1, y, amountnext);

					map = ((OreTile)map[x - 1, y]).Spread(map, h + reduce, rnd, reduce);
				}
			}
		}
		if (y != l - 1)
		{
			if ((map[x, y + 1] == null) || ((int)map[x, y + 1].type < (int)base.type))
			{
				if (rnd.Next(0, 100) >= h)
				{
					map[x, y + 1] = null;
					map[x, y + 1] = new OreTile(base.type, x, y + 1, amountnext);

					map = ((OreTile)map[x, y + 1]).Spread(map, h + reduce, rnd, reduce);
				}
			}
		}
		if (y != 0)
		{
			if ((map[x, y - 1] == null) || ((int)map[x, y - 1].type < (int)base.type))
			{
				if (rnd.Next(0, 100) >= h)
				{
					map[x, y - 1] = null;
					map[x, y - 1] = new OreTile(base.type, x, y - 1, amountnext);

					map = ((OreTile)map[x, y - 1]).Spread(map, h + reduce, rnd, reduce);
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
		this.amount = rnk.Next(1, (int)amountSet);


	}


}
