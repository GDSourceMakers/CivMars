using UnityEngine;
using System.Collections;

public class InventoryDesplay : MonoBehaviour
{

    public GameObject InventoryCanvas;
    public GameObject InventoryPrefab;

    public GameObject[] drawedInv = new GameObject[10];

    InventoryDrawedElement InventoryDravedElement;


    public void UpdateInventory(Inventory inv)
    {
        for (int i = 0; i < 10; i++)
        {
            if (inv.inventory[i] != null)
            {

                if (drawedInv[i] == null)
                {
                    
                    InventoryDravedElement = null;
                    InventoryDravedElement = Instantiate(InventoryPrefab).GetComponent<InventoryDrawedElement>();
                    InventoryDravedElement.transform.SetParent(InventoryCanvas.transform);
                    

                    InventoryDravedElement.Set(inv.inventory[i]);

                    drawedInv[i] = InventoryDravedElement.gameObject;
                    Debug.Log(inv.inventory[i].GetType());
                    Debug.Log("Drawed " + i);
                }
                else
                {
                    InventoryDravedElement = drawedInv[i].GetComponent<InventoryDrawedElement>();
                    InventoryDravedElement.Set(inv.inventory[i].amount);
                    Debug.Log(inv.inventory[i].GetType() + "  " + InventoryDravedElement.name);
                    Debug.Log("Drawed " + i);
                }
            }
        }
    }

    public void UpdateInventory(Inventory inv, int num)
    {
        
            if (inv.inventory[num] != null)
            {

                if (drawedInv[num] == null)
                {

                    //invDwrEl = drawedInv[i].GetComponent<InventoryDrawedElement>();

                    Debug.Log("Drawed " + num);

                    InventoryDravedElement = null;
                    InventoryDravedElement = Instantiate(InventoryPrefab).GetComponent<InventoryDrawedElement>();
                    InventoryDravedElement.transform.SetParent(InventoryCanvas.transform);
                    Debug.Log(inv.inventory[num].GetType());

                    InventoryDravedElement.Set(inv.inventory[num]);

                    drawedInv[num] = InventoryDravedElement.gameObject;
                }
                else
                {
                    InventoryDravedElement.Set(inv.inventory[num]);
                }
            }
        }
    }


