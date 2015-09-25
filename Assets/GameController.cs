using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public GameState gameS;
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
	//Base GUI
	public GameObject load;
	public GameObject menu;
	public Text bar;
	public float loadProgress;

	AsyncOperation loadingmap;

	public BuildingRegistry buildingRegistry;

	public bool gameIsOn = false;

	void Awake()
	{
		buildingRegistry = this.GetComponent<BuildingRegistry>();
	}

	void Start()
	{
		DontDestroyOnLoad(transform.gameObject);
		buildingRegistry.CallRegister();
		
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

	public void Update()
	{
		if (Application.loadedLevelName == "Start")
		{
			if(load.active == true)
			{
				loadProgress = loadingmap.progress * 100;
				bar.text = loadProgress + "!!";
			}
		}
	}

	public void StartGame()
	{

		StartCoroutine(LoadLevel("Main"));

	}

	public IEnumerator LoadLevel(string a)
	{
		load.SetActive(true);
		menu.SetActive(false);

		//bar.text = loadProgress + "??";


		loadingmap = Application.LoadLevelAsync(a);



		while (!loadingmap.isDone)
		{
			yield return loadingmap;
		}



	}

	public void TogleDesplay()
	{
		TogleDesplay(null);
		return;
	}

	public void TogleDesplay(Building other)
	{
		if (!guiHandler.desplayOn)
		{
			Debug.Log("Opening");
			guiHandler.AccesPanel.ChangeTab(AccesPanelState.Inventory, other);
			guiHandler.AccesPanel.gameObject.SetActive(true);
			

			playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			guiHandler.desplayOn = true;
			gameS = GameState.Desplay;

			return;
		}
		else
		{
			Debug.Log("Closing");
			guiHandler.AccesPanel.ChangeTab(AccesPanelState.Inventory, null);
			guiHandler.AccesPanel.gameObject.SetActive(false);

			playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			guiHandler.desplayOn = false;
			gameS = GameState.InGame;

			return;
		}
	}

	public void ChangeLanguage(int num)
	{
		language = num;
	}

}
