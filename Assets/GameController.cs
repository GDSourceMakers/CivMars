using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Map map;

    public Sprite[] sprites;
    public GameObject mapPiece;
    public float tileSize;
    public Vector2 posMultiplyer;


    public float orePercent;
    public float oreReducer;

    public GameObject load;
    public GameObject menu;
    public Text bar;
    public float loadProgress;


    public bool MapLoaded = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    public void Update()
    {
        if (Application.loadedLevelName == "Main" && !MapLoaded)
        {

            Debug.Log("Jeej!");

            sprites = Resources.LoadAll<Sprite>("Texturas");

            Tile[,] t = TerrainGen.Generate(orePercent, oreReducer, 1245);

            map = new Map(t);
            Debug.Log(t.Length == null);
            Debug.Log(map.mapArray == null);

            MapLoad.MapDraw(map, mapPiece, sprites, tileSize);

            MapLoaded = true;
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

        bar.text = loadProgress + "??";


        AsyncOperation async = Application.LoadLevelAsync(a);



        //while (!async.isDone)
        //{
            loadProgress = async.progress * 100;
            bar.text = loadProgress + "!!";

            yield return async;
        //}



    }


}
