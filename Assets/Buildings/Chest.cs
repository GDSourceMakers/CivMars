using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[AddComponentMenu("Buildings/Chest")]
public class Chest : Building, IInventory, IBuildable,IRegystratabe, IHasGui
{
	new static public int ID = 2;

	public Text Name;
	public Text InventoryButtonText;
	public Text asd;


	public Inventory inventory = new Inventory(15);

	public Sprite Icon;

	Item[] buildingMaterials = {new SandOre(2)};

	public void OpenInventory()
	{
		GameCon.TogleAccesPanel(this);
	}

	public Inventory GetInventory()
	{
		return inventory;
	}

	public Sprite GetImage()
	{
		return Icon;
	}

	public GameObject GetPrefab()
	{
		return gameObject;
	}

	public Image GetBuildedState()
	{
		throw new NotImplementedException();
	}

	public Item[] GetNeededMaterials()
	{
		return buildingMaterials;
	}

	public float GetBuildtime()
	{
		return 5f;
	}

	public void Regystrate()
	{
		GameRegystry.RegisterBuilding(this as IBuildable);
	}
}