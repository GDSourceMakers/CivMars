using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlanedBuilding : Building
{
	Item[] NeededMaterials;
	int[] NeededMaterialsPlaced;

	public Button buttonscript;
	public GameObject NeededItemsDesp;
	public GameObject neededItemPrefab;
	public List<GameObject> neededItemsDrawn;

	public IBuildable building;

	public float counter  = -1f;
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
		for (int i = 0; i < NeededMaterials.Length; i++)
		{

			if (neededItemsDrawn[i] == null)
			{
				GameObject go = Instantiate(neededItemPrefab);

				neededItemsDrawn[i] = go;

				neededItemsDrawn[i].transform.SetParent(NeededItemsDesp.transform);
				neededItemsDrawn[i].transform.SetSiblingIndex(i);

				neededItemsDrawn[i].transform.FindChild("Name").GetComponent<Text>().text = NeededMaterials[i].GetType().ToString();
				neededItemsDrawn[i].transform.FindChild("Amount").GetComponent<Text>().text = NeededMaterialsPlaced[i] + "/" + NeededMaterials[i].amount.ToString();
				neededItemsDrawn[i].transform.FindChild("Slider").GetComponent<Slider>().value = NeededMaterialsPlaced[i] / NeededMaterials[i].amount;

				//go.transform.FindChild("Picture");
			}
			else
			{
				neededItemsDrawn[i].transform.SetParent(NeededItemsDesp.transform);
				neededItemsDrawn[i].transform.SetSiblingIndex(i);

				neededItemsDrawn[i].transform.FindChild("Name").GetComponent<Text>().text = NeededMaterials[i].GetType().ToString();
				neededItemsDrawn[i].transform.FindChild("Amount").GetComponent<Text>().text = NeededMaterialsPlaced[i] + "/" + NeededMaterials[i].amount.ToString();
				neededItemsDrawn[i].transform.FindChild("Slider").GetComponent<Slider>().value = (float)NeededMaterialsPlaced[i] / (float)NeededMaterials[i].amount;
			}
		}
	}

	void OnMouseDown()
	{
		TogelGui();
	}

	public void SetBuilding(IBuildable b)
	{
		building = b;
		buildtime = b.GetBuildtime();
		NeededMaterials = building.GetNeededMaterials();
		NeededMaterialsPlaced = new int[NeededMaterials.Length];
		for (int i = 0; i < NeededMaterials.Length; i++)
		{
			neededItemsDrawn.Add(null);
		}
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

		for (int i = 0; i < NeededMaterials.Length; i++)
		{
			if (!(NeededMaterials[i].amount == NeededMaterialsPlaced[i]))
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
		Inventory playerinv = GameCon.playerclass.Inventory;

		for (int j = 0; j < NeededMaterials.Length; j++)
		{
			int neededamount;
			neededamount = NeededMaterials[j].amount - NeededMaterialsPlaced[j];
			
			

			NeededMaterialsPlaced[j] = NeededMaterials[j].amount - (playerinv.Remove(NeededMaterials[j],neededamount));
		}
	}
}
