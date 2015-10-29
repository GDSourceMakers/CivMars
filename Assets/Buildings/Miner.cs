using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Miner : Building, IInventory, IHasGui, IRegystratabe, IBuildable
{
	public Sprite icon;

	Item[] neededMaterials = {new SandOre(3), new StoneOre(2) };

	public void OpenInventory()
	{
		GameCon.TogleAccesPanel(this);
	}

	#region IInventory

	public Item Add(Item i)
	{
		throw new NotImplementedException();
	}

	public string GetInventoryName()
	{
		throw new NotImplementedException();
	}

	public int GetInventorySize()
	{
		throw new NotImplementedException();
	}

	public int GetInventoryStackLimit(int i)
	{
		throw new NotImplementedException();
	}

	public Item GetStackInSlot(int i)
	{
		throw new NotImplementedException();
	}

	public bool HasCustomInventoryName()
	{
		throw new NotImplementedException();
	}

	public bool IsItemValidForSlot(int slot, Item givenItem)
	{
		throw new NotImplementedException();
	}

	public bool IsUseableByPlayer(Player p_70300_1_)
	{
		throw new NotImplementedException();
	}

	public Item Remove(Item i)
	{
		throw new NotImplementedException();
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

	#region IRegystratabe
	public void Regystrate()
	{
		GameRegystry.RegisterBuilding(this);
	}
	#endregion

	#region IBuildable
	public float GetBuildtime()
	{
		return 10f;
	}

	public Sprite GetImage()
	{
		return icon;
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
		return neededMaterials;
    }
	#endregion
}

