using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Map map;
    public Player playerclass;

    //map Load
    public Sprite[] sprites;
    public GameObject mapPiece;
    public float tileSize;
    public Vector2 posMultiplyer;

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


    public bool gameIsOn = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            guiHandler = GameObject.Find("_GUIHandler").GetComponent<GUIHandler>();
            playerclass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

    }

    public void Update()
    {
        if (Application.loadedLevelName == "Main" && !gameIsOn)
        {

            Debug.Log("Jeej!");

            sprites = Resources.LoadAll<Sprite>("Texturas");

            Tile[,] t = TerrainGen.Generate(orePercent, oreReducer, 666421, 2);

            

            map = new Map(t);
            Debug.Log(t.Length == null);
            Debug.Log(map.mapArray == null);

            MapLoad.MapDraw(map, mapPiece, sprites, tileSize);

            gameIsOn = true;

            Camera.main.GetComponent<CameraChase>().MapLoaded();
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

    public void TogleInventory()
    {
        if (!(guiHandler.inventoryOn))
        {
            Debug.Log("Opening");
            guiHandler.actionGroup.SetActive(false);
            guiHandler.InventoryDisplay.gameObject.SetActive(true);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            guiHandler.inventoryOn = true;
            return;
        }
        else
        {
            Debug.Log("Closing");
            guiHandler.actionGroup.SetActive(true);
            guiHandler.InventoryDisplay.gameObject.SetActive(false);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            guiHandler.inventoryOn = false;
            return;
        }
    }

}
