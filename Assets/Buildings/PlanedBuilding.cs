using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PlanedBuilding : Building
{
	Item[] Materials = new Item[1];
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

	public override void Awake()
	{
		base.Awake();
		Graphicks.SetActive(false);
		this.Graphicks.transform.position = Vector3.zero;
	}

	void Start()
	{
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
			neededItemsDrawn[i].transform.FindChild("Amount").GetComponent<Text>().text = Materials[i].amount + "/" + MaterialsAmount[i];
			neededItemsDrawn[i].transform.FindChild("Slider").GetComponent<Slider>().value = (float)MaterialsAmount[i] / Materials[i].amount;
		}
	}



	/// <summary>
	/// Sets what building to build
	/// </summary>
	/// <param name="b">Ibuildable for building</param>
	public void SetBuilding(IBuildable b)
	{
		building = b;
		buildtime = b.GetBuildtime();

		Materials = new Item[building.GetNeededMaterials().Length];
		building.GetNeededMaterials().CopyTo(Materials, 0);



		MaterialsAmount = new int[Materials.Length];

		
		for (int i = 0; i < Materials.Length; i++)
		{
			//MaterialsAmount[i] = Materials[i].amount;
			neededItemsDrawn.Add(null);
		}
		

		Name.text = building.GetType().ToString();
	}

	/// <summary>
	/// Builds The actual building
	/// </summary>
	void BuildBuilding()
	{
		GameObject go = GameObject.Instantiate(building.GetPrefab());

		GameCon.map.Buildings.tiles[transform.position.x, transform.position.y] = null;
		GameCon.map.Buildings.SetTile(transform.position.x, transform.position.y, go.GetComponent<TileTransform>());
		go.GetComponent<IBuildable>().Setup();

		//Destroy itself
		GameCon.CloseGUI(this);
		Destroy(this.gameObject);
	}

	/// <summary>
	/// Starts The building counter
	/// </summary>
	public void Build()
	{
		for (int i = 0; i < Materials.Length; i++)
		{
			if ((Materials[i].amount - MaterialsAmount[i]) == 0)
			{
				counter = buildtime;
				return;
			}
		}
	}

	/// <summary>
	/// Removes Items From the player for the building
	/// </summary>
	public void Place()
	{
		Inventory playerinv = GameCon.playerclass.inventory;

		for (int i = 0; i < Materials.Length; i++)
		{
			if ((Materials[i].amount - MaterialsAmount[i]) != 0)
			{

				Item needed = (Item)Activator.CreateInstance(null, Materials[i].GetType().ToString()).Unwrap();
				needed.amount = Materials[i].amount;

				Item remaining = playerinv.Remove(needed);
				if (remaining != null)
				{
					Materials[i] = remaining;
					MaterialsAmount[i] += Materials[i].amount - remaining.amount;
				}
				else
				{
					MaterialsAmount[i] = Materials[i].amount;
				}
				
			}
		}
	}
}
