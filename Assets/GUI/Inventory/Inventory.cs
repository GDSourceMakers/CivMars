using UnityEngine;
using System.Collections;

[System.Serializable]
public class Inventory
{

    public Item[] inventory;

    public int size;
   

    public void Add(Item added)
    {
        foreach (Item item in inventory)
        {

            if (item != null)
            {
                
                if (item.GetType() == added.GetType())
                {
                    Debug.Log(added.GetType());
                    item.amount += added.amount;
                    Debug.Log("Inventory added: " + item.GetType() + " Amount: " + item.amount);
                    
                    return;
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = added;
                return;
            }
        }

        
    }

    public Inventory (int InventorySize)
    {
        inventory = new Item[InventorySize];
        this.size = InventorySize;
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
}
