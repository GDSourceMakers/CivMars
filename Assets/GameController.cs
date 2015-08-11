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

           if (Application.loadedLevelName == "Main" && !gameIsOn)
           {

               Debug.Log("Jeej!");

               Sprite[] GeneratedSprites = Resources.LoadAll<Sprite>("Texturas/Generated");
               GameObject[] BuildingPrefabs = Resources.LoadAll<GameObject>("Prefabs/Buildings");

               GeneratedTile[,] t = TerrainGen.Generate(orePercent, oreReducer, 666421, 2);



               map = new Map(t);
               Debug.Log(t.Length == null);
               Debug.Log(map.mapGenerated == null);

               MapLoad.MapDraw(map, mapPiece, GeneratedSprites, BuildingPrefabs, tileSize);

               gameIsOn = true;

               Camera.main.GetComponent<CameraChase>().MapLoaded();
           }

        }

    }

    public void Update()
    {

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

    public void TogleSingleInventory()
    {
        if ((guiHandler.dualinventoryOn))
        {
            Debug.Log("Closing");
            guiHandler.actionGroup.SetActive(true);
            guiHandler.DualInventory.SetOtherInv(null);
            guiHandler.DualInventory.gameObject.SetActive(false);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            guiHandler.dualinventoryOn = false;
            gameS = GameState.InGame;
            return;
        }
        else if (!(guiHandler.inventoryOn))
        {
            Debug.Log("Opening");
            guiHandler.actionGroup.SetActive(false);
            guiHandler.InventoryDisplay.gameObject.SetActive(true);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            guiHandler.inventoryOn = true;
            gameS = GameState.Inventory;
            return;
        }
        else
        {
            Debug.Log("Closing");
            guiHandler.actionGroup.SetActive(true);
            guiHandler.InventoryDisplay.gameObject.SetActive(false);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            guiHandler.inventoryOn = false;
            gameS = GameState.InGame;

            return;
        }
    }


    public void TogleDualInventory(Inventory other)
    {
        if ((guiHandler.inventoryOn))
        {
            Debug.Log("Closing");
            guiHandler.actionGroup.SetActive(true);
            guiHandler.InventoryDisplay.gameObject.SetActive(false);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            guiHandler.inventoryOn = false;
            gameS = GameState.InGame;

            return;
        }
        else if (!(guiHandler.dualinventoryOn))
        {
            //Debug.Log("Opening");
            guiHandler.actionGroup.SetActive(false);
            guiHandler.DualInventory.SetOtherInv(other);
            guiHandler.DualInventory.gameObject.SetActive(true);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            guiHandler.dualinventoryOn = true;
            gameS = GameState.DualInventory;
            return;
        }
        else
        {
            Debug.Log("Closing");
            guiHandler.actionGroup.SetActive(true);
            guiHandler.DualInventory.SetOtherInv(null);
            guiHandler.DualInventory.gameObject.SetActive(false);
            playerclass.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            guiHandler.dualinventoryOn = false;
            gameS = GameState.InGame;
            return;
        }
    }


    public void ChangeLanguage(int num)
    {
        language = num;
    }
}
