using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	
	public GameState gameS;

	//Gui
	public int CanTurnOf;
	IHasGui OpendGui;

	public Map map;
	public Player playerclass;

	//settings
	public int language;

	//UI
	public GUIHandler guiHandler;

	public AssetsLoader Registry;

	//Map
	public SavedMapData mapData;

	//Loading
	AsyncOperation loadingmap;

	//Saved
	public List<SavedMapData.DisplayDeteals> savedMaps = new List<SavedMapData.DisplayDeteals>();

	void Awake()
	{
		Registry = this.GetComponent<AssetsLoader>();
	}

	void Start()
	{
		Registry.CallRegister();

		loadingmap = new AsyncOperation();
		DontDestroyOnLoad(transform.gameObject);
		StartCoroutine(LoadLevel("Start"));

		gameS = GameState.MainManu;
	}


	public IEnumerator LoadLevel(string a)
	{

		loadingmap = SceneManager.LoadSceneAsync(a);

		while (!loadingmap.isDone)
		{
			yield return loadingmap;
		}

		loadingmap = null;
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

	public bool HasOpendGui()
	{
		if (OpendGui == null)
		{
			return false;
		}
		else
		{
			return true;
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
		if (OpendGui != null)
		{
			OpendGui.Close();
		}
		OpendGui = null;
		gameS = GameState.InGame;
		CanTurnOf = -1;
	}

	void OnLevelWasLoaded(int level)
	{
		if (SceneManager.GetActiveScene().name == "Main")
		{
			guiHandler = GameObject.Find("_GUIHandler").GetComponent<GUIHandler>();
			map = GameObject.Find("Map").GetComponent<Map>();
			playerclass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

			if (gameS == GameState.MainManu)
			{
				Debug.Log("Jeej!");

				map.LoadMap(mapData);

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

	public void LoadMaps()
	{
		string[] files = Directory.GetFiles("./saves", "*.ddc", SearchOption.AllDirectories);

		for (int i = 0; i < savedMaps.Count; i++)
		{
			savedMaps.RemoveAt(i);
		}

		foreach (string file in files)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
			SavedMapData.DisplayDeteals obj = (SavedMapData.DisplayDeteals)formatter.Deserialize(stream);
			savedMaps.Add(obj);
			stream.Close();
		}
	}

	public SavedMapData GetSavedMap(string path)
	{
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		SavedMapData obj = (SavedMapData)formatter.Deserialize(stream);
		stream.Close();

		return obj;
	}


	public void SaveMap()
	{
		mapData = map.Save();

		DirectoryInfo a = Directory.CreateDirectory("./saves/" + mapData.name);

		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream("./saves/" + mapData.name +"/" +mapData.name+".bin", FileMode.Create, FileAccess.Write, FileShare.None);
		formatter.Serialize(stream, mapData);
		stream.Close();

		//IFormatter formatter = new BinaryFormatter();
		stream = new FileStream("./saves/" + mapData.name + "/" + mapData.name + ".ddc", FileMode.Create, FileAccess.Write, FileShare.None);
		formatter.Serialize(stream, mapData.GetDeteails());
		stream.Close();

	}

	public void QuitGame()
	{
		SceneManager.LoadScene("Start");
		gameS = GameState.MainManu;
	}
}
