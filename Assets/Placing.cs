/*
using UnityEngine;
using System.Collections;

public class Placing : MonoBehaviour {

	public GameObject planedb;
	public Map map;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			Vector3 pos = new Vector3(Mathf.Round(ray.origin.x), Mathf.Round(ray.origin.y));
			if (map.mapBuilt[(int)pos.x, (int)pos.y] == null)
			{
				GameObject go = ((GameObject)Instantiate(planedb, pos, transform.rotation));
				map.mapBuilt[(int)pos.x, (int)pos.y] = go.GetComponent<Tiled>();
            }
		}
	}
}
*/
