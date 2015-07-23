using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public Map map;


    public Sprite[] sprites;
    public GameObject mapPiece;

    public float tileSize;

    public Vector2 posMultiplyer;


    public float orePercent;
    public float oreReducer;


    private AsyncOperation async = null; // When assigned, load is in progress.

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


	
	public void LoadMap () {

        Application.LoadLevel("Main");

        sprites = Resources.LoadAll<Sprite>("Texturas");

        Tile[,] t = TerrainGen.Generate(orePercent, oreReducer, 1245);

        map = new Map(t);
        Debug.Log(t.Length == null);
        Debug.Log(map.mapArray == null);

        MapLoad.MapDraw(map, mapPiece, sprites, tileSize);

	}


    

    public IEnumerator LoadALevel(int a)
    {
        async = Application.LoadLevelAsync(a);
        yield return async;
    }



	// Update is called once per frame
	void Update () {
	
	}
}
