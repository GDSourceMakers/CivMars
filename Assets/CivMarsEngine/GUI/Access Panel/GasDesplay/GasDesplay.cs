using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CivMarsEngine
{
	public class GasDesplay : MonoBehaviour
	{

		public GameObject GasCanvasPlayer;
		public GameObject GasCanvasOther;

		public GameObject TankElement;

		public List<GasDesplayElement> drawedInvPlayer_Inv = new List<GasDesplayElement>();
		public List<GasDesplayElement> drawedInvPlayer_Suit = new List<GasDesplayElement>();

		public List<GasDesplayElement> drawedInvOther = new List<GasDesplayElement>();

		IGasTank player_t;
		IGasTank other_t;

		public GasDesplayElement OutPuting;
		public GasDesplayElement InPuting;

		void Start()
		{
			player_t = GameController.instance.playerclass.GetSuit();
		}

		void Update()
		{
			UpdateDesplay();
			if ((OutPuting != null && InPuting != null))
			{
				//OutPuting.tank.Transfer(InPuting.tank, 5f * Time.deltaTime);
			}
		}

		public void UpdateDesplay()
		{
			if (other_t == null)
			{
				UpdateDesplayPlayer(player_t);
			}
			else
			{
				UpdateDesplayOther(other_t);
				UpdateDesplayPlayer(player_t);
			}
		}

		void UpdateDesplayOther(IGasTank TankThis)
		{
			for (int i = 0; i < drawedInvOther.Count; i++)
			{
				GasDesplayElement actual = drawedInvOther[i];

				if (i <= TankThis.GetTankCount())
				{
					actual.Set(TankThis, true);
				}
				else
				{
					actual.Set(null, false);
				}
			}
			for (int i = 0; i < TankThis.GetTankCount() - drawedInvOther.Count; i++)
			{
				GasDesplayElement actual;
				actual = Instantiate(TankElement).GetComponent<GasDesplayElement>();
				actual.transform.SetParent(GasCanvasOther.transform);
				actual.transform.SetSiblingIndex(i);

				actual.SetUp(drawedInvOther.Count + i, this);

				actual.Set(TankThis, true);

				drawedInvOther.Add(actual);
			}
		}

		void UpdateDesplayPlayer(IGasTank TankThis)
		{
			#region Player
			for (int i = 0; i < drawedInvPlayer_Suit.Count; i++)
			{
				GasDesplayElement actual = drawedInvPlayer_Suit[i];

				if (i <= TankThis.GetTankCount())
				{
					actual.GetComponent<GasDesplayElement>().Set(TankThis, true);
				}
				else
				{
					actual.GetComponent<GasDesplayElement>().Set(null, false);
				}
			}
			for (int i = 0; i < TankThis.GetTankCount() - drawedInvPlayer_Suit.Count ; i++)
			{
				GasDesplayElement actual;
				actual = Instantiate(TankElement).GetComponent<GasDesplayElement>();
				actual.transform.SetParent(GasCanvasPlayer.transform);
				actual.transform.SetSiblingIndex(i);

				actual.SetUp(drawedInvPlayer_Suit.Count + i, this);

				actual.Set(TankThis, true);

				drawedInvPlayer_Suit.Add(actual);
			}
			#endregion

			/*
			#region Inv
			for (int i = 0; i < drawedInvPlayer_Inv.Count; i++)
			{
				GasDesplayElement actual = drawedInvPlayer_Inv[i];

				if (i <= TankThis.GetTankCount())
				{
					actual.Set(TankThis, true);
				}
				else
				{
					actual.Set(null, false);
				}
			}
			for (int i = 0; i < TankThis.GetTankCount() - drawedInvPlayer_Inv.Count; i++)
			{
				GasDesplayElement actual;
				actual = Instantiate(TankElement).GetComponent<GasDesplayElement>();
				actual.transform.SetParent(GasCanvasPlayer.transform.FindChild("Inv").transform);
				actual.transform.SetSiblingIndex(i);

				actual.SetUp(drawedInvPlayer_Inv.Count + i, this);

				actual.Set(TankThis, true);

				drawedInvPlayer_Inv.Add(actual);
			}
			#endregion
			*/

		}


		public void SetOtherInv(IGasTank OtherInventory)
		{
			other_t = OtherInventory;
		}

		public void SetInput(GasDesplayElement t)
		{
			if (InPuting != null)
			{
				InPuting.TurnInput(false);
			}
			InPuting = t;

		}

		public void SetOutput(GasDesplayElement t)
		{
			if (InPuting != null)
			{
				InPuting.TurnOutput(false);
			}
			InPuting = t;
		}

	}
}