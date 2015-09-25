using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Buildings/Building")]
public class Building : Tiled
{
	static public int ID;

	private int x;
	private int y;
	public List<Item> buildingMaterials;

	public GameObject Canvas;
	public bool guion;

	public GameController GameCon;


	void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		if (GameCon == null)
		{
			Debug.LogErrorFormat("Can't find the GameController", this);
		}
		Canvas.SetActive(false);
		Canvas.transform.position = Vector3.zero;
	}


	void OnMouseDown()
	{
		TogelGui();
	}

	public void TogelGui()
	{
		if (guion)
		{
			Canvas.SetActive(false);
			GameCon.guiHandler.OpenBuilding = null;
			GameCon.guiHandler.isBuildingOpened = false;
			guion = false;
		}
		else
		{
			Canvas.SetActive(true);

			if (GameCon.guiHandler.isBuildingOpened)
			{
				GameCon.guiHandler.OpenBuilding.TogelGui();
			}
			GameCon.guiHandler.OpenBuilding = this;
			GameCon.guiHandler.isBuildingOpened = true;
			guion = true;
		}

	}
}