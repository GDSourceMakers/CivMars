using UnityEngine;
using System.Collections;
using System;

namespace CivMarsEngine
{
	public class AccesPanel : MonoBehaviour, IHasGui
	{
		public GameController GameCon;

		public Building OpenBuilding;

		public bool on;

		public GameObject[] AccesTabs;

		public GameObject Graphicks;

		public void Start()
		{
			GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
			if (!on)
			{
				if (GameCon.HasOpendGui())
				{
					GameCon.CloseGUI(null);
				}
				else
				{
					if (GameCon.AlloweGUI(this))
					{
						Open();
					}
				}
			}
			else
			{
				GameCon.CloseGUI(this);
				Close();
			}
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