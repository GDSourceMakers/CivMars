using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BuildingLister : MonoBehaviour
{
	public GameObject buildableDrawElement;
	public GameObject buildingDesplayCanvas;

	public GameObject planedBuildingPrefab;

	GameController GameCon;

	ToggleGroup toglegroup;

	BuildingListerStates state;

	public GameObject inBuilding;
	public GameObject InSelecting;

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
		if (state == BuildingListerStates.Building)
		{
			inBuilding.SetActive(true);
			inBuilding.SetActive(false);
		}
		else if (state == BuildingListerStates.Selecting)
		{
			inBuilding.SetActive(false);
			inBuilding.SetActive(true);
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
}

enum BuildingListerStates
{
	Building,
	Selecting,
	Idle
}

