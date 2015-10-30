using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlanedBuilding : Building
{
	Item[] Materials;
	int[] MaterialsAmount;

	public Button buttonscript;
	public Text Name;
	public GameObject NeededItemsDesp;
	public GameObject neededItemPrefab;
	public List<GameObject> neededItemsDrawn;

	public IBuildable building;

	public float counter = -1f;
	public float buildtime;

	public float defaultYPos;
	public float defaultXPos;
	public RectTransform maskRect;

	void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		if (GameCon == null)
		{
			Debug.LogErrorFormat("Can't find the GameController", this);
		}
		Graphicks.SetActive(false);
		Graphicks.transform.position = Vector3.zero;

		//maskRect = gameObject.transform.FindChild("Mask").GetComponent<RectTransform>();
		defaultYPos = maskRect.localPosition.y;

		counter = -1f;

	}

	void Update()
	{
		UpdateMaterials();

		BuildingButonUpdate();
	}

	void BuildingButonUpdate()
	{
		if (counter > 0)
		{
			buttonscript.interactable = false;

			maskRect.localPosition = new Vector2(maskRect.localPosition.x, Mathf.Lerp(defaultYPos + maskRect.rect.height, defaultYPos, (counter / buildtime)));
			//ActionRuned = false;
			GameCon.playerclass.GetComponent<Rigidbody2D>().isKinematic = true;

			counter -= Time.deltaTime;
			if (counter < 0)
			{
				counter = 0;
			}

		}
		if (counter == 0)
		{
			counter = -1;
			BuildBuilding();
		}
	}

	void UpdateMaterials()
	{
		for (int i = 0; i < Materials.Length; i++)
		{

			if (neededItemsDrawn[i] == null)
			{
				GameObject go = Instantiate(neededItemPrefab);
				neededItemsDrawn[i] = go;
				neededItemsDrawn[i].transform.SetParent(NeededItemsDesp.transform);
				neededItemsDrawn[i].transform.SetSiblingIndex(i);
			}
			else
			{
				neededItemsDrawn[i].transform.SetParent(NeededItemsDesp.transform);
				neededItemsDrawn[i].transform.SetSiblingIndex(i);
			}

			neededItemsDrawn[i].transform.FindChild("Name").GetComponent<Text>().text = Materials[i].GetType().ToString();
			neededItemsDrawn[i].transform.FindChild("Amount").GetComponent<Text>().text = (MaterialsAmount[i] - Materials[i].amount) + "/" + MaterialsAmount[i];
			neededItemsDrawn[i].transform.FindChild("Slider").GetComponent<Slider>().value = (float)(MaterialsAmount[i] - Materials[i].amount) / MaterialsAmount[i];
		}
	}

	public void SetBuilding(IBuildable b)
	{
		building = b;
		buildtime = b.GetBuildtime();
		Materials = building.GetNeededMaterials();
		MaterialsAmount = new int[Materials.Length];
		for (int i = 0; i < Materials.Length; i++)
		{
			MaterialsAmount[i] = Materials[i].amount;
			neededItemsDrawn.Add(null);
		}
		Name.text = building.GetType().ToString();
	}

	void BuildBuilding()
	{
		GameObject go = GameObject.Instantiate(building.GetPrefab());
		go.transform.position = this.transform.position;
		GameCon.CloseGUI(this);
		Destroy(this.gameObject);
	}

	public void Build()
	{
		bool done = true;
		done = true;

		for (int i = 0; i < Materials.Length; i++)
		{
			if (!((MaterialsAmount[i] - Materials[i].amount) == MaterialsAmount[i]))
			{
				done = false;
			}
		}

		if (done)
		{
			counter = buildtime;
		}
	}

	/// <summary>
	/// Removes Items From the player for the building
	/// </summary>
	public void Place()
	{
		Inventory playerinv = GameCon.playerclass.inventory;

		for (int j = 0; j < Materials.Length; j++)
		{
			if ((MaterialsAmount[j] - Materials[j].amount) < MaterialsAmount[j])
			{

				Item remaining = playerinv.Remove(Materials[j]);
				if (remaining != null)
				{
					Materials[j] = remaining;
				}
				else
				{
					Materials[j].amount = 0;
				}
				//Materials[j].amount -= (MaterialsAmount[j] - Materials[j].amount);
			}
		}
	}
}
