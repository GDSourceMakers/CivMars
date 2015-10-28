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

	new Item[] buildingMaterials = {new SandOre(2)};

	public void OpenInventory()
	{
		GameCon.TogleAccesPanel(this);
	}

	/*
	public Inventory GetInventory()
	{
		return inventory;
	}
	*/

	#region buildable
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
	#endregion

	public void Regystrate()
	{
		GameRegystry.RegisterBuilding(this as IBuildable);
	}

	public int GetInventorySize()
	{
		return inventory.size;
		throw new NotImplementedException();
	}

	public string GetInventoryName()
	{
		throw new NotImplementedException();
	}

	public bool HasCustomInventoryName()
	{
		return false;
		throw new NotImplementedException();
	}

	public Item GetStackInSlot(int i)
	{
		return inventory.Get(i);
		throw new NotImplementedException();
	}

	public int GetInventoryStackLimit(int i)
	{
		throw new NotImplementedException();
	}

	public bool IsItemValidForSlot(int slot, Item givenItem)
	{
		throw new NotImplementedException();
	}

	public bool IsUseableByPlayer(Player p_70300_1_)
	{
		return true;
		throw new NotImplementedException();
	}

	public Item Add(Item i)
	{
		inventory.Add(i);
		throw new NotImplementedException();
	}

	public Item Remove(Item i)
	{
		inventory.Remove(i);
		throw new NotImplementedException();
	}
}