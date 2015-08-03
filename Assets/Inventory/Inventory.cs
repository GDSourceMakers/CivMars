using UnityEngine;
using System.Collections;

public class Inventory
{

    public Item[] inventory = new Item[10];
    

   

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
}
