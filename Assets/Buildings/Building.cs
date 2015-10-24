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

	public GameObject Canvas;
	public bool guion;

	public GameController GameCon;


	void Awake()
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
		if (GameCon.AlloweGUI(this as IHasGui))
		{
			TogelGui();
		}
	}

	public void TogelGui()
	{
		if (guion)
		{
			Close();
		}
		else
		{
			Open();
		}

	}

	public void Open()
	{
		Canvas.SetActive(true);
		GameCon.guiHandler.OpenGUI = this;
		GameCon.guiHandler.isGUIOpen = true;
		guion = true;
	}

	public void Close()
	{
		Canvas.SetActive(false);
		GameCon.guiHandler.OpenGUI = null;
		GameCon.guiHandler.isGUIOpen = false;
		guion = false;
	}

	public bool CanBeTurnedOf()
	{
		return true;
	}
}