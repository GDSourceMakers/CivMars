using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

[AddComponentMenu("Buildings/Main Building")]
[System.Serializable]
public class MainBuilding : Building
{
	new static public int ID = 1;

	public Text Name;
    public Text InventoryButtonText;
    public Text asd;
    

	public Inventory inventory = new Inventory(20);



    public void OpenInventory()
    {
        GameCon.TogleInventory(inventory);
    }

}
