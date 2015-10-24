using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

[AddComponentMenu("Buildings/Main Building")]
[System.Serializable]
public class MainBuilding : Building , IInventory, IGasTank
{
	new static public int ID = 1;

	public Text Name;
    public Text InventoryButtonText;
    

	public Inventory inventory = new Inventory(20);

	public static float[] max = { 1000f, 1000f, 1000f, 1000f };
	public GasTankCluster tanks = new GasTankCluster(4, max);


    public void OpenInventory()
    {
        GameCon.TogleAccesPanel(this);
    }

	public Inventory GetInventory()
	{
		return inventory;
	}

	public GasTankCluster GetTankCluster()
	{
		return tanks;
	}
}
