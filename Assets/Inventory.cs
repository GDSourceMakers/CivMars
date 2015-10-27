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
		int size = adding.amount;

		foreach (Item item in inventory)
		{
			if (item != null)
			{
				if (item.GetType() == adding.GetType())
				{
					//Debug.Log(adding.GetType());
					size = item.Add(adding.amount);

					Debug.Log("Inventory added: " + item.GetType() + " Amount: " + item.amount);

					if (size == -1)
					{
						return item;
					}

					adding.amount = size;
				}
			}
		}

		for (int i = 0; i < 10; i++)
		{
			if (inventory[i] == null)
			{
				inventory[i] = adding;
				return inventory[i];
			}
		}

		return null;

	}


	public int Remove(Item type, int amount)
	{
		int size = amount;
		for (int i = 0; i < inventory.GetLength(0); i++)
		{

			Item item = inventory[i];

			if (item != null)
			{
				if (item.GetType() == type.GetType())
				{
					//Debug.Log(adding.GetType());
					size = item.Remove(amount);
					Debug.Log("Inventory added: " + item.GetType() + " Amount: " + item.amount);
					if (item.amount == 0)
					{
						item = null;
					}

					

					if (size == -1)
					{
						return 0;
					}

					amount = size;
				}
			}
		}

		return size;

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
		inventory[index].Remove(amount);
		if (inventory[index].amount == 0)
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
	public void TransferItem(Inventory ToInv, int index)
	{
		this.Add(ToInv.Get(index));
		ToInv.Remove(index);
	}

	/// <summary>
	/// Transfers a specific amount of a item from this inventory to a other
	/// </summary>
	/// <param name="Toinv">other inv to transfer to</param>
	/// <param name="Fromindex">this inventorys index to transfer</param>
	/// <param name="transferingAmount">amount to tramsfer</param>
	public void TransferItemAmount(Inventory Toinv, int Fromindex, int transferingAmount)
	{
		Debug.Log(inventory[Fromindex]);

		if (inventory[Fromindex].amount - transferingAmount < 0)
		{
			Item addable = (((Item)Activator.CreateInstance(null, inventory[Fromindex].GetType().ToString()).Unwrap()));
			addable.amount = (transferingAmount - inventory[Fromindex].amount);
			Toinv.Add(addable);
			Remove(Fromindex);

		}
		else if (inventory[Fromindex].amount - transferingAmount == 0)
		{
			Item addable = (((Item)Activator.CreateInstance(null, inventory[Fromindex].GetType().ToString()).Unwrap()));
			addable.amount = transferingAmount;
			Toinv.Add(addable);
			Remove(Fromindex);
		}
		else if (inventory[Fromindex].amount - transferingAmount > 0)
		{
			Item addable = (((Item)Activator.CreateInstance(null, inventory[Fromindex].GetType().ToString()).Unwrap()));
			addable.amount = transferingAmount;
			Toinv.Add(addable);
			inventory[Fromindex].amount -= transferingAmount;
		}
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
