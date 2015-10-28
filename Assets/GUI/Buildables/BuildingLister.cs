using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BuildingLister : MonoBehaviour, IHasGui
{
	public GameObject buildableDrawElement;
	public GameObject buildingDesplayCanvas;

	public GameObject planedBuildingPrefab;

	public bool guion;

	GameController GameCon;

	ToggleGroup toglegroup;

	public BuildingListerStates state;

	public GameObject inBuilding;
	public GameObject inSelecting;

	int SelectedBuilding;

	void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		List<IBuildable> buildables = GameRegystry.buildings;
		toglegroup = transform.FindChild("InSelecting").FindChild("Panel").GetComponent<ToggleGroup>();

		state = BuildingListerStates.Idle;

		for (int i = 0; i < buildables.Count; i++)
		{
			GameObject actual = Instantiate(buildableDrawElement);
			actual.transform.SetParent(buildingDesplayCanvas.transform);
			actual.transform.SetSiblingIndex(i);
			actual.transform.FindChild("Icon").GetComponent<Image>().sprite = buildables[i].GetImage();
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
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			Vector3 pos = new Vector3(Mathf.Round(ray.origin.x), Mathf.Round(ray.origin.y));

			Debug.Log(GameCon.map.mapBuilt[(int)pos.x, -1 * (int)pos.y]);

			if (GameCon.map.mapBuilt[(int)pos.x, -1 * (int)pos.y] == null)
			{
				PlanedBuilding p = Instantiate(planedBuildingPrefab).GetComponent<PlanedBuilding>();
				GameCon.map.mapBuilt[(int)pos.x, -1 * (int)pos.y] = p;
				GameCon.map.mapBuilt[(int)pos.x, -1 * (int)pos.y].transform.position = pos;

				p.SetBuilding(GameRegystry.buildings[SelectedBuilding]);
			}

			state = BuildingListerStates.Idle;
		}
	}

	int GetActiveTogle(IEnumerable<Toggle> t)
	{
		int i = 0;

		foreach (Toggle item in t)
		{
			if (item.isOn)
			{
				return i;
			}
			i++;
		}
		return -1;
	}

	public void BuildSelected()
	{
		SelectedBuilding = GetActiveTogle(toglegroup.ActiveToggles());
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

