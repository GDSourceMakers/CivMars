using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("TileMap/Tile Map")]
public class TileMap : MonoBehaviour
{

	public TileTransform[,] tiles;
	public TileTransform[,] backgroundTiles;
	public int x_max;
	public int y_max;


	//public bool swapedX;
	//public bool swapedY;

	public TileVectorTypes swaping;

	public Vector3 TileSize;

	public TileTransform background;

	public GameObject BackgroundLayer;
	public GameObject ForegroundLayer;

	public void Awake()
	{
		tiles = new TileTransform[x_max, y_max];
		backgroundTiles = new TileTransform[x_max, y_max];
		if (BackgroundLayer != null)
		{
			for (int i = 0; i < x_max; i++)
			{
				for (int j = 0; j < y_max; j++)
				{
					TileTransform a = Instantiate(background.gameObject).GetComponent<TileTransform>();
					backgroundTiles[i, j] = a;
					a.transform.SetParent(BackgroundLayer.transform);
					a.position = new TileVector(i, j, swaping);
					a.SetTileMap(this);
				}
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
		
		if (IsTileOn(x, y))
		{
			tiles[x, y] = t;
			t.transform.SetParent(ForegroundLayer.transform);
			t.position = new TileVector(x, y, swaping);
			t.SetTileMap(this);
		}
	}

	public void RemoveTile(int x, int y)
	{
		if (!IsTileOn(x, y))
		{
			GameObject.DestroyImmediate(tiles[x, y].gameObject);
			tiles[x, y] = null;
		}
	}

	public void RemoveTile(TileVector p)
	{
		RemoveTile(p.x, p.y);
	}

	public bool Inside(TileVector a)
	{
		return
		(a.x >= 0 && a.x <= x_max - 1) &&
		(a.y >= 0 && a.y <= y_max - 1);
	}

	public bool Inside(int x, int y)
	{
		return Inside(new TileVector(x, y));
	}

	/*
	void OnDrawGizmos()
	{
		if (ForegroundLayer != null)
		{
			#region Fore
			#region vertical
			if (x_max > 0)
			{

				if (swapedX)
				{
					for (float x = ForegroundLayer.transform.position.x + (TileSize.x / 2);
								x > -x_max * TileSize.x;
								x -= TileSize.x)
					{
						if (swapedY)
						{
							Vector3 start = new Vector3(x, -(ForegroundLayer.transform.position.y - (TileSize.y / 2)), ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, -(ForegroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.y / 2)), ForegroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3(x, (ForegroundLayer.transform.position.y - (TileSize.y / 2)), ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, (ForegroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.y / 2)), ForegroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
					}
				}
				else
				{
					for (float x = ForegroundLayer.transform.position.x - (TileSize.x / 2);
								x < x_max * TileSize.x;
								x += TileSize.x)
					{
						if (swapedY)
						{
							Vector3 start = new Vector3(x, -(ForegroundLayer.transform.position.y - (TileSize.y / 2)), ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, -(ForegroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.x / 2)), ForegroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3(x, (ForegroundLayer.transform.position.y - (TileSize.y / 2)), ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, (ForegroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.x / 2)), ForegroundLayer.transform.position.z);
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
					for (float y = ForegroundLayer.transform.position.y + (TileSize.y / 2);
								y > -y_max * TileSize.y;
								y -= TileSize.y)
					{
						if (swapedX)
						{
							Vector3 start = new Vector3(-(ForegroundLayer.transform.position.x - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3(-(ForegroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3((ForegroundLayer.transform.position.x - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3((ForegroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
					}
				}
				else
				{
					for (float y = ForegroundLayer.transform.position.y - (TileSize.y / 2);
								y < y_max * TileSize.y;
								y += TileSize.y)
					{
						if (swapedX)
						{
							Vector3 start = new Vector3(-(ForegroundLayer.transform.position.x - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3(-(ForegroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3((ForegroundLayer.transform.position.x - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Vector3 end = new Vector3((ForegroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, ForegroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
					}
				}
			}
			#endregion

			#endregion
		}

		if (BackgroundLayer != null)
		{
			#region Background
			#region vertical
			if (x_max > 0)
			{

				if (swapedX)
				{
					for (float x = BackgroundLayer.transform.position.x + (TileSize.x / 2);
								x > -x_max * TileSize.x;
								x -= TileSize.x)
					{
						if (swapedY)
						{
							Vector3 start = new Vector3(x, -(BackgroundLayer.transform.position.y - (TileSize.y / 2)), BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, -(BackgroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.y / 2)), BackgroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3(x, (BackgroundLayer.transform.position.y - (TileSize.y / 2)), BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, (BackgroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.y / 2)), BackgroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
					}
				}
				else
				{
					for (float x = BackgroundLayer.transform.position.x - (TileSize.x / 2);
								x < x_max * TileSize.x;
								x += TileSize.x)
					{
						if (swapedY)
						{
							Vector3 start = new Vector3(x, -(BackgroundLayer.transform.position.y - (TileSize.y / 2)), BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, -(BackgroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.x / 2)), BackgroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3(x, (BackgroundLayer.transform.position.y - (TileSize.y / 2)), BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3(x, (BackgroundLayer.transform.position.y + (y_max * TileSize.y) - (TileSize.x / 2)), BackgroundLayer.transform.position.z);
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
					for (float y = BackgroundLayer.transform.position.y + (TileSize.y / 2);
								y > -y_max * TileSize.y;
								y -= TileSize.y)
					{
						if (swapedX)
						{
							Vector3 start = new Vector3(-(BackgroundLayer.transform.position.x - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3(-(BackgroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3((BackgroundLayer.transform.position.x - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3((BackgroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
					}
				}
				else
				{
					for (float y = BackgroundLayer.transform.position.y - (TileSize.y / 2);
								y < y_max * TileSize.y;
								y += TileSize.y)
					{
						if (swapedX)
						{
							Vector3 start = new Vector3(-(BackgroundLayer.transform.position.x - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3(-(BackgroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
						else
						{
							Vector3 start = new Vector3((BackgroundLayer.transform.position.x - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Vector3 end = new Vector3((BackgroundLayer.transform.position.x + (x_max * TileSize.x) - (TileSize.x / 2)), y, BackgroundLayer.transform.position.z);
							Gizmos.DrawLine(start, end);
						}
					}
				}
			}
			#endregion
			#endregion
		}
	}
	*/

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

	public bool IsTileOn(int x, int y)
	{
		if (Inside(x, y))
		{
			return tiles[x, y] == null;
		}
		return false;
	}

	public bool IsTileOn(TileVector pos)
	{
		return IsTileOn(pos.x, pos.y);
	}

	public TileTransform GetTileOn(int x, int y)
	{
		return tiles[x, y];
	}

	public TileTransform GetTileOn(TileVector v)
	{
		//if (tiles[v.x, v.y] != null)
		//{
			return tiles[v.x, v.y];
		//}
		//else
		//{
		//	return BackgroundLayer[v.x, v.y];
        //}
	}
}
