using UnityEngine;
using System.Collections;

[AddComponentMenu("TileMap/Tile Transform")]
public class TileTransform : MonoBehaviour
{
	public TileMap tileMap;

	[SerializeField]
	TileVector position_r;

	public TileVector position
	{
		set
		{
			position_r = value;
			transform.localPosition = position;

			gameObject.SendMessage("PositionUpdate", SendMessageOptions.DontRequireReceiver);
		}
		get
		{
			return position_r;
		}
	}


	public void SetTileMap(TileMap t)
	{
		tileMap = t;
	}


}