using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Inventory
{

	public Item[] inventory;

	public int size;


	public Inventory(int InventorySize)
	{
		if (InventorySize < 1)
			Debug.LogErrorFormat("Inventory size can't be less than 0", this);
		inventory = new Item[InventorySize];
		this.size = InventorySize;
	}


	public Item Add(Item adding)
	{
		//int size = adding.amount;

		foreach (Item item in inventory)
		{
			if (item != null)
			{
				if (item.GetType() == adding.GetType())
				{
					//Debug.Log(adding.GetType());
					adding.amount = item.Add(adding.amount);

					Debug.Log("Inventory added: " + item.GetType() + " Amount: " + adding.amount);

					if (adding.amount == -1)
					{
						return null;
					}
				}
			}
		}

		for (int i = 0; i < 10; i++)
		{
			if (inventory[i] == null)
			{
				inventory[i] = adding;
				return null;
			}
		}

		return null;

	}


	public Item Remove(Item removing)
	{
		for (int i = 0; i < inventory.GetLength(0); i++)
		{
			Item item = inventory[i];
			if (item != null)
			{
				if (item.GetType() == removing.GetType())
				{
					//Debug.Log(adding.GetType());
					removing.amount = item.Remove(removing.amount);
					Debug.Log("Inventory added: " + item.GetType() + " Amount: " + item.amount);

					Check(i);


				}
			}
		}
		if (removing.amount == -1)
		{
			return null;
		}
		return removing;

	}

	void Check(int i)
	{
		if (inventory[i].amount <= 0)
		{
			inventory[i] = null;
		}
	}

	/// <summary>
	/// Remove item at index
	/// </summary>
	/// <param name="index">index of the item</param>
	public void Remove(int index)
	{
		inventory[index] = null;
	}


	/// <summary>
	/// Remove amount from item at index
	/// </summary>
	/// <param name="index">index of the item</param>
	/// <param name="amount">amount to remove</param>
	public void Remove(int index, int amount)
	{
		
		if (inventory[index].Remove(amount) < 0)
		{
			inventory[index] = null;
		}
	}

	/// <summary>
	/// Finds the Iten witch is T
	/// Returns null if not found
	/// </summary>
	/// <typeparam name="T">Type of item</typeparam>
	/// <returns>The first item witch matches</returns>
	public Item Find<T>()
	{
		foreach (Item i in inventory)
		{
			if (i is T)
			{
				return i;
			}
		}

		return null;
	}

	/// <summary>
	/// Gives the item at the index
	/// </summary>
	/// <param name="i">index</param>
	/// <returns>Item</returns>
	public Item Get(int i)
	{
		return inventory[i];
	}

	/// <summary>
	/// Transfers a item from this inventory to a other
	/// </summary>
	/// <param name="ToInv">other inv to transfer to</param>
	/// <param name="index">this inventorys index to transfer</param>
	public void TransferItem(IInventory ToInv, int index)
	{
		ToInv.Add(this.Get(index));
		this.Remove(index);
	}

	/// <summary>
	/// Transfers a specific amount of a item from this inventory to a other
	/// </summary>
	/// <param name="Toinv">other inv to transfer to</param>
	/// <param name="fromindex">this inventorys index to transfer</param>
	/// <param name="transferingAmount">amount to tramsfer</param>
	public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
	{
		Debug.Log(inventory[fromindex]);

		int remaining = inventory[fromindex].Remove(transferingAmount);
		
		Item addable = (((Item)Activator.CreateInstance(null, inventory[fromindex].GetType().ToString()).Unwrap()));
		if (remaining == -1)
		{
			addable.amount = transferingAmount;
		}
		else
		{
			addable.amount = transferingAmount - remaining;
		}
		Toinv.Add(addable);
		Check(fromindex);
	}


	/*
		public int AddAmount(int rAmount, Item i)
		{
			if ((i.amount + rAmount) > (i.maxStackSize))
			{
				int reamaining = (i.amount + rAmount) - i.maxStackSize;
				i.amount = i.maxStackSize;
				Debug.Log(i.amount);
				return reamaining;
			}
			else
			{
				i.amount = i.amount + rAmount;
				Debug.Log(i.amount);
				return 0;
			}

		}
		*/
}
