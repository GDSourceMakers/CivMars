using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[AddComponentMenu("Buildings/Chest")]
public class Chest : Building, IInventory, IBuildable, IRegystratabe, IHasGui
{
	new static public int ID = 2;

	public Text Name;
	public Text InventoryButtonText;

	public Inventory inventory = new Inventory(15);

	public Sprite Icon;

	new Item[] buildingMaterials = { new SandOre(2) };

	new void Start()
	{
		base.Start();
		Graphicks.SetActive(false);
		Graphicks.transform.position = Vector3.zero;
	}

	public void OpenInventory()
	{
		GameCon.TogleAccesPanel(this);
	}

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
	}

	public string GetInventoryName()
	{
		throw new NotImplementedException();
	}

	public bool HasCustomInventoryName()
	{
		return false;
	}

	public Item GetStackInSlot(int i)
	{
		return inventory.Get(i);
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
	}

	public Item Add(Item i)
	{
		return inventory.Add(i);
	}

	public Item Remove(Item i)
	{
		return inventory.Remove(i);
	}

	public void TransferItem(IInventory ToInv, int index)
	{
		throw new NotImplementedException();
	}

	public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
	{
		throw new NotImplementedException();
	}
}