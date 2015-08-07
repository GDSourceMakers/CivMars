using UnityEngine;
using System.Collections;

public class Behaviour : MonoBehaviour {

    public GameController GameCon;

	// Use this for initialization
	void Start () {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
