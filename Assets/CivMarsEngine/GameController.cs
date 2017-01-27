using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

using CivMarsEngine.Registry;
using CivMarsEngine.GUI;

namespace CivMarsEngine
{
    public class GameController : MonoBehaviour
    {

        public static GameController instance;

        public GameState gameS;

        public AssetsLoader Registry;


        //Gui
        public GUIManagger guiHandler;

        public MapManagger map;
        public Player playerclass;

        //settings
        public int language;

        //Map
        public SavedMapData mapData;

        //Loading
        AsyncOperation loadingMap;

        //Saved
        public List<SavedMapData.DisplayDeteals> savedMaps = new List<SavedMapData.DisplayDeteals>();

        void Awake()
        {
            instance = this;
            Registry = this.GetComponent<AssetsLoader>();
            //SceneManager.sceneLoaded += LevelLoaded;
        }

        void Start()
        {
            Registry.CallRegister();

            loadingMap = new AsyncOperation();
            //DontDestroyOnLoad(transform.gameObject);
            StartCoroutine(LoadLevel("MainMenu"));

            gameS = GameState.MainManu;
        }

        IEnumerator LoadLevel(string a)
        {
            loadingMap = SceneManager.LoadSceneAsync(a, LoadSceneMode.Additive);

            while (!loadingMap.isDone)
            {
                yield return loadingMap;
            }

            loadingMap = null;
        }

        #region Map loading

        public MapLoadingProgress load;

        public void StartGame()
        {
            SceneManager.UnloadSceneAsync("MainMenu");
            //Debug.Log("Load");
            StartCoroutine(LoadGameMap());
        }

        IEnumerator LoadGameMap()
        {
            load = new MapLoadingProgress();

            loadingMap = SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);

            while (!loadingMap.isDone)
            {
                load.progress = loadingMap.progress * 50;
                yield return load;
            }
            loadingMap = null;

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));

            map = MapManagger.instance;
            guiHandler = GUIManagger.instance;
            playerclass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            yield return StartCoroutine(map.LoadMap(mapData, load));

            gameS = GameState.InGame;

            Camera.main.GetComponent<CameraChase>().MapLoaded();

            load.isDone = true;
        }

        public class MapLoadingProgress
        {
            public float progress;
            public bool isDone;
        }

        #endregion

        public void Update()
        {
            if (gameS == GameState.Gui)
            {
                playerclass.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else if (gameS != GameState.MainManu)
            {
                playerclass.GetComponent<Rigidbody2D>().isKinematic = false;
            }
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

            //DirectoryInfo a = Directory.CreateDirectory("./saves/" + mapData.name);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("./saves/" + mapData.name + "/" + mapData.name + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
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
}
