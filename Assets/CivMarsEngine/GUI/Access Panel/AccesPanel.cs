using UnityEngine;
using System.Collections;
using System;
using CivMarsEngine.GUI;

namespace CivMarsEngine
{
	public class AccesPanel : MonoBehaviour, IGUI
	{
		public GameController GameCon;

		//public Building OpenBuilding;

		public bool on;

		public GameObject[] AccesTabs;

		public GameObject Graphicks;

		public void Start()
		{
			GameCon = GameController.instance;
		}

		void Update()
		{
			if (Input.GetButtonUp("Inventory"))
			{
				TogelGui();
			}
		}

		#region IHasGUI

		public void TogelGui()
		{
			/*
			if (!on)
			{
				if (GameCon.guiHandler.HasOpendGui())
				{
					GameCon.guiHandler.CloseGUI(null);
				}
				else
				{
					if (GameCon.guiHandler.AlloweGUI(this))
					{
						Open();
					}
				}
			}
			else
			{
				GameCon.guiHandler.CloseGUI(this);
				Close();
			}
			*/
		}

		public void Open()
		{
			Graphicks.SetActive(true);
			on = true;
		}

		public void Close()
		{
			Graphicks.SetActive(false);
			on = false;
		}

		public int ClosingLevel()
		{
			return int.MaxValue;
		}

#endregion


	}
}