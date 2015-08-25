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
	public GameObject InventoryElementBack;

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

		UpdateInventorySection(player, drawedInvPlayer, InventoryCanvasPlayer.transform.FindChild("Items").gameObject, true);
		UpdateInventorySection(other, drawedInvOther, InventoryCanvasOther.transform.FindChild("Items").gameObject, false);
    }

	void UpdateInventorySection(Inventory inv, GameObject[] drawed, GameObject drawingCanvas, bool isplayer)
	{
		for (int i = 0; i < inv.size; i++)
		{
			bool isbackground = false;

			#region
			if (drawed[i] != null)
			{
				if (drawed[i].GetComponent<DualInventoryElement>() == null)
				{
					isbackground = true;
				}
				else
				{
					isbackground = false;
				}
			}
			#endregion

			//van itt elem
			if (inv.inventory[i] != null)
			{
				if (isbackground)
				{
					//Destroy back
					Destroy(drawed[i]);
					drawed[i] = null;

					//Create item
					InventoryDravedElement = null;
					InventoryDravedElement = Instantiate(InventoryDubleElement).GetComponent<DualInventoryElement>();
					InventoryDravedElement.transform.SetParent(drawingCanvas.transform);
					drawed[i] = InventoryDravedElement.gameObject;

					InventoryDravedElement.Set(inv.inventory[i], isplayer, other, player, i);


				}
				else if (drawed[i] != null)
				{
					//update item
					drawed[i].GetComponent<DualInventoryElement>().Set(inv.inventory[i].amount);
					drawed[i].GetComponent<DualInventoryElement>().other = other;
					drawed[i].GetComponent<DualInventoryElement>().thisinv = player;

				}
				else
				{
					//create item
					InventoryDravedElement = null;
					InventoryDravedElement = Instantiate(InventoryDubleElement).GetComponent<DualInventoryElement>();
					InventoryDravedElement.transform.SetParent(drawingCanvas.transform);
					drawed[i] = InventoryDravedElement.gameObject;

					InventoryDravedElement.Set(inv.inventory[i], isplayer, other, player, i);
				}
			}
			else
			{
				//Background
				if (isbackground)
				{
					//Oh that's good
				}
				// not background but somethig
				else if (drawed[i] != null)
				{
					//Destroy older
					Destroy(drawed[i]);
					drawed[i] = null;

					//Create Back
					drawed[i] = null;
					drawed[i] = Instantiate(InventoryElementBack);
					drawed[i].transform.SetParent(drawingCanvas.transform);
				}
				// not background not anithing else
				else
				{
					//Create Back
					drawed[i] = null;
					drawed[i] = Instantiate(InventoryElementBack);
					drawed[i].transform.SetParent(drawingCanvas.transform);
				}
			}
		
		}
	}



	/*
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
	*/

	/*
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
	*/

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