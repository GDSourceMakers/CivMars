using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class Item
{
	public int amount;
	public int maxStackSize;

	public Item(int setAmount)
	{
		amount = setAmount;
	}

	public Item(int setAmount, int SetMaxStackSize)
	{
		amount = setAmount;
		maxStackSize = SetMaxStackSize;
	}

	public Item()
	{
	}


	public int Add(int addAmount)
	{
		if ((amount + addAmount) > (maxStackSize))
		{
			int reamaining = (amount + addAmount) - maxStackSize;
			amount = maxStackSize;
			//Debug.Log(amount);
			return reamaining;
		}
		else
		{
			amount = amount + addAmount;
			//Debug.Log(i.amount);
			return -1;
		}
	}

	/// <summary>
	/// Remove amonunt fron the item
	/// </summary>
	/// <param name="remAmount">amount to remove</param>
	/// <returns>Returns the remaining amount or -1 if completed</returns>
	public int Remove(int remAmount)
	{
		if ((amount - remAmount) < 0)
		{
			int reamaining = remAmount - amount;
			amount = 0;
			//Debug.Log(amount);
			return reamaining;
		}
		else
		{
			amount = amount - remAmount;
			//Debug.Log(i.amount);
			return -1;
		}
	}
	
}

