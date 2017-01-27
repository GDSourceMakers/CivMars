using UnityEngine;
using System.Collections;
using System;
using CivMarsEngine.GUI;

namespace CivMarsEngine
{

	public class PauseTab : MonoBehaviour, IGUI
	{

		bool on;
		GameController GameCon;
		public GameObject Content;

		// Use this for initialization
		void Start()
		{
			GameCon = GameController.instance;
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetButtonUp("Pause"))
			{
				TogelGui();
			}
		}

		private void TogelGui()
		{
			if (on)
			{
				GUIManagger.instance.OpenGUI(this);
			}
			else
			{
				GUIManagger.instance.CloseGUI(this);
			}
		}

		#region IGUI

		public void Open()
		{
			Content.SetActive(true);
			on = true;
		}

		public void Close()
		{
			Content.SetActive(false);
			on = false;
		}

		public int ClosingLevel()
		{
			return int.MaxValue;
		}

		#endregion

		public void SaveMap()
		{
			GameCon.SaveMap();
		}

		public void SaveNQuit()
		{
			GameCon.SaveMap();
			GameCon.QuitGame();
		}
	}
}