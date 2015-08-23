using System;
using System.IO;
using UnityEngine;

//public class Map
//{
//	public int mapHeight;
//	public GeneratedTile[,] mapGenerated;
//	public Building[,] mapBuilt;

//	public int seed;

//	public Map(GeneratedTile[,] inmap, int inputseed)
//	{
//		this.mapHeight = (int)Math.Sqrt(inmap.Length);

//		this.mapGenerated = new GeneratedTile[mapHeight, mapHeight];

//		for (int i = 0; i < mapHeight; i++)
//		{
//			for (int j = 0; j < mapHeight; j++)
//			{
//				mapGenerated[i, j] = inmap[i, j];
//			}
//		}
//		mapBuilt = new Building[mapHeight, mapHeight];

//		seed = inputseed;
//	}

//	public Map(int inputseed, float h, float reduce, int maxOre, GameObject mapPiece)
//	{
//		Vector2 posMultiplyer = new Vector2((tileSize / 2), -(tileSize / 2));

//		this.mapHeight = (int)Math.Sqrt(h);
//		this.mapGenerated = new GeneratedTile[mapHeight, mapHeight];
//		seed = inputseed;

//		#region File
//		FileStream file = new FileStream("./file.txt", FileMode.Create);
//		StreamWriter wf = new StreamWriter(file);
//		#endregion

//		int gen = 50;
//		float[,] h2 = new float[,] { { 3f, 15f }, { 2f, 20f }, { 1f, 22f }, { 0.2f, 30f }, { 0.1f, 40f }, { 0.001f, 45 } };

//		System.Random rand = new System.Random(seed);

//		GeneratedTile[,] map = new GeneratedTile[50, 50];
//		GeneratedTile initial;



//		for (int i = 0; i < gen; i++)
//		{
//			for (int j = 0; j < gen; j++)
//			{
//				initial = new OreTile(rand, i, j, maxOre);

//				h = h2[(int)initial.type, 0];

//				reduce = h2[(int)initial.type, 1];

//				if (rand.Next(0, 100) <= h)
//				{
//					map[i, j] = initial;

//					map = ((OreTile)map[i, j]).Spread(map, h, rand, reduce, rand.Next(1, maxOre));
//				}
//			}
//			wf.WriteLine();
//		}

//		for (int xPos = 0; xPos < gen; xPos++)
//		{
//			for (int yPos = 0; yPos < gen; yPos++)
//			{
//				if (map[xPos, yPos] == null)
//				{
//					map[xPos, yPos] = new GeneratedTile(xPos, yPos);
//				}
//				if (map[xPos, yPos] != null)
//				{
//					wf.Write((int)map[xPos, yPos].type + ",");
//				}

//				Debug.Log(xPos + "," + yPos);

//				GameObject go = GameObject.Instantiate(mapPiece);
//				go.name = "Tile_" + xPos + "_" + yPos;
//				SpriteRenderer curr = go.GetComponent<SpriteRenderer>();

//				Debug.Log(xPos + "," + yPos);
//				curr.sprite = GeneratedSprites[((int)map.mapGenerated[xPos, yPos].type)];

//				curr.transform.parent = showLay.transform;

//				Vector2 pos = new Vector3(yPos, -xPos) * tileSize;
//				pos = pos + posMultiplyer;

//				curr.transform.localPosition = (pos);

//				Debug.Log("Tile Done");

//			}
//		}

//		wf.Close();


//	}



//	public Map()
//	{ }

//	public void GenerateBuildings()
//	{
//		int xMpos;
//		xMpos = ((int)Math.Floor((double)mapHeight / 2));

//		mapBuilt[xMpos, xMpos] = new MainBuilding(xMpos, xMpos);
//		mapBuilt[xMpos + 5, xMpos - 5] = new Chest(xMpos + 5, xMpos - 5);

//	}


//	public static void MapDraw(Map map, GameObject mapPiece, Sprite[] GeneratedSprites, GameObject[] BuildingPrefabs, float tileSize)
//	{

//		Vector2 posMultiplyer = new Vector2((tileSize / 2), -(tileSize / 2));
//		GameObject allTile = new GameObject("AllTitle");

//		Debug.Log("MapShowing started");

//		GameObject showLay = new GameObject("");
//		showLay.transform.position = new Vector3(0, 0, 0);
//		showLay.transform.parent = allTile.transform;


//		if (map.mapGenerated != null)
//			Debug.Log("OK");



//		Debug.Log(map.seed);
//		Debug.Log(map.mapHeight);

//		#region load generated
//		for (int xPos = 0; xPos < map.mapHeight; xPos++)
//		{

//			for (int yPos = 0; yPos < map.mapHeight; yPos++)
//			{

//				Debug.Log(xPos + "," + yPos);

//				GameObject go = GameObject.Instantiate(mapPiece);
//				go.name = "Tile_" + xPos + "_" + yPos;
//				SpriteRenderer curr = go.GetComponent<SpriteRenderer>();

//				Debug.Log(xPos + "," + yPos);
//				curr.sprite = GeneratedSprites[((int)map.mapGenerated[xPos, yPos].type)];

//				curr.transform.parent = showLay.transform;

//				Vector2 pos = new Vector3(yPos, -xPos) * tileSize;
//				pos = pos + posMultiplyer;

//				curr.transform.localPosition = (pos);

//				Debug.Log("Tile Done");
//			}
//		}
//		#endregion


//		#region Building load OUT DATED
//		/*
//        for (int xPos = 0; xPos < map.mapHeight; xPos++)
//        {

//            for (int yPos = 0; yPos < map.mapHeight; yPos++)
//            {
//                if (map.mapBuilt[xPos, yPos] != null)
//                {
//					Debug.Log(xPos + "," + yPos);

//					foreach (GameObject i in BuildingPrefabs)
//					{
//						Debug.Log(map.mapBuilt[xPos, yPos].GetType().ToString());
//						if (i.name == map.mapBuilt[xPos, yPos].GetType().ToString())
//						{
//							GameObject go = GameObject.Instantiate(i);

//							Vector3 pos = new Vector3(yPos + posMultiplyer.x, -xPos + posMultiplyer.y, -5) * tileSize;

//							go.transform.localPosition = (pos);

//							break;
//						}
//					}

                    

                    

//                    Debug.Log("Tile Done");
//                }
//            }
//        }
//		*/
//		#endregion



//	}
//}


