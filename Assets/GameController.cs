using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
	//Gui
	public GameState gameS;
	public int CanTurnOf;
	IHasGui OpendGui;
	public InventoryDesplay defaultInv;

	public Map map;
	public Player playerclass;

	//settings
	public int language;

	//UI
	public GUIHandler guiHandler;

	public AssetsLoader buildingRegistry;

	public bool gameIsOn = false;

	



	void Awake()
	{
		buildingRegistry = this.GetComponent<AssetsLoader>();
	}

	void Start()
	{
		DontDestroyOnLoad(transform.gameObject);
		buildingRegistry.CallRegister();
		gameS = GameState.MainManu;
	}

	public void Update()
	{
		if (gameS == GameState.Gui)
		{
			playerclass.GetComponent<Rigidbody2D>().isKinematic = true;
		}
		else if(gameS != GameState.MainManu)
		{
			playerclass.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

	public bool AlloweGUI(IHasGui hasGui)
	{
		if (OpendGui != null)
		{
			CanTurnOf = OpendGui.ClosingLevel();
		}
		if (CanTurnOf <= hasGui.ClosingLevel())
		{
			if (OpendGui != null)
			{
				OpendGui.Close();
			}
			OpendGui = hasGui;

			CanTurnOf = hasGui.ClosingLevel();

			gameS = GameState.Gui;
			return true;
		}
		else
		{
			return false;
		}
	}

	public void CloseGUI(IHasGui hasGui)
	{
		OpendGui = null;
		gameS = GameState.InGame;
		CanTurnOf = -1;
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 1)
		{
			guiHandler = GameObject.Find("_GUIHandler").GetComponent<GUIHandler>();
			map = GameObject.Find("Map").GetComponent<Map>();
			playerclass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

			if (Application.loadedLevelName == "Main" && !gameIsOn)
			{

				Debug.Log("Jeej!");

				map.BuildMap();
				map.AddBasicBuildings();

				gameIsOn = true;
				gameS = GameState.InGame;

				Camera.main.GetComponent<CameraChase>().MapLoaded();
			}

		}

	}

	public void TogleAccesPanel()
	{
		guiHandler.AccesPanel.TogelGui();
	}

	public void ChangeLanguage(int num)
	{
		language = num;
	}

}
