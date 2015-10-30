using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("TileMap/Tile Map")]
public class TileMap : MonoBehaviour
{

	public TileTransform[,] tiles;
	public int x_max;
	public int y_max;


	public bool swapedX;
	public bool swapedY;

	public Vector3 TileSize;

	public TileTransform surface;

	public void Awake()
	{
		tiles = new TileTransform[x_max, y_max];

		for (int i = 0; i < x_max; i++)
		{
			for (int j = 0; j < y_max; j++)
			{
				TileTransform a = Instantiate(surface.gameObject).GetComponent<TileTransform>();
				SetTile(i, j, a);
			}
		}
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}

	/*
	public void SetUp(int x, int y)
	{
		Tiles = new TileTransform[x, y];
		x_max = x - 1;
		y_max = y - 1;
	}
	*/

	public void SetTile(int x, int y, TileTransform t)
	{
		if (IsTileOn(x, y, BasicTileType.Null) || IsTileOn(x, y, BasicTileType.Surface))
		{
			tiles[x, y] = t;
			t.position = new TileVector(x, y);
			t.SetTileMap(this);
		}
	}

	public bool Inside(TileVector a)
	{
		return
		(a.x >= 0 && a.x <= x_max-1) &&
		(a.y >= 0 && a.y <= y_max-1);
	}

	public bool Inside(int x, int y)
	{
		return Inside(new TileVector(x, y));
	}

	void OnDrawGizmos()
	{
		Vector2 positionMulti = Vector2.one;

		if (swapedX)
		{
			positionMulti.x = -1;
		}
		if (swapedY)
		{
			positionMulti.y = -1;
		}

		#region vertical
		if (x_max > 0)
		{

			if (swapedX)
			{
				for (float x = transform.position.x + (TileSize.x / 2);
							x > -x_max * TileSize.x;
							x -= TileSize.x)
				{
					if (swapedY)
					{
						Vector2 start = new Vector2(x, -(transform.position.y - (TileSize.y / 2)));
						Vector2 end = new Vector2(x, -(transform.position.y + (y_max * TileSize.y) - (TileSize.y / 2)));
						Gizmos.DrawLine(start, end);
					}
					else
					{
						Vector2 start = new Vector2(x, (transform.position.y - (TileSize.y / 2)));
						Vector2 end = new Vector2(x, (transform.position.y + (y_max * TileSize.y) - (TileSize.y / 2)));
						Gizmos.DrawLine(start, end);
					}
				}
			}
			else
			{
				for (float x = transform.position.x - (TileSize.x / 2);
							x < x_max * TileSize.x;
							x += TileSize.x)
				{
					if (swapedY)
					{
						Vector2 start = new Vector2(x, -(transform.position.y - (TileSize.y / 2)));
						Vector2 end = new Vector2(x, -(transform.position.y + (y_max * TileSize.y) - (TileSize.x / 2)));
						Gizmos.DrawLine(start, end);
					}
					else
					{
						Vector2 start = new Vector2(x, (transform.position.y - (TileSize.y / 2)));
						Vector2 end = new Vector2(x, (transform.position.y + (y_max * TileSize.y) - (TileSize.x / 2)));
						Gizmos.DrawLine(start, end);
					}
				}
			}
		}

		#endregion

		#region horisontal
		if (y_max > 0)
		{

			if (swapedY)
			{
				for (float y = transform.position.y + (TileSize.y / 2);
							y > -y_max * TileSize.y;
							y -= TileSize.y)
				{
					if (swapedX)
					{
						Vector2 start = new Vector2(-(transform.position.x - (TileSize.x / 2)), y);
						Vector2 end = new Vector2(-(transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y);
						Gizmos.DrawLine(start, end);
					}
					else
					{
						Vector2 start = new Vector2((transform.position.x - (TileSize.x / 2)), y);
						Vector2 end = new Vector2((transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y);
						Gizmos.DrawLine(start, end);
					}
				}
			}
			else
			{
				for (float y = transform.position.y - (TileSize.y / 2);
							y < y_max * TileSize.y;
							y += TileSize.y)
				{
					if (swapedX)
					{
						Vector2 start = new Vector2(-(transform.position.x - (TileSize.x / 2)), y);
						Vector2 end = new Vector2(-(transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y);
						Gizmos.DrawLine(start, end);
					}
					else
					{
						Vector2 start = new Vector2((transform.position.x - (TileSize.x / 2)), y);
						Vector2 end = new Vector2((transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y);
						Gizmos.DrawLine(start, end);
					}
				}
			}
		}
		#endregion
	}

	/*
	public bool TileTipeOn(int x, int y)
	{
		if (t == BasicTileType.Null)
		{
			return tiles[x, y] == null;
		}
		else if (t == BasicTileType.Other)
		{
			return tiles[x, y] != null;
		}
		else if (t == BasicTileType.Surface)
		{
			return tiles[x, y] != null;
		}
		return false;
	}
	*/

	public bool IsTileOn(int x, int y, BasicTileType t)
	{
		if (Inside(x,y))
		{
			if (t == BasicTileType.Null)
			{
				return tiles[x, y] == null;
			}
			else if (t == BasicTileType.Other)
			{
				return !(tiles[x, y] == null) && !(tiles[x, y].GetComponent<Surface>() != null);
			}
			else if (t == BasicTileType.Surface)
			{
				return tiles[x, y].GetComponent<Surface>() != null;
			}
			else if (t == BasicTileType.NullOrSurface)
			{
				return !(tiles[x, y] == null) || !(tiles[x, y].GetComponent<Surface>() != null);
			}
		}
		return false;
	}

	public bool IsTileOn(TileVector pos, BasicTileType t)
	{
		return IsTileOn(pos.x, pos.y, t);
	}

}

public enum BasicTileType
{
	Surface,
	Null,
	NullOrSurface,
	Other
}
