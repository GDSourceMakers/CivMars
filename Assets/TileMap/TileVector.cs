using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class TileVector
{
	[SerializeField]
	int x_pos;
	public int x
	{
		get { return x_pos; }
		set
		{
			this.x_pos = value;
			normal.x = value;
			magnitude = x_pos * y_pos;
		}
	}
	[SerializeField]
	int y_pos;
	public int y
	{
		get { return y_pos; }
		set
		{
			this.y_pos = value;
			normal.y = value;
			magnitude = x_pos * y_pos;
		}
	}

	public int magnitude
	{
		get;
		private set;
	}
	

	public static TileVector zero = new TileVector(0, 0);

	Vector2 normal;

	public TileVector(int set_x, int set_y)
	{
		x = set_x;
		y = set_y;
	}

	public TileVector(float set_x, float set_y)
	{
		x = (int)Mathf.Floor(set_x);
		y = (int)Mathf.Floor(set_x);
	}

	static public TileVector operator +(TileVector l, TileVector r)
	{
		return new TileVector(l.x + r.x, l.y + r.y);
	}

	static public TileVector operator -(TileVector l, TileVector r)
	{
		return new TileVector(l.x - r.x, l.y - r.y);
	}

	static public implicit operator TileVector(Vector2 v)
	{
		return new TileVector(v.x,v.y);
	}

	static public implicit operator TileVector(Vector3 v)
	{
		return new TileVector(v.x, v.y);
	}

	static public implicit operator Vector2(TileVector v)
	{
		return new Vector2(v.x, -v.y);
	}

	static public implicit operator Vector3(TileVector v)
	{
		return new Vector3(v.x, -v.y);
	}
}
