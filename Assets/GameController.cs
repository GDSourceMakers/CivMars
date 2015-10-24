using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{

	public GameState gameS;
	public bool CanTurnOf;
	public Map map;
	public Player playerclass;

	//map Load

	public GameObject mapPiece;
	public float tileSize;
	public Vector2 posMultiplyer;

	//settings
	public int language;

	//Ore gen
	public float orePercent;
	public float oreReducer;

	//UI
	public GUIHandler guiHandler;

	public AssetsLoader buildingRegistry;

	public bool gameIsOn = false;

	IHasGui OpendGui;



	void Awake()
	{
		buildingRegistry = this.GetComponent<AssetsLoader>();
	}


	void Start()
	{
		DontDestroyOnLoad(transform.gameObject);
		buildingRegistry.CallRegister();
	}

	public void Update()
	{
		if (gameS == GameState.Gui)
		{
			playerclass.GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}

	public bool AlloweGUI(IHasGui hasGui)
	{
		if (CanTurnOf)
		{
			if (OpendGui != null)
			{
				OpendGui.Close();
			}
			OpendGui = hasGui;

			CanTurnOf = hasGui.CanBeTurnedOf();

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

				Sprite[] GeneratedSprites = Resources.LoadAll<Sprite>("Texturas/Generated");
				GameObject[] BuildingPrefabs = Resources.LoadAll<GameObject>("Prefabs/Buildings");

				int seed = 666421;

				//GeneratedTile[,] t = TerrainGen.Generate(orePercent, oreReducer, seed, 2);

				map.BuildMap();
				map.AddBasicBuildings();

				//MapLoad.MapDraw(map, mapPiece, GeneratedSprites, BuildingPrefabs, tileSize);

				gameIsOn = true;

				Camera.main.GetComponent<CameraChase>().MapLoaded();
			}

		}

	}

	public void TogleAccesPanel()
	{
		TogleAccesPanel(null);
		return;
	}

	public void TogleAccesPanel(Building other)
	{
		guiHandler.AccesPanel.TogelGui();
	}

	public void ChangeLanguage(int num)
	{
		language = num;
	}

}
