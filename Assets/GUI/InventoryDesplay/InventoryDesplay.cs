using UnityEngine;
using System.Collections;
using System;

public class InventoryDesplay : MonoBehaviour, IAccesTab
{
	public GameObject InventoryCanvasPlayer;
	public GameObject InventoryCanvasOther;

	public GameObject InventoryDubleElement;
	public GameObject InventoryElementBack;

	public GameObject[] drawedInvPlayer = new GameObject[10];
	public GameObject[] drawedInvOther = new GameObject[10];

	InventoryDrawedElement InventoryDravedElement;

	Inventory player;
	Inventory other;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Inventory;
	}

	void Update()
	{
		UpdateInventory();
	}

	public void UpdateInventory()
	{
		if (other == null)
		{
			UpdateInventorySection(player, drawedInvPlayer, InventoryCanvasPlayer.transform.FindChild("Items").gameObject, true);
		}
		else
		{
			UpdateInventorySection(player, other, drawedInvPlayer, InventoryCanvasPlayer.transform.FindChild("Items").gameObject, true);
		}
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
					if (actual.GetComponent<InventoryDrawedElement>() == null)
					{
						//Destroy back
						Destroy(actual);
						actual = null;

						//Create item
						actual = null;
						actual = Instantiate(InventoryDubleElement);
						actual.transform.SetParent(drawingCanvas.transform);
						actual.transform.SetSiblingIndex(i);


						actual.GetComponent<InventoryDrawedElement>().Set(invThis.inventory[i], isplayer, invOthe, invThis, i);


					}
					//Item element
					else if (actual.GetComponent<InventoryDrawedElement>() != null)
					{
						//update item
						drawed[i].GetComponent<InventoryDrawedElement>().Set(invThis.inventory[i].amount);
						drawed[i].GetComponent<InventoryDrawedElement>().other = invOthe;
						drawed[i].GetComponent<InventoryDrawedElement>().thisinv = invThis;

					}
				}
				else
				{
					//create item
					actual = null;
					actual = Instantiate(InventoryDubleElement);
					actual.transform.SetParent(drawingCanvas.transform);
					actual.transform.SetSiblingIndex(i);


					actual.GetComponent<InventoryDrawedElement>().Set(invThis.inventory[i], isplayer, invOthe, invThis, i);
				}
			}
			//nics item
			else
			{
				//Van kint valami
				if (actual != null)
				{
					// background
					if (actual.GetComponent<InventoryDrawedElement>() == null)
					{
						//OK
					}
					// Item element
					else if (actual.GetComponent<InventoryDrawedElement>() != null)
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


	void UpdateInventorySection(Inventory invThis, GameObject[] drawed, GameObject drawingCanvas, bool isplayer)
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
					if (actual.GetComponent<InventoryDrawedElement>() == null)
					{
						//Destroy back
						Destroy(actual);
						actual = null;

						//Create item
						actual = null;
						actual = Instantiate(InventoryDubleElement);
						actual.transform.SetParent(drawingCanvas.transform);
						actual.transform.SetSiblingIndex(i);


						actual.GetComponent<InventoryDrawedElement>().Set(invThis.inventory[i], isplayer, null, invThis, i);


					}
					//Item element
					else if (actual.GetComponent<InventoryDrawedElement>() != null)
					{
						//update item
						drawed[i].GetComponent<InventoryDrawedElement>().Set(invThis.inventory[i].amount);
						drawed[i].GetComponent<InventoryDrawedElement>().other = null;
						drawed[i].GetComponent<InventoryDrawedElement>().thisinv = invThis;

					}
				}
				else
				{
					//create item
					actual = null;
					actual = Instantiate(InventoryDubleElement);
					actual.transform.SetParent(drawingCanvas.transform);
					actual.transform.SetSiblingIndex(i);


					actual.GetComponent<InventoryDrawedElement>().Set(invThis.inventory[i], isplayer, null, invThis, i);
				}
			}
			//nics item
			else
			{
				//Van kint valami
				if (actual != null)
				{
					// background
					if (actual.GetComponent<InventoryDrawedElement>() == null)
					{
						//OK
					}
					// Item element
					else if (actual.GetComponent<InventoryDrawedElement>() != null)
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


	public void SetOtherInv(Inventory OtherInventory)
	{
		other = OtherInventory;
		if (OtherInventory != null)
		{
			foreach (GameObject des in drawedInvOther)
			{
				Destroy(des);
			}

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

	public void UpdateData()
	{
		throw new NotImplementedException();
	}

	public void UpdateData(Inventory datas)
	{
		SetOtherInv(datas);
	}

	public void UpdateData(Building datas)
	{
		if (datas is IInventory)
		{
			SetOtherInv(((IInventory)datas).GetInventory());
		}
		else
		{
			SetOtherInv(null);
		}
	}
}
