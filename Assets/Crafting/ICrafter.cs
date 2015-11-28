using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface ICrafter
{
	void AddToQueue(int i);

	void RemoveFromQueue(int i);

	CraftingProcess[] GetQueue();

	string GetCraftingID();

}

