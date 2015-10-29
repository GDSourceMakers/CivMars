using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public enum AccesPanelState
{
	Inventory,
	Gas,
	Stats
}

interface IAccesTab
{
	void UpdateData(Building datas);
}

public class AccesPanel : MonoBehaviour, IHasGui
{
	public GameController GameCon;

	public Building OpenBuilding;

	public AccesPanelState state;
	public bool open;

	public GameObject[] AccesTabs;

	public GameObject Graphicks;

	public void ChangeTab(AccesPanelState a, Building data)
	{
		state = a;
		OpenBuilding = data;
		UpdateTab();
	}

	public void ChangeBuilding( Building data)
	{
		OpenBuilding = data;
		UpdateTab();
	}


	/*
	public void ChangeTab(AccesPanelState a)
	{
		state = a;
		UpdateTab();
	}
	*/

	public void ChangeTab(string a)
	{
		state = (AccesPanelState)Enum.Parse(typeof(AccesPanelState), a);

		UpdateTab();
	}

	public void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	void UpdateTab()
	{
		for (int i = 0; i < AccesTabs.Length; i++)
		{
			if ((int)state == i)
			{
				AccesTabs[i].SetActive(true);
				if (AccesTabs[i].GetComponent<IAccesTab>() != null)
				{
					AccesTabs[i].GetComponent<IAccesTab>().UpdateData(OpenBuilding);
				}
			}
			else
			{
				AccesTabs[i].SetActive(false);
			}
		}
	}

	public void Update()
	{
		if (Input.GetButtonUp("Inventory"))
		{
			Debug.Log("Inventory opening");

			TogelGui();
		}
	}

	public void TogelGui(Building opended)
	{
		OpenBuilding = opended;
		UpdateTab();
		TogelGui();
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
		ChangeBuilding(null);
	}

	public int ClosingLevel()
	{
		return 10;
	}
	#endregion
}
