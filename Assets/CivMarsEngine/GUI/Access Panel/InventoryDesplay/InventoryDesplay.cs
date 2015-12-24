using UnityEngine;
using System.Collections;
using System;

namespace CivMarsEngine
{
	public class InventoryDesplay : MonoBehaviour
	{
		public GameObject InventoryCanvasPlayer;
		public GameObject InventoryCanvasOther;

		public GameObject InventoryDubleElement;
		public GameObject InventoryElementBack;

		GameObject[] drawedInvPlayer = new GameObject[10];
		GameObject[] drawedInvOther = new GameObject[10];

		IInventory player;
		IInventory other;

		void Start()
		{
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		}

		void Update()
		{
			UpdateInventory();
		}

		public void UpdateInventory()
		{
			UpdateInventorySection(player, other, drawedInvPlayer, InventoryCanvasPlayer, true);

			UpdateInventorySection(other, player, drawedInvOther, InventoryCanvasOther, false);
		}

		void UpdateInventorySection(IInventory invThis, IInventory invOthe, GameObject[] drawed, GameObject drawingCanvas, bool isplayer)
		{
			for (int i = 0; i < invThis.GetInventorySize(); i++)
			{
				GameObject actual = drawed[i];

				//van itt item
				if (invThis.GetStackInSlot(i) != null)
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
							actual = Instantiate(InventoryDubleElement);
							actual.transform.SetParent(drawingCanvas.transform);
							actual.transform.SetSiblingIndex(i);

							actual.transform.localScale = Vector3.one;
							actual.GetComponent<InventoryDrawedElement>().Set(invThis.GetStackInSlot(i), isplayer, invOthe, invThis, i);
						}
						//Item element
						else
						{
							//update item
							drawed[i].GetComponent<InventoryDrawedElement>().Set(invThis.GetStackInSlot(i).amount);
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

						actual.transform.localScale = Vector3.one;
						actual.GetComponent<InventoryDrawedElement>().Set(invThis.GetStackInSlot(i), isplayer, invOthe, invThis, i);
						drawed[i] = actual;
					}
				}
				//nics item
				else
				{
					//Van kint valami
					if (actual != null)
					{
						// background
						if (actual.GetComponent<InventoryDrawedElement>() != null)
						{
							//Destroy older
							Destroy(actual);
							actual = null;

							//Create Back
							actual = null;
							actual = Instantiate(InventoryElementBack);
							actual.transform.SetParent(drawingCanvas.transform);
							actual.transform.SetSiblingIndex(i);

							actual.transform.localScale = Vector3.one;
						}
					}
					else
					{
						//Create Back
						actual = null;
						actual = Instantiate(InventoryElementBack);
						actual.transform.SetParent(drawingCanvas.transform);
						actual.transform.SetSiblingIndex(i);

						actual.transform.localScale = Vector3.one;
					}
				}
				drawed[i] = actual;
			}

			int a = invThis.GetInventorySize() / 3;
			if (invThis.GetInventorySize() % 3 > 0)
			{
				a++;
			}
			drawingCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (a * (50)) + 10);
		}

		/*
		void UpdateInventorySection(IInventory invThis, GameObject[] drawed, GameObject drawingCanvas, bool isplayer)
		{
			for (int i = 0; i < invThis.GetInventorySize(); i++)
			{


				GameObject actual = drawed[i];

				//van itt item
				if (invThis.GetStackInSlot(i) != null)
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


							actual.GetComponent<InventoryDrawedElement>().Set(invThis.GetStackInSlot(i), isplayer, null, invThis, i);


						}
						//Item element
						else if (actual.GetComponent<InventoryDrawedElement>() != null)
						{
							//update item
							drawed[i].GetComponent<InventoryDrawedElement>().Set(invThis.GetStackInSlot(i).amount);
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


						actual.GetComponent<InventoryDrawedElement>().Set(invThis.GetStackInSlot(i), isplayer, null, invThis, i);
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
		*/

		public void Activate(IInventory OtherInventory)
		{
			if (OtherInventory != null)
			{
				other = OtherInventory;

				drawedInvOther = new GameObject[other.GetInventorySize()];

				gameObject.SetActive(true);
			}
		}

		public void Deactive()
		{
			other = null;

			foreach (GameObject des in drawedInvOther)
			{
				Destroy(des);
			}

			gameObject.SetActive(false);

		}

		/*
			public void SetOtherInv(IInventory OtherInventory)
			{
				other = OtherInventory;
				if (OtherInventory != null)
				{
					foreach (GameObject des in drawedInvOther)
					{
						Destroy(des);
					}

					drawedInvOther = new GameObject[other.GetInventorySize()];
				}
				else
				{
					foreach (GameObject des in drawedInvOther)
					{
						Destroy(des);
					}
				}
			}
		*/

		public void UpdateData()
		{
			throw new NotImplementedException();
		}

		public void UpdateData(Building datas)
		{
			if (datas is IInventory)
			{
				Activate(((IInventory)datas));
			}
			else
			{
				Deactive();
			}
		}
	}
}