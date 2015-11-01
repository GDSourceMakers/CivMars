using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

[AddComponentMenu("Buildings/Main Building")]
[System.Serializable]
public class MainBuilding : Building , IInventory, IGasTank,IRegystratabe
{
	static public string ID = "CivMars.MainBuilding";
	
	public Text Name;
    public Text InventoryButtonText;
    

	public Inventory inventory = new Inventory(20);

	public static float[] max = { 1000f, 1000f, 1000f, 1000f };
	public GasTankCluster tanks = new GasTankCluster(4, max);

	void Start()
	{
		base.Awake();
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

	public void Regystrate()
	{
		GameRegystry.RegisterBuildableBuilding(ID, this);
	}
}
