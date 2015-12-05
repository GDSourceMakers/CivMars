using UnityEngine;
using System.Collections;
using System;


public class AccesPanel : MonoBehaviour, IHasGui
{
	public GameController GameCon;

	public Building OpenBuilding;

	public bool open;

	public GameObject[] AccesTabs;

	public GameObject Graphicks;

	public void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}


	public void Update()
	{
		if (Input.GetButtonUp("Inventory"))
		{
			Debug.Log("Inventory opening");
			TogelGui();
		}
	}

	#region IhasGui
	public void TogelGui()
	{
		if (!open)
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
		open = true;
		Graphicks.SetActive(true);
	}

	public void Close()
	{
		open = false;
		Graphicks.SetActive(false);
	}

	public int ClosingLevel()
	{
		return 10;
	}
	#endregion
}
