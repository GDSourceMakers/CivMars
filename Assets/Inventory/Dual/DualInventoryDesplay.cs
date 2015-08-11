using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DualInventoryDesplay : MonoBehaviour
{


    public GameObject InventoryCanvasPlayer;
    public GameObject InventoryCanvasOther;


    public GameObject InventoryDubleElement;

    public GameObject[] drawedInvPlayer = new GameObject[10];
    public GameObject[] drawedInvOther = new GameObject[10];

    DualInventoryElement InventoryDravedElement;

    Inventory player;
    Inventory other;

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
        #region player inventory

        Inventory inv = player;

        GameObject drawingCanvas = InventoryCanvasPlayer.transform.FindChild("Items").gameObject;
        GameObject[] drawedInv = drawedInvPlayer;

        for (int i = 0; i < inv.size; i++)
        {
            if (inv.inventory[i] != null)
            {

                if (drawedInv[i] == null)
                {
                    #region setup all
                    #region setup part
                    InventoryDravedElement = null;
                    InventoryDravedElement = Instantiate(InventoryDubleElement).GetComponent<DualInventoryElement>();
                    InventoryDravedElement.transform.SetParent(drawingCanvas.transform);
                    #endregion
                    InventoryDravedElement.Set(inv.inventory[i]);
                    drawedInv[i] = InventoryDravedElement.gameObject;
                    drawedInv[i].GetComponent<DualInventoryElement>().isPlayer = true;
                    drawedInv[i].GetComponent<DualInventoryElement>().other = other;
                    drawedInv[i].GetComponent<DualInventoryElement>().thisinv = player;
                    drawedInv[i].GetComponent<DualInventoryElement>().index = i;

                    //Debug.Log(inv.inventory[i].GetType());
                    //Debug.Log("Drawed " + i);
                    #endregion
                }
                else
                {
                    InventoryDravedElement = drawedInv[i].GetComponent<DualInventoryElement>();
                    InventoryDravedElement.Set(inv.inventory[i].amount);
                    //Debug.Log(inv.inventory[i].GetType() + "  " + InventoryDravedElement.name);
                    //Debug.Log("Drawed " + i);
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
        #endregion


        #region other inventory

        inv = other;

        drawingCanvas = InventoryCanvasOther.transform.FindChild("Items").gameObject;
        drawedInv = drawedInvOther;

        for (int i = 0; i < inv.size; i++)
        {
            if (inv.inventory[i] != null)
            {

                if (drawedInv[i] == null)
                {
                    #region setup part
                    InventoryDravedElement = null;
                    InventoryDravedElement = Instantiate(InventoryDubleElement).GetComponent<DualInventoryElement>();
                    InventoryDravedElement.transform.SetParent(drawingCanvas.GetComponent<RectTransform>());

                    InventoryDravedElement.Set(inv.inventory[i]);
                    drawedInv[i] = InventoryDravedElement.gameObject;
                    drawedInv[i].GetComponent<DualInventoryElement>().isPlayer = false;
                    drawedInv[i].GetComponent<DualInventoryElement>().other = player;
                    drawedInv[i].GetComponent<DualInventoryElement>().thisinv = other;
                    drawedInv[i].GetComponent<DualInventoryElement>().index = i;

                    //Debug.Log(inv.inventory[i].GetType());
                    //Debug.Log("Drawed " + i);
                    #endregion
                }
                else
                {
                    #region change part
                    InventoryDravedElement = drawedInv[i].GetComponent<DualInventoryElement>();
                    InventoryDravedElement.Set(inv.inventory[i].amount);
                    //Debug.Log(inv.inventory[i].GetType() + "  " + InventoryDravedElement.name);
                    //Debug.Log("Drawed " + i);
                    #endregion
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
        #endregion
    }


    public void UpdateInventory(Inventory inv, int num)
    {
        GameObject drawingCanvas = InventoryCanvasPlayer;
        GameObject[] drawedInv = drawedInvPlayer;
        if (inv.inventory[num] != null)
        {

            if (drawedInv[num] == null)
            {

                //invDwrEl = drawedInv[i].GetComponent<InventoryDrawedElement>();

                Debug.Log("Drawed " + num);

                InventoryDravedElement = null;
                InventoryDravedElement = Instantiate(InventoryDubleElement).GetComponent<DualInventoryElement>();
                InventoryDravedElement.transform.SetParent(drawingCanvas.transform);
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

    public void DesplayInventory(Inventory player, Inventory other)
    {

        Inventory inv = player;
        GameObject drawingCanvas = InventoryCanvasPlayer;
        GameObject[] drawedInv = drawedInvPlayer;

        #region player inventory drawing
        for (int i = 0; i < inv.size; i++)
        {
            if (inv.inventory[i] != null)
            {

                if (drawedInv[i] == null)
                {

                    InventoryDravedElement = null;
                    InventoryDravedElement = Instantiate(InventoryDubleElement).GetComponent<DualInventoryElement>();
                    InventoryDravedElement.transform.SetParent(InventoryCanvasPlayer.transform);


                    InventoryDravedElement.Set(inv.inventory[i]);

                    drawedInv[i] = InventoryDravedElement.gameObject;
                    Debug.Log(inv.inventory[i].GetType());
                    Debug.Log("Drawed " + i);
                }
                else
                {
                    InventoryDravedElement = drawedInv[i].GetComponent<DualInventoryElement>();
                    InventoryDravedElement.Set(inv.inventory[i].amount);
                    Debug.Log(inv.inventory[i].GetType() + "  " + InventoryDravedElement.name);
                    Debug.Log("Drawed " + i);
                }
            }
        }
        #endregion

        inv = other;
        drawingCanvas = InventoryCanvasOther;
        drawedInv = drawedInvOther;


        #region Other inventory drawing
        for (int i = 0; i < inv.size; i++)
        {
            if (inv.inventory[i] != null)
            {

                if (drawedInv[i] == null)
                {

                    InventoryDravedElement = null;
                    InventoryDravedElement = Instantiate(InventoryDubleElement).GetComponent<DualInventoryElement>();
                    InventoryDravedElement.transform.SetParent(InventoryCanvasPlayer.transform);


                    InventoryDravedElement.Set(inv.inventory[i]);

                    drawedInv[i] = InventoryDravedElement.gameObject;
                    Debug.Log(inv.inventory[i].GetType());
                    Debug.Log("Drawed " + i);
                }
                else
                {
                    InventoryDravedElement = drawedInv[i].GetComponent<DualInventoryElement>();
                    InventoryDravedElement.Set(inv.inventory[i].amount);
                    Debug.Log(inv.inventory[i].GetType() + "  " + InventoryDravedElement.name);
                    Debug.Log("Drawed " + i);
                }
            }
        }
        #endregion

    }

    public void SetOtherInv(Inventory OtherInventory)
    {
        other = OtherInventory;
        if (OtherInventory != null)
        {
            drawedInvOther = new GameObject[other.size];
        }
        else
        {
            foreach (GameObject des in drawedInvOther)
            {
                Destroy(des);
            }
        }
    }



}
