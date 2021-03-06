﻿using UnityEngine;
using System.Collections;
using System;
using CivMarsEngine;

public class OreTile : Tiled, IRegystratabe, IWorldGen, ISaveble
{
	public string ID;

	public float chanche = 0;
	public float chanche2 = 0;
	public float chancheReduce = 0;
	public float distance = 0;

	public int amount = 40;

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

				bool k = map.HasTileOn(pos);

				if (r.Next(0, 1000) <= chanche && first && k)
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

				bool k = !map.HasTileOn(pos);

				if ((i != 0 || j != 0) && map.Inside(pos) && !k)
				{
					if (r.Next(0, 1000) <= chancheCurrent)
					{
						if (!k)
						{
							GameObject a = Instantiate(this.gameObject);

							a.name = (int.Parse(this.name[0].ToString()) + 1).ToString() + "a";

							map.SetTile(pos.x, pos.y, a.GetComponent<TileTransform>());

							a.GetComponent<OreTile>().Spread(r, map, chancheCurrent - chancheReduce);
						}
						else if(map.GetTileOn(pos.x, pos.y).GetComponent<OreTile>().ID == this.ID)
						{
							map.GetTileOn(pos.x, pos.y).GetComponent<OreTile>().Spread(r, map, chancheCurrent - chancheReduce);
						}
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

	public SavedTile Save()
	{
		SavedOre s = new SavedOre(ID, amount);

		return s;
	}

	public void Load(SavedTile data)
	{
		amount = ((SavedOre)data).amount;
	}

	public GameObject GetPrefab()
	{
		return this.gameObject;
	}
}
