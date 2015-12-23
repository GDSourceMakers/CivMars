using UnityEngine;
using System.Collections;
using System;

namespace CivMarsEngine
{
	public class PlayerInventory : MonoBehaviour
	{
		public GameObject InventoryCanvasPlayer;
		//public GameObject InventoryCanvasOther;

		public GameObject InventoryDubleElement;
		public GameObject InventoryElementBack;

		GameObject[] drawedInvPlayer = new GameObject[10];
		//GameObject[] drawedInvOther = new GameObject[10];

		IInventory player;
		//IInventory other;

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

			for (int i = 0; i < player.GetInventorySize(); i++)
			{
				GameObject actual = drawedInvPlayer[i];

				//van itt item
				if (player.GetStackInSlot(i) != null)
				{
					//Van kint valami
					if (actual != null)
					{
						//Background element
						if (actual.GetComponent<PlayerInventoryDrawedElement>() == null)
						{
							//Destroy back
							Destroy(actual);
							actual = null;

							//Create item
							actual = null;
							actual = Instantiate(InventoryDubleElement);
							actual.transform.SetParent(InventoryCanvasPlayer.transform);
							actual.transform.SetSiblingIndex(i);


							actual.GetComponent<PlayerInventoryDrawedElement>().Set(player.GetStackInSlot(i), i);


						}
						//Item element
						else
						{
							//update item
							drawedInvPlayer[i].GetComponent<PlayerInventoryDrawedElement>().Set(player.GetStackInSlot(i), i);

						}
					}
					else
					{
						//create item
						actual = null;
						actual = Instantiate(InventoryDubleElement);
						actual.transform.SetParent(InventoryCanvasPlayer.transform);
						actual.transform.SetSiblingIndex(i);


						actual.GetComponent<PlayerInventoryDrawedElement>().Set(player.GetStackInSlot(i), i);
					}
				}
				//nics item
				else
				{
					//Van kint valami
					if (actual != null)
					{
						// background
						if (actual.GetComponent<PlayerInventoryDrawedElement>() == null)
						{
							//OK
						}
						// Item element
						else
						{
							//Destroy older
							Destroy(actual);
							actual = null;

							//Create Back
							actual = null;
							actual = Instantiate(InventoryElementBack);
							actual.transform.SetParent(InventoryCanvasPlayer.transform);
							actual.transform.SetSiblingIndex(i);
						}
					}
					else
					{
						//Create Back
						actual = null;
						actual = Instantiate(InventoryElementBack);
						actual.transform.SetParent(InventoryCanvasPlayer.transform);
						actual.transform.SetSiblingIndex(i);
					}
				}
				drawedInvPlayer[i] = actual;
			}
		}

	}
}