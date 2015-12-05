using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[AddComponentMenu("Buildings/Chest")]
public class Chest : Building, IInventory, IBuildable, IRegystratabe, IHasGui
{
	static public string ID = "CivMars.Chest";

	public Text Name;
	public Text InventoryButtonText;

	public Inventory inventory = new Inventory(15);

	public Sprite Icon;

	static Item[] buildingMaterials = { new SandOre(2) };

	bool invOn;

	public override void Awake()
	{
		base.Awake();
		Graphicks.SetActive(false);
		this.Graphicks.transform.position = Vector3.zero;
	}

	public void OpenInventory()
	{
		invOn = !invOn;
		if (invOn)
			GameCon.guiHandler.defaultInventory.Activate(this);
		else
			GameCon.guiHandler.defaultInventory.Deactive();

	}

	#region IHasGUI

	public override void Close()
	{
		base.Close();
		GameCon.guiHandler.defaultInventory.Deactive();
	}

	#endregion


	#region IBuildable

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

	public void Setup()
	{
	}

	#endregion

	public void Regystrate()
	{
		GameRegystry.RegisterBuildableBuilding(ID, this);
	}

	#region Inventory

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



	#endregion
}