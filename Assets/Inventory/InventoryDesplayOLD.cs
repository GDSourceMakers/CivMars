using UnityEngine;
using System.Collections;

/*
[AddComponentMenu("Inventory/Inventory Desplay")]
public class InventoryDesplay : MonoBehaviour
{



    public GameObject InventoryCanvas;
    //public GameObject InventoryCanvasPlayer;
    //public GameObject InventoryCanvasOther;

    public GameObject InventoryPrefab;
    //public GameObject InventoryDubleElement;

    public GameObject[] drawedInvPlayer = new GameObject[10];
    //public GameObject[] drawedInvOther = new GameObject[10];

    InventoryDrawedElement InventoryDravedElement;

    public Inventory player;
    //Inventory other;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Inventory;
    }

    void Update()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        Inventory inv = player;

        
        GameObject[] drawedInv = drawedInvPlayer;

        for (int i = 0; i < inv.size; i++)
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
            else
            {
                if (drawedInv[i] != null)
                {
                    Destroy(drawedInv[i]);
                    drawedInv[i] = null;
                }
            }
        }
    }


    public void UpdateInventory(Inventory inv, int num)
    {
       
        GameObject[] drawedInv = drawedInvPlayer;
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


	*/