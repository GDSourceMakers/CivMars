using UnityEngine;
using System.Collections;
using System;

public class OreTile : Tiled, IRegystratabe, IWorldGen
{
	static public float chanche;
	static public float chanche2;
	static public float chancheReduce;
	static public float distance;

	float amount = 2;

	public virtual void Regystrate() { }

	public virtual void Generate(System.Random r, TileMap map)
	{

		//throw new NotImplementedException();
		bool first = true;

		//TileVector last_pos = TileVector.zero;

		for (int i = 0; i < map.tiles.GetLength(0); i++)
		{
			for (int j = 0; j < map.tiles.GetLength(1); j++)
			{
				TileVector pos = new TileVector(i, j);

				if (r.Next(1000) <= chanche && first && map.IsTileOn(pos))
				{
					first = true;
					GameObject a = Instantiate(this.gameObject);

					a.name = "1a";
					map.SetTile(pos.x, pos.y, a.GetComponent<TileTransform>());

					a.GetComponent<OreTile>().Spread(r, map, chanche2);
				}


			}
		}
	}

	public void Spread(System.Random r, TileMap map, float chancheCurrent)
	{

		//throw new NotImplementedException();

		for (int i = -1; i < 2; i++)
		{
			for (int j = -1; j < 2; j++)
			{
				TileVector pos = transform.position + new TileVector(i, j);
				if ((i != 0 || j != 0) && map.Inside(pos) && map.IsTileOn(pos))
				{
					if (r.Next(1000) <= chancheCurrent)
					{
						GameObject a = Instantiate(this.gameObject);

						a.name = (int.Parse(this.name[0].ToString()) + 1).ToString() + "a";

						map.SetTile(pos.x, pos.y, a.GetComponent<TileTransform>());

						a.GetComponent<OreTile>().Spread(r, map, chancheCurrent - chancheReduce);
					}
				}
			}
		}
	}



	public virtual float GetMiningTime()
	{
		return 0f;
	}

	public virtual float GetAmountLeft()
	{
		return amount;
	}

	public virtual Type GetItemType()
	{
		return null;
	}


	public virtual bool Mine(int remAmount)
	{
		amount -= remAmount;
		if (amount <= 0)
		{
			transform.tileMap.RemoveTile(transform.position);
			return true;
		}
		return false;
	}
}
