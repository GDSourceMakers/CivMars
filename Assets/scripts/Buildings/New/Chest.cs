using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("Buildings/Chest")]
public class Chest : Building
{
	new static public int ID = 2;

	public Text Name;
	public Text InventoryButtonText;
	public Text asd;


	public Inventory inventory = new Inventory(15);


	

	public void OpenInventory()
	{
		GameCon.TogleDualInventory(inventory);
	}

}
