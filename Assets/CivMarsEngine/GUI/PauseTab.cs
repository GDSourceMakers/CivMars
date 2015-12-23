using UnityEngine;
using System.Collections;
using System;
using CivMarsEngine;

public class PauseTab : MonoBehaviour, IHasGui
{

	bool on;
	GameController GameCon;
	public GameObject Content;

	// Use this for initialization
	void Start () {
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Pause"))
		{
			TogelGui();
		}
	}

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
