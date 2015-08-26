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

		UpdateInventorySection(player, other, drawedInvPlayer, InventoryCanvasPlayer.transform.FindChild("Items").gameObject, true);
		if (other != null)
		{
			UpdateInventorySection(other, player, drawedInvOther, InventoryCanvasOther.transform.FindChild("Items").gameObject, false);
		}
		else
		{
			foreach (GameObject item in drawedInvOther)
			{
				Destroy(item);
			}
		}
	}

	void UpdateInventorySection(Inventory invThis, Inventory invOthe, GameObject[] drawed, GameObject drawingCanvas, bool isplayer)
	{
		for (int i = 0; i < invThis.size; i++)
		{
			

			GameObject actual = drawed[i];

			//van itt item
			if (invThis.inventory[i] != null)
			{
				//Van kint valami
				if (actual != null)
				{
					//Background element
					if (actual.GetComponent<DualInventoryElement>() == null)
					{
						//Destroy back
						Destroy(actual);
						actual = null;

						//Create item
						actual = null;
						actual = Instantiate(InventoryDubleElement);
						actual.transform.SetParent(drawingCanvas.transform);
						actual.transform.SetSiblingIndex(i);


						actual.GetComponent<DualInventoryElement>().Set(invThis.inventory[i], isplayer, invOthe, invThis, i);


					}
					//Item element
					else if (actual.GetComponent<DualInventoryElement>() != null)
					{
						//update item
						drawed[i].GetComponent<DualInventoryElement>().Set(invThis.inventory[i].amount);
						drawed[i].GetComponent<DualInventoryElement>().other = invOthe;
						drawed[i].GetComponent<DualInventoryElement>().thisinv = invThis;

					}
				}
				else
				{
					//create item
					actual = null;
					actual = Instantiate(InventoryDubleElement);
					actual.transform.SetParent(drawingCanvas.transform);
					actual.transform.SetSiblingIndex(i);


					actual.GetComponent<DualInventoryElement>().Set(invThis.inventory[i], isplayer, invOthe, invThis, i);
				}
			}
			//nics item
			else
			{
				//Van kint valami
				if (actual != null)
				{
					// background
					if (actual.GetComponent<DualInventoryElement>() == null)
					{
						//OK
					}
					// Item element
					else if (actual.GetComponent<DualInventoryElement>() != null)
					{
						//Destroy older
						Destroy(actual);
						actual = null;

						//Create Back
						actual = null;
						actual = Instantiate(InventoryElementBack);
						actual.transform.SetParent(drawingCanvas.transform);
						actual.transform.SetSiblingIndex(i);
					}
				}
				else
				{
					//Create Back
					actual = null;
					actual = Instantiate(InventoryElementBack);
					actual.transform.SetParent(drawingCanvas.transform);
					actual.transform.SetSiblingIndex(i);
				}
			}
			drawed[i] = actual;
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