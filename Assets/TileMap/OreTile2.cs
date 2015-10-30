using UnityEngine;
using System.Collections;

public class OreTile2 : Tiled, IRegystratabe, IWorldGen
{
	static int chanche = 1;
	static int chanche2 = 400;
	static int chancheReduce = 100;
	static int distance = 20;


	public virtual void Regystrate() { }

	public void Generate(System.Random r, TileMap map)
	{

		//throw new NotImplementedException();
		bool first = true;

		TileVector last_pos = TileVector.zero;

		for (int i = 0; i < map.tiles.GetLength(0); i++)
		{
			for (int j = 0; j < map.tiles.GetLength(1); j++)
			{
				TileVector pos = new TileVector(i, j);

				if (r.Next(1000) <= chanche && first && last_pos.magnitude > distance && map.IsTileOn(pos,BasicTileType.NullOrSurface))
				{
					first = true;
					GameObject a = Instantiate(this.gameObject);
					
					a.name = "1a";
					map.SetTile(pos.x, pos.y, a.GetComponent<TileTransform>());

					a.GetComponent<OreTile2>().Spread(r, map, chanche2);
				}

				last_pos = pos;
			}
		}
	}

	public void Spread(System.Random r, TileMap map, int chancheCurrent)
	{

		//throw new NotImplementedException();

		for (int i = -1; i < 2; i++)
		{
			for (int j = -1; j < 2; j++)
			{
				TileVector pos = transform.position + new TileVector(i, j);
				if ((i != 0 || j != 0) && map.Inside(pos) && map.IsTileOn(pos, BasicTileType.NullOrSurface))
				{
					if (r.Next(1000) <= chancheCurrent)
					{
						GameObject a = Instantiate(this.gameObject);

						a.name = (int.Parse(this.name[0].ToString()) + 1).ToString() + "a";

						map.SetTile(pos.x, pos.y, a.GetComponent<TileTransform>());

						a.GetComponent<OreTile2>().Spread(r, map, chancheCurrent - chancheReduce);
					}
				}
			}
		}
	}


}
