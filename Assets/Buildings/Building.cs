using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Buildings/Building")]
public class Building : Tiled , IHasGui
{
	static public int ID;

	private int x;
	private int y;
	public List<Item> buildingMaterials;

	public GameObject Graphicks;
	public bool guion;

	public GameController GameCon;


	void Awake()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		if (GameCon == null)
		{
			Debug.LogErrorFormat("Can't find the GameController", this);
		}
		Graphicks.SetActive(false);
		Graphicks.transform.position = Vector3.zero;
	}


	void OnMouseDown()
	{
		TogelGui();
	}

	#region IhasGui
	public void TogelGui()
	{
		if (!guion)
		{
			if (GameCon.AlloweGUI(this as IHasGui))
			{
				Open();
			}
		}
		else
		{
			GameCon.CloseGUI(this as IHasGui);
			Close();
		}
	}

	public void Open()
	{
		guion = true;
		Graphicks.SetActive(true);
	}

	public void Close()
	{
		guion = false;
		Graphicks.SetActive(false);
	}

	public int ClosingLevel()
	{
		return 1;
	}
	#endregion
}