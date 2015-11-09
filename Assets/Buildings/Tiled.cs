using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileTransform))]
public class Tiled : MonoBehaviour {

	new public TileTransform transform;

	protected GameController GameCon;

	// Use this for initialization
	public virtual void Awake () {
		transform = GetComponent<TileTransform>();

		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		if (GameCon == null)
		{
			Debug.LogErrorFormat("Can't find the GameController", this);
		}

	}
}
