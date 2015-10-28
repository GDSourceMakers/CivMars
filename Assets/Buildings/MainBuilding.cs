﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

[AddComponentMenu("Buildings/Main Building")]
[System.Serializable]
public class MainBuilding : Building , IInventory, IGasTank
{
	new static public int ID = 1;

	public Text Name;
    public Text InventoryButtonText;
    

	public Inventory inventory = new Inventory(20);

	public static float[] max = { 1000f, 1000f, 1000f, 1000f };
	public GasTankCluster tanks = new GasTankCluster(4, max);

	void Start()
	{
		base.Start();
		Graphicks.SetActive(false);
		Graphicks.transform.position = Vector3.zero;
	}


	public void OpenInventory()
    {
        GameCon.TogleAccesPanel(this);
    }

	public GasTankCluster GetTankCluster()
	{
		return tanks;
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

	public void TransferItem(IInventory ToInv, int index)
	{
		inventory.TransferItem(ToInv, index);
    }

	public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
	{
		inventory.TransferItemAmount(Toinv, fromindex, transferingAmount);
    }
}
