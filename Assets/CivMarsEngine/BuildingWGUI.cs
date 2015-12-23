using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CivMarsEngine
{
	public class BuildingWGUI : Building, IHasGui
	{

		public GameObject SideMenu;

		public void PositionUpdate()
		{
			SideMenu.SetActive(false);
			this.SideMenu.transform.position = Vector3.zero;
		}

		#region IhasGui
		public void TogelGui()
		{
			if (!guion)
			{
				if (GameCon.AlloweGUI(this))
				{
					Open();
				}
			}
			else
			{
				GameCon.CloseGUI(this);
				Close();
			}
		}

		public virtual void Open()
		{
			guion = true;
			SideMenu.SetActive(true);
		}

		public virtual void Close()
		{
			guion = false;
			SideMenu.SetActive(false);
		}

		public int ClosingLevel()
		{
			return 1;
		}

		/*
		public void OnPointerClick(PointerEventData eventData)
		{
			TogelGui();
		}
		*/
		#endregion

	}
}
