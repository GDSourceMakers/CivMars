using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewMap : MonoBehaviour
{
	public GameController GameCon;

	public InputField nameField;
	public InputField seedField;

	AsyncOperation loadingmap;

	// Use this for initialization
	void Start()
	{
		GameCon = GameObject.Find("_GameController").GetComponent<GameController>();
		loadingmap = new AsyncOperation();
	}

	public void CreateMap()
	{
		SavedMapData map = new SavedMapData(int.Parse(seedField.text), nameField.text);

		GameCon.mapData = map;

		StartCoroutine(GameCon.LoadLevel("Main"));
	}
}
