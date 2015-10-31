using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileTransform))]
public class Tiled : MonoBehaviour {

	new public TileTransform transform;

	// Use this for initialization
	void Awake () {
		transform = GetComponent<TileTransform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
