using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using BasicUtility.TileMap;
using BasicUtility;
using CivMarsEngine.Registry;
using CivMarsEngine.GUI;

namespace CivMarsEngine
{
	public class BuildingLister : MonoBehaviour, IGUI ,IPointerClickHandler
	{
		public GameObject buildableDrawElement;
		public GameObject buildingDesplayCanvas;
		public GameObject planedBuildingPrefab;

		public GraphicRaycaster raycaster;

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
            GameCon = GameController.instance;
			toglegroup = transform.FindChild("InSelecting").FindChild("Panel").GetComponent<TogleGroupAdvanced>();
			state = BuildingListerStates.Idle;

			buildingID = new List<string>();

			foreach (KeyValuePair<string, Tile> item in GameRegystry.tiels)
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
				actual.transform.FindChild("Icon").GetComponent<Image>().sprite = ((IBuildable)GameRegystry.tiels[buildingID[i]]).GetImage();
				actual.GetComponent<Toggle>().group = toglegroup;
				actual.transform.localScale = Vector3.one;
			}

		}

		// Update is called once per frame
		void Update()
		{

			if (Input.GetButtonUp("BuildingList") && (state == BuildingListerStates.Idle|| state == BuildingListerStates.Selecting))
			{
					Debug.Log("Buildning opening");
					TogelGui();
			}
			else if (state == BuildingListerStates.Building)
			{
				if (Input.GetMouseButtonUp(0) && SelectedBuilding != -1 && !EventSystem.current.IsPointerOverGameObject())
				{
					//Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

					//TileVector pos = new TileVector(Mathf.Round(ray.x - 0.5f), -1* Mathf.Round(ray.y + 0.5f),TileVectorTypes.ySwaped);
                    //TODO: Layers...
                    /*
					if (GameCon.map.Buildings.GetTileOn((int)pos.x, (int)pos.y) == null)
					{
						//PlanedBuilding p = Instantiate(planedBuildingPrefab).GetComponent<PlanedBuilding>();
						GameCon.map.Buildings.SetTile(pos.x, pos.y, p.transform);

						p.SetBuilding(((IBuildable)GameRegystry.tiels[buildingID[SelectedBuilding]]));

					}
                    */
					//GameCon.CloseGUI(this);
					Close();
				}
			}

			
		}

		public void BuildSelected()
		{
			SelectedBuilding = toglegroup.ActiveToggle().transform.GetSiblingIndex();
			if (SelectedBuilding == -1)
			{
				return;
			}

			inBuilding.SetActive(true);
			inSelecting.SetActive(false);

			state = BuildingListerStates.Building;
		}

		public void CancelBuilding()
		{
			SelectedBuilding = -1;
			state = BuildingListerStates.Selecting;
			inBuilding.SetActive(false);
			inSelecting.SetActive(true);
		}

		#region IhasGui
		public void TogelGui()
		{
			/*
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
			*/
		}

		public void Open()
		{
			guion = true;
			state = BuildingListerStates.Selecting;
			inBuilding.SetActive(false);
			inSelecting.SetActive(true);
		}

		public void Close()
		{
			guion = false;
			state = BuildingListerStates.Idle;

			inBuilding.SetActive(false);
			inSelecting.SetActive(false);
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

		public void OnPointerClick(PointerEventData eventData)
		{
			throw new NotImplementedException();
		}
		#endregion


	}

	public enum BuildingListerStates
	{
		Building,
		Selecting,
		Idle
	}
}
