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
			if(swaping == TileVectorTypes.xSwaped || swaping == TileVectorTypes.xySwaped)
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
			if (swaping == TileVectorTypes.ySwaped || swaping == TileVectorTypes.xySwaped)
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

	TileVectorTypes swaping = TileVectorTypes.none;

	public TileVector(int set_x, int set_y, TileVectorTypes swap)
	{
		x = set_x;
		y = set_y;
		swaping = swap;
	}

	public TileVector(int set_x, int set_y)
	{
		x = set_x;
		y = set_y;
		swaping = TileVectorTypes.none;
	}

	public TileVector(float set_x, float set_y, TileVectorTypes swap)
	{
		x = (int)Mathf.Floor(set_x);
		y = (int)Mathf.Floor(set_y);
		swaping = swap;
	}

	public TileVector(float set_x, float set_y)
	{
		x = (int)Mathf.Floor(set_x);
		y = (int)Mathf.Floor(set_y);
		swaping = TileVectorTypes.none;
	}

	static public TileVector operator +(TileVector l, TileVector r)
	{
		return new TileVector(l.x + r.x, l.y + r.y,l.swaping);
	}

	static public TileVector operator -(TileVector l, TileVector r)
	{
		return new TileVector(l.x - r.x, l.y - r.y,l.swaping);
	}

	static public implicit operator TileVector(Vector2 v)
	{
		return new TileVector(v.x, v.y);
	}

	static public implicit operator TileVector(Vector3 v)
	{
		return new TileVector(v.x, v.y);
	}

	static public implicit operator Vector2(TileVector v)
	{
		if (v.swaping == TileVectorTypes.xSwaped)
		{
			return new Vector2(-v.x, v.y);
		}
		else if (v.swaping == TileVectorTypes.xySwaped)
		{
			return new Vector2(-v.x, -v.y);
		}
		else if (v.swaping == TileVectorTypes.ySwaped)
		{
			return new Vector2(v.x, -v.y);
		}
		return new Vector2(v.x, v.y);
	}

	static public implicit operator Vector3(TileVector v)
	{
		if (v.swaping == TileVectorTypes.xSwaped)
		{
			return new Vector3(-v.x, v.y);
		}
		else if (v.swaping == TileVectorTypes.xySwaped)
		{
			return new Vector3(-v.x, -v.y);
		}
		else if (v.swaping == TileVectorTypes.ySwaped)
		{
			return new Vector3(v.x, -v.y);
		}
		return new Vector3(v.x, v.y);
	}
}

public enum TileVectorTypes
{
	xSwaped,
	ySwaped,
	xySwaped,
	none
}

