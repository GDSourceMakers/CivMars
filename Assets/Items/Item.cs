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
}

