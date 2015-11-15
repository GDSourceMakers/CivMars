using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GasDesplay : MonoBehaviour, IAccesTab
{


	public GameObject GasCanvasPlayer;
	public GameObject GasCanvasOther;

	public GameObject TankElement;
	public GameObject TankElementBack;

	public GameObject[] drawedInvPlayer = new GameObject[10];
	public GameObject[] drawedInvOther = new GameObject[10];

	GasTankCluster player;
	GasTankCluster other;

	public GasDesplayElement OutPuting;
	public GasDesplayElement InPuting;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetTankCluster();
	}


	void Update()
	{
		UpdateDesplay();
		if ((OutPuting != null && InPuting != null) && (OutPuting.tank.gasType == InPuting.tank.gasType || InPuting.tank.gasType == GasType.Null))
		{
			OutPuting.tank.Transfer(InPuting.tank, 5f * Time.deltaTime);
		}
	}

	public void UpdateData(Building datas)
	{
		if (datas is IGasTank)
		{
			other = ((IGasTank)datas).GetTankCluster();
		}
	}

	public void UpdateDesplay()
	{
		if (other == null)
		{
			UpdateDesplaySection(player, drawedInvPlayer, GasCanvasPlayer.gameObject, true);

			foreach (GameObject item in drawedInvOther)
			{
				Destroy(item);
			}
		}
		else
		{
			UpdateDesplaySection(player, other, drawedInvPlayer, GasCanvasPlayer.gameObject, true);
			UpdateDesplaySection(other, player, drawedInvOther, GasCanvasOther.gameObject, false);
		}
	}

	void UpdateDesplaySection(GasTankCluster TankThis, GasTankCluster TankOthe, GameObject[] drawed, GameObject drawingCanvas, bool isplayer)
	{
		for (int i = 0; i < TankThis.size; i++)
		{
			GameObject actual = drawed[i];

			//van itt item

			//Van kint valami
			if (actual != null)
			{
				//Background element
				if (actual.GetComponent<GasDesplayElement>() == null)
				{
					//Destroy back
					Destroy(actual);
					actual = null;

					//Create item
					actual = null;
					actual = Instantiate(TankElement);
					actual.transform.SetParent(drawingCanvas.transform);
					actual.transform.SetSiblingIndex(i);


					actual.GetComponent<GasDesplayElement>().Set(TankThis.GetTank(i), this);
				}
			}
			else
			{
				//create item
				actual = null;
				actual = Instantiate(TankElement);
				actual.transform.SetParent(drawingCanvas.transform);
				actual.transform.SetSiblingIndex(i);


				actual.GetComponent<GasDesplayElement>().Set(TankThis.GetTank(i), this);
			}


			drawed[i] = actual;
		}
	}

	void UpdateDesplaySection(GasTankCluster TankThis, GameObject[] drawed, GameObject drawingCanvas, bool isplayer)
	{
		for (int i = 0; i < TankThis.size; i++)
		{
			GameObject actual = drawed[i];

			//van itt item
			if (TankThis.GetTank(i).gasType != GasType.Null)
			{
				//Van kint valami
				if (actual != null)
				{
					//Background element
					if (actual.GetComponent<GasDesplayElement>() == null)
					{
						//Destroy back
						Destroy(actual);
						actual = null;

						//Create item
						actual = null;
						actual = Instantiate(TankElement);
						actual.transform.SetParent(drawingCanvas.transform);
						actual.transform.SetSiblingIndex(i);


						actual.GetComponent<GasDesplayElement>().Set(TankThis.GetTank(i), this);


					}
					//Item element
					else if (actual.GetComponent<GasDesplayElement>() != null)
					{
						//update item
						drawed[i].GetComponent<GasDesplayElement>().Set(TankThis.GetTank(i), this);
					}
				}
				else
				{
					//create item
					actual = null;
					actual = Instantiate(TankElement);
					actual.transform.SetParent(drawingCanvas.transform);
					actual.transform.SetSiblingIndex(i);

					Debug.Log(TankThis.GetTank(i).ToString());

					actual.GetComponent<GasDesplayElement>().Set(TankThis.GetTank(i), this);
				}
			}
			//nics item
			else
			{
				//Van kint valami
				if (actual != null)
				{
					// background
					if (actual.GetComponent<GasDesplayElement>() == null)
					{
						//OK
					}
					// Item element
					else if (actual.GetComponent<GasDesplayElement>() != null)
					{
						//Destroy older
						Destroy(actual);
						actual = null;

						//Create Back
						actual = null;
						actual = Instantiate(TankElementBack);
						actual.transform.SetParent(drawingCanvas.transform);
						actual.transform.SetSiblingIndex(i);
					}
				}
				else
				{
					//Create Back
					actual = null;
					actual = Instantiate(TankElementBack);
					actual.transform.SetParent(drawingCanvas.transform);
					actual.transform.SetSiblingIndex(i);
				}
			}
			drawed[i] = actual;
		}
	}


	public void SetOtherInv(IGasTank OtherInventory)
	{

		if (OtherInventory != null)
		{
			other = OtherInventory.GetTankCluster();
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

	public bool SetInput(GasDesplayElement t)
	{
		if (InPuting != null && InPuting != t)
		{
			InPuting.SetInput(false);
		}
		if (t != null)
		{
			if (OutPuting != null)
			{
				//if (OutPuting.tank.gasType == t.tank.gasType || t.tank.gasType == GasType.Null)
				//{
				InPuting = t;
				return true;
				//}
				//else
				//{
				//return false;
				//}
			}
			else
			{
				InPuting = t;
				return true;
			}
		}
		else
		{
			InPuting = null;
			return true;
		}

	}

	public bool SetOutput(GasDesplayElement t)
	{
		if (OutPuting != null && OutPuting != t)
		{
			OutPuting.SetOutput(false);
		}
		if (t != null)
		{
			if (InPuting != null)
			{
				//if (InPuting.tank.gasType == t.tank.gasType || t.tank.gasType == GasType.Null)
				//{
				OutPuting = t;
				return true;
				//}
				//else
				//{
				//return false;
				//}
			}
			else
			{
				OutPuting = t;
				return true;
			}
		}
		else
		{
			OutPuting = null;
			return true;
		}
	}

}