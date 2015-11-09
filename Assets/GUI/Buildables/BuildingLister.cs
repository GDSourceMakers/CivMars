using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BuildingLister : MonoBehaviour, IHasGui
{
	public GameObject buildableDrawElement;
	public GameObject buildingDesplayCanvas;

	public GameObject planedBuildingPrefab;

	bool guion;

	GameController GameCon;

	TogleGroupAdvanced toglegroup;

	BuildingListerStates state;

	public GameObject inBuilding;
	public GameObject inSelecting;

	int SelectedBuilding;

	List<string> buildingID;

	void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		toglegroup = transform.FindChild("InSelecting").FindChild("Panel").GetComponent<TogleGroupAdvanced>();
		state = BuildingListerStates.Idle;

		buildingID = new List<string>();

		foreach (KeyValuePair<string, Building> item in GameRegystry.buildings)
		{
			if (item.Value is IBuildable)
			{
				buildingID.Add(item.Key);
			}
		}

		for (int i = 0; i < buildingID.Count; i++)
		{
			GameObject actual = Instantiate(buildableDrawElement);
			actual.transform.SetParent(buildingDesplayCanvas.transform);
			actual.transform.SetSiblingIndex(i);
			actual.transform.FindChild("Icon").GetComponent<Image>().sprite = ((IBuildable)GameRegystry.buildings[buildingID[i]]).GetImage();
			actual.GetComponent<Toggle>().group = toglegroup;
		}

	}

	// Update is called once per frame
	void Update()
	{

		if (state == BuildingListerStates.Idle)
		{
			inBuilding.SetActive(false);
			inSelecting.SetActive(false);
			if (Input.GetButtonUp("BuildingList"))
			{
				Debug.Log("Buildning opening");

				TogelGui();
			}
		}
		else if (state == BuildingListerStates.Building)
		{
			inBuilding.SetActive(true);
			inSelecting.SetActive(false);
		}
		else if (state == BuildingListerStates.Selecting)
		{
			inBuilding.SetActive(false);
			inSelecting.SetActive(true);
			if (Input.GetButtonUp("BuildingList"))
			{
				Debug.Log("Buildning opening");

				TogelGui();
			}
		}

		if (Input.GetMouseButtonDown(0) && SelectedBuilding != -1 && state == BuildingListerStates.Building)
		{
			Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			TileVector pos = new TileVector(Mathf.Round(ray.x), -1 * Mathf.Round(ray.y));

			if (GameCon.map.Buildings.GetTileOn((int)pos.x, (int)pos.y) == null)
			{
				PlanedBuilding p = Instantiate(planedBuildingPrefab).GetComponent<PlanedBuilding>();
				GameCon.map.Buildings.SetTile(pos.x, pos.y, p.transform);

				p.SetBuilding(((IBuildable)GameRegystry.buildings[buildingID[SelectedBuilding]]));

			}
			GameCon.CloseGUI(this);
			Close();
		}
	}

	public void BuildSelected()
	{
		SelectedBuilding = toglegroup.ActiveToggle().transform.GetSiblingIndex();
		if (SelectedBuilding == -1)
		{
			return;
		}

		state = BuildingListerStates.Building;
	}

	public void CancelBuilding()
	{
		SelectedBuilding = -1;
		state = BuildingListerStates.Selecting;
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
		state = BuildingListerStates.Selecting;
	}

	public void Close()
	{
		guion = false;
		state = BuildingListerStates.Idle;
	}

	public int ClosingLevel()
	{
		if (state != BuildingListerStates.Building)
		{
			return 10;
		}
		else
		{
			return int.MaxValue;
		}
	}
	#endregion
}

public enum BuildingListerStates
{
	Building,
	Selecting,
	Idle
}

