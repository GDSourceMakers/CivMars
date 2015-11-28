using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Press : Building, IInventory, IHasGui, IRegystratabe, ICrafter, IBuildable {

	enum States
	{
		None,
		Inv,
		Craft
	}

	public List<CraftingProcess> craftingQueue = new List<CraftingProcess>();

	static public string ID = "CivMars.Press";
	static Item[] neededMaterials = { new SandOre(1) };
	public Sprite icon;

	States invOn;

	Inventory inv = new Inventory(10);

	Item remaining;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (remaining == null && craftingQueue.Count > 0)
		{
			CraftingProcess a = (CraftingProcess)craftingQueue[0];
			if (a.HasItems())
			{
				a.status -= Time.deltaTime;

				if (a.status <= 0)
				{
					remaining = (Item)Activator.CreateInstance(a.recipe.Crafted.GetType());
					remaining.amount = a.amount * a.recipe.Crafted.amount;
					craftingQueue.RemoveAt(0);
				}

			}
			else
			{
				Inventory playerinv = GameCon.playerclass.inventory;

				for (int i = 0; i < a.recipe.Materials.Length; i++)
				{
					if (a.materials[i] > 0)
					{
						Item needed = (Item)Activator.CreateInstance(null, a.recipe.Materials[i].GetType().ToString()).Unwrap();
						needed.amount = a.materials[i];

						Item remainingItem = playerinv.Remove(needed);
						if (remainingItem != null)
						{
							a.materials[i] = remainingItem.amount;
						}
						else
						{
							a.materials[i] = 0;
						}


					}
				}
			}
		}
		else if (remaining != null)
		{
			remaining = inv.Add(remaining);
		}
	}

	public override void Awake()
	{
		base.Awake();
		Graphicks.SetActive(false);
		this.Graphicks.transform.position = Vector3.zero;
	}

	public void OpenInventory()
	{
		if (invOn != States.Inv)
		{
			GameCon.guiHandler.defaultInventory.gameObject.SetActive(true);
			GameCon.guiHandler.defaultCrafting.gameObject.SetActive(false);

			GameCon.guiHandler.defaultInventory.SetOtherInv(this);
			GameCon.guiHandler.defaultCrafting.SetBuilding(null);
			invOn = States.Inv;
		}
		else
		{
			GameCon.guiHandler.defaultInventory.gameObject.SetActive(false);

			GameCon.guiHandler.defaultInventory.SetOtherInv(null);
			invOn = States.None;
		}
	}

	public void OpenCrafting()
	{

		if (invOn != States.Craft)
		{
			GameCon.guiHandler.defaultInventory.gameObject.SetActive(false);
			GameCon.guiHandler.defaultCrafting.gameObject.SetActive(true);

			GameCon.guiHandler.defaultInventory.SetOtherInv(null);
			GameCon.guiHandler.defaultCrafting.SetBuilding(this);
			invOn = States.Craft;
		}
		else
		{
			GameCon.guiHandler.defaultCrafting.gameObject.SetActive(false);

			GameCon.guiHandler.defaultCrafting.SetBuilding(null);
			invOn = States.None;
		}

	}

	#region IHasGUI

	public override void Close()
	{
		base.Close();
		GameCon.guiHandler.defaultInventory.gameObject.SetActive(false);
		GameCon.guiHandler.defaultInventory.SetOtherInv(null);

		GameCon.guiHandler.defaultCrafting.gameObject.SetActive(false);
		GameCon.guiHandler.defaultCrafting.SetBuilding(null);
	}

	#endregion

	#region IRegystratabe

	public void Regystrate()
	{
		GameRegystry.RegisterBuildableBuilding(ID, this);
	}

	#endregion

	#region IBuildable

	public float GetBuildtime()
	{
		return 1;
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

	public void Setup()
	{
		return;
	}


	#endregion

	#region IInventory

	public int GetInventorySize()
	{
		return 10;
	}

	public string GetInventoryName()
	{
		return "asd";
	}

	public bool HasCustomInventoryName()
	{
		return true;
	}

	public Item GetStackInSlot(int i)
	{
		return inv.Get(i);
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
		throw new NotImplementedException();
	}

	public Item Add(Item i)
	{
		return inv.Add(i);
	}

	public Item Remove(Item i)
	{
		return inv.Remove(i);
	}

	public void TransferItem(IInventory ToInv, int index)
	{
		inv.TransferItem(ToInv, index);
	}

	public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
	{
		inv.TransferItemAmount(Toinv, fromindex, transferingAmount);
	}

	#endregion

	#region ICrafter
	public void AddToQueue(int i)
	{
		//throw new NotImplementedException();
		craftingQueue.Add(new CraftingProcess(GameRegystry.recepies[ID][i], 1));
		Debug.Log("asdasd");
	}

	public CraftingProcess[] GetQueue()
	{
		CraftingProcess[] a = new CraftingProcess[craftingQueue.Count];

		for (int i = 0; i < a.Length; i++)
		{
			a[i] = (CraftingProcess)craftingQueue.ToArray()[i];
		}

		return a;
	}

	public string GetCraftingID()
	{
		return ID;
	}

	public void RemoveFromQueue(int i)
	{
		craftingQueue.RemoveAt(i);
	}
	#endregion

}
