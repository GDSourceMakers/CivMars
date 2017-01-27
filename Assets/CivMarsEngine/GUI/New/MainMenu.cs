using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine.GUI
{
	class MainMenu:MonoBehaviour
	{
		GameController GameCon;

		private void Awake()
		{
			GameCon = GameController.instance;
		}

		public void NewGame()
		{
			if (GameCon == null)
			{
				Debug.Log("In test mode (missing Game Controller)");
			}
			else
			{
				
			}
		}
	}
}
