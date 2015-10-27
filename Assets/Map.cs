using UnityEngine;
using System.Collections;
using System.IO;

public class Map : MonoBehaviour
{
	public int seed;
	public int mapHeight = 100;



	public GeneratedTile[,] mapGenerated = new GeneratedTile[100, 100];
	public Tiled[,] mapBuilt = new Tiled[100, 100];

	float[,] OreRarety = new float[,] { { 3f, 15f, 2f }, { 2f, 20f, 2f }, { 1f, 22f, 2f }, { 0.2f, 30f, 2f }, { 0.1f, 40f, 2f }, { 0.01f, 45, 2f } };
	//float[,] OreRarety = new float[,] { { 3f, 15f, 2f }, { 2f, 20f, 2f }, { 1f, 22f, 2f }, { 0.2f, 30f, 2f }, { 0.1f, 40f, 2f }, { 1f, 45, 2f } };
	public float maximumAmountInOre = 2;
	public float reduce = 25;


	GeneratedTile initial;
	public Vector3 posMultiplyer;
	public float tileSize;

	public GameObject[] GeneratedPrefabs;
	public GameObject[] BuildingPrefabs;

	// Use this for initialization
	void Start()
	{
		//mapGenerated = new GeneratedTile[mapHeight, mapHeight];

		//mapBuilt = new Building[mapHeight, mapHeight];
	}



	public void BuildMap()
	{
		float chance;

		#region File
		FileStream file = new FileStream("./file.txt", FileMode.Create);
		StreamWriter wf = new StreamWriter(file);
		#endregion

		System.Random rand = new System.Random(seed);

		//Debug.Log("Random random test: " +rand.NextDouble());

		//bool t = true;

		for (int xPos = 0; xPos < mapHeight; xPos++)
		{
			for (int yPos = 0; yPos < mapHeight; yPos++)
			{
				initial = new OreTile(rand, xPos, yPos, maximumAmountInOre);

				chance = OreRarety[(int)initial.type, 0];

				reduce = OreRarety[(int)initial.type, 1];



				if (rand.NextDouble() <= chance/100)
				{
					//Debug.Log(xPos + "," + yPos);

					mapGenerated[xPos, yPos] = initial;


					mapGenerated = ((OreTile)mapGenerated[xPos, yPos]).Spread(mapGenerated, chance, rand, reduce);


				}
				if (mapGenerated[xPos, yPos] == null)
				{
					mapGenerated[xPos, yPos] = new GeneratedTile(xPos, yPos);
				}
				wf.Write((int)mapGenerated[xPos, yPos].type + ",");





				initial = null;
			}
			wf.WriteLine();
		}
		wf.Close();

		for (int xPos = 0; xPos < mapHeight; xPos++)
		{
			for (int yPos = 0; yPos < mapHeight; yPos++)
			{

				GameObject go = GameObject.Instantiate(GeneratedPrefabs[((int)mapGenerated[xPos, yPos].type)]);
				go.name = "Tile" + "_" + xPos + "_" + yPos;
				SpriteRenderer curr = go.GetComponent<SpriteRenderer>();

				//Debug.Log(xPos + "," + yPos);

				curr.transform.parent = this.transform;

				Vector3 pos = new Vector3(xPos, -yPos) * tileSize;
				pos = pos + posMultiplyer;

				curr.transform.localPosition = (pos);

				//Debug.Log("Tile Done");

			}
		}

		Debug.Log("asd");
	}

	public void AddBasicBuildings()
	{
		int xMpos;
		xMpos = ((int)Mathf.Floor((float)mapHeight / 2));

		Debug.Log(MainBuilding.ID);
		mapBuilt[xMpos, xMpos] = Instantiate(BuildingPrefabs[MainBuilding.ID]).GetComponent<MainBuilding>();
		mapBuilt[xMpos, xMpos].transform.position = new Vector3(xMpos, -xMpos, -2) + posMultiplyer;
        mapBuilt[xMpos + 5, xMpos - 5] = Instantiate(BuildingPrefabs[Chest.ID]).GetComponent<Chest>();
		mapBuilt[xMpos + 5, xMpos - 5].transform.position = new Vector3(xMpos + 5, -(xMpos - 5),-2) +posMultiplyer;
	}

	

	// Update is called once per frame
	void Update()
	{

	}

	public void MapUpdate(int x, int y, Map map)
	{
		Sprite[] sprites = Resources.LoadAll<Sprite>("Texturas/Generated");

		GameObject go = GameObject.Find("Tile_" + x + "_" + y);
		SpriteRenderer curr = go.GetComponent<SpriteRenderer>();

		curr.sprite = sprites[((int)map.mapGenerated[x, y].type)];

	}
}
