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


    public Item Add(Item added)
    {
        int size = added.amount;

        foreach (Item item in inventory)
        {

            if (item != null)
            {

                if (item.GetType() == added.GetType())
                {
                    Debug.Log(added.GetType());

                    size = AddAmount(added.amount, item);

                    Debug.Log("Inventory added: " + item.GetType() + " Amount: " + item.amount);
                    if (size == 0)
                    {
                        return item;
                    }
                    added.amount = size;
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = added;
                return inventory[i];
            }
        }

        return null;

    }

    public void Remove(int i)
    {
        inventory[i] = null;
    }


	public Item Get(int i)
    {
        return inventory[i];
    }

    public void TransferItem(Inventory inv, int index)
    {
        this.Add(inv.Get(index));
        inv.Remove(index);
    }

    public void TransferItemAmount(Inventory Toinv, int Fromindex, int addingAmount)
    {
        
		

  //      Toinv.Add(inventory[Fromindex]);

		//if (inventory[Fromindex].amount == 0)
		//{
		//	Remove(Fromindex);
		//}

		
		Debug.Log(inventory[Fromindex]);

		if (inventory[Fromindex].amount - addingAmount < 0)
		{
			Item addable = (((Item)Activator.CreateInstance(null, inventory[Fromindex].GetType().ToString()).Unwrap()));

			addable.amount = (addingAmount - inventory[Fromindex].amount);

			 Toinv.Add(addable);

			Remove(Fromindex);
			
		}
		else if (inventory[Fromindex].amount - addingAmount == 0)
		{
			Item addable = (((Item)Activator.CreateInstance(null, inventory[Fromindex].GetType().ToString()).Unwrap()));

			addable.amount = addingAmount;

			Toinv.Add(addable);

			Remove(Fromindex);
		}
		else if (inventory[Fromindex].amount - addingAmount > 0)
		{
			Item addable = (((Item)Activator.CreateInstance(null, inventory[Fromindex].GetType().ToString()).Unwrap()));

			addable.amount = addingAmount;

			Toinv.Add(addable);

			inventory[Fromindex].amount -= addingAmount;

			//Remove(Fromindex);
		}


		;
	

}

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
}
