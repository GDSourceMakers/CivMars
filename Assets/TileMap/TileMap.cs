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
	public bool hasBorder;

	//public bool swapedX;
	//public bool swapedY;

	public TileVectorTypes swaping;

	public Vector3 TileSize;

	public TileTransform background;

	public GameObject BackgroundLayer;
	public GameObject ForegroundLayer;

	public BoxCollider2D TopCollider;
	public BoxCollider2D LeftCollider;
	public BoxCollider2D BottomCollider;
	public BoxCollider2D RighttCollider;


	public void Awake()
	{
		//Cretion of the Arrays
		tiles = new TileTransform[x_max, y_max];
		backgroundTiles = new TileTransform[x_max, y_max];

		//Draws Statick background
		#region Draw Background
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
		#endregion

		//setup colliders
		if (hasBorder)
		{
			float total_x = x_max * TileSize.x;
			float total_y = y_max * TileSize.y;

			TopCollider.size = new Vector2(total_x, 1);
			TopCollider.offset = new Vector2(total_x / 2 - TileSize.x / 2, TileSize.y);

			LeftCollider.size = new Vector2(1, total_y);
			LeftCollider.offset = new Vector2(-TileSize.x, -(total_y / 2 - TileSize.y / 2));

			BottomCollider.size = new Vector2(total_x, 1);
			BottomCollider.offset = new Vector2(total_x / 2 - TileSize.x / 2, -total_y);

			RighttCollider.size = new Vector2(1, total_y);
			RighttCollider.offset = new Vector2(total_x, -(total_y / 2 - TileSize.y / 2));
		}
	}

	/*
	// Update is called once per frame
	void Update()
	{
	}
	*/

	/// <summary>
	/// Set te TileTransform to the coordinates
	/// </summary>
	/// <param name="x">x coordinate</param>
	/// <param name="y">y coordinate</param>
	/// <param name="t">Tile to set</param>
	public void SetTile(int x, int y, TileTransform t)
	{

		if (HasTileOn(x, y))
		{
			tiles[x, y] = t;
			t.transform.SetParent(ForegroundLayer.transform);
			t.position = new TileVector(x, y, swaping);
			t.SetTileMap(this);
		}
	}

	/// <summary>
	/// Removes the tile on coordinates
	/// </summary>
	/// <param name="x">x coordinate</param>
	/// <param name="y">y coordinate</param>
	public void RemoveTile(int x, int y)
	{
		if (!HasTileOn(x, y))
		{
			GameObject.DestroyImmediate(tiles[x, y].gameObject);
			tiles[x, y] = null;
		}
	}

	/// <summary>
	/// Removes the tile on coordinates
	/// </summary>
	/// <param name="p">Coordinates in Tile Vector</param>
	public void RemoveTile(TileVector p)
	{
		RemoveTile(p.x, p.y);
	}

	/// <summary>
	/// Returns true if the coordinates are inside of the map
	/// </summary>
	/// <param name="a">Coordinates in TileVector</param>
	/// <returns></returns>
	public bool Inside(TileVector a)
	{
		return
		(a.x >= 0 && a.x <= x_max - 1) &&
		(a.y >= 0 && a.y <= y_max - 1);
	}


	/// <summary>
	/// Returns true if the coordinates are inside of the map
	/// </summary>
	/// <param name="x">x coordinate</param>
	/// <param name="y">y coordinate</param>
	/// <returns></returns>
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



	/// <summary>
	/// Returns True if TileMap has tile on coordinates
	/// </summary>
	/// <param name="x">x coordinate</param>
	/// <param name="y">y coordinate</param>
	/// <returns></returns>
	public bool HasTileOn(int x, int y)
	{
		if (Inside(x, y))
		{
			return tiles[x, y] == null;
		}
		return false;
	}

	/// <summary>
	/// Returns True if TileMap has tile on coordinates
	/// </summary>
	/// <param name="cor">Coordinates in TileVector</param>
	/// <returns></returns>
	public bool HasTileOn(TileVector cor)
	{
		return HasTileOn(cor.x, cor.y);
	}


	/// <summary>
	/// Returns the TileTransform of the tile on coordinates
	/// </summary>
	/// <param name="x">x coordinate</param>
	/// <param name="y">y coordinate</param>
	/// <returns></returns>
	public TileTransform GetTileOn(int x, int y)
	{
		return tiles[x, y];
	}


	/// <summary>
	/// Returns the TileTransform of the tile on coordinates
	/// </summary>
	/// <param name="cor">Coordinates in TileVector</param>
	/// <returns></returns>
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
