using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;
using UnityEngine.EventSystems;

namespace CivMarsEngine
{
	public class BuildingWGUI : Building, IHasGui
	{

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
			Graphicks.SetActive(true);
		}

		public virtual void Close()
		{
			guion = false;
			Graphicks.SetActive(false);
		}

		public int ClosingLevel()
		{
			return 1;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!eventData.rawPointerPress.transform.IsChildOf(Graphicks.transform))
				TogelGui();
		}
		#endregion

	}
}
