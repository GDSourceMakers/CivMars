using UnityEngine;
using System.Collections;
using System.IO;
using CivMarsEngine;
using BasicUtility.TileMap;
using CivMarsEngine.Registry;

namespace CivMarsEngine
{
    public class MapManagger : MonoBehaviour
    {
        public static MapManagger instance;

        public int seed;
        public int mapHeight = 100;

        //public Vector3 posMultiplyer;


        public GameObject back;
        public string backLayerName;
        public string generatedLayerName;
		public string buildingLayerName;

		public TileMap TileMap;
        Layer backLayer;
        Layer generatedLayer;
		Layer buildingLayer;

        public SavedMapData mapData;

        // Use this for initialization
        void Awake()
        {
            instance = this;
            backLayer = TileMap.layers[0];
            generatedLayer = TileMap.layers[1];
			buildingLayer = TileMap.layers[2];
        }



        public IEnumerator BuildMap()
        {

            

            yield return 100;
            /*
            SavedMap a = new SavedMap(this);
            a.Save("./Map.bin");

            SavedMap b = new SavedMap("./Map.bin", this);
            b.LoadFromSave();
            */

        }

        public void AddBasicBuildings()
        {
            //int xMpos;
            //xMpos = mapHeight / 2;

            //TileTransform mainBuilding = Instantiate(GameRegystry.tiels[CivMars.MainBuilding.ID].gameObject).GetComponent<TileTransform>();
            //Buildings.SetTile(xMpos, xMpos, mainBuilding);

            //TileTransform chest = Instantiate(GameRegystry.tiels[CivMars.Chest.ID].gameObject).GetComponent<TileTransform>();
            //Buildings.SetTile(xMpos+5, xMpos+5, chest);

        }

        public SavedMapData Save()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    TileTransform tile = TileMap.GetTile(new TilePosition(ga i, j,generatedLayer);
                    if (tile != null)
                    {
                        Tiled t = tile.GetComponent<Tiled>();

                        if (t is ISaveble)
                        {
                            mapData.GeaneratedTiles[i, j] = ((ISaveble)t).Save();
                        }
                    }


                    tile = TileMap.GetTileOn(i, j,buildingLayer);
                    if (tile != null)
                    {
                        Tiled t = tile.GetComponent<Tiled>();

                        if (t is ISaveble)
                        {
                            mapData.BuildingTiles[i, j] = ((ISaveble)t).Save();
                        }
                    }
                }
            }

            return mapData;
        }

        /*
        public void LoadMap(SavedMapData savedMap)
        {
            mapData = savedMap;

            TileMap.map_x = mapHeight;
            TileMap.map_y = mapHeight;

            if (mapData.generated)
            {
                for (int i = 0; i < mapData.height; i++)
                {
                    for (int j = 0; j < mapData.height; j++)
                    {
                        SavedTile tile = mapData.GeaneratedTiles[i, j];
                        if (tile != null)
                        {
                            if (tile is SavedOre)
                            {
                                TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.worldGen[tile.ID]).GetPrefab()).GetComponent<TileTransform>();
								
								TileMap.SetTile(i, j, trans, generatedLayer);
							}
                        }

                        tile = mapData.BuildingTiles[i, j];
                        if (tile != null)
                        {
                            TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.tiels[tile.ID]).GetPrefab()).GetComponent<TileTransform>();
                            
                            TileMap.SetTile(i, j, trans,buildingLayer);
                        }
                    }
                }
            }
            else
            {
                BuildMap();
                AddBasicBuildings();
                mapData.SetSize(mapHeight);
                mapData.generated = true;
                
            }
        }
        */

        public IEnumerator LoadMap(SavedMapData savedMap, GameController.MapLoadingProgress progress)
        {
            mapData = savedMap;

            TileMap.map_x = mapHeight;
            TileMap.map_y = mapHeight;

            if (mapData.generated)
            {
                for (int i = 0; i < mapData.height; i++)
                {
                    for (int j = 0; j < mapData.height; j++)
                    {
                        SavedTile tile = mapData.GeaneratedTiles[i, j];
                        if (tile != null)
                        {
                            if (tile is SavedOre)
                            {
                                TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.worldGen[tile.ID]).GetPrefab()).GetComponent<TileTransform>();

                                TileMap.SetTile(i, j, trans, generatedLayer);
                            }
                        }

                        tile = mapData.BuildingTiles[i, j];
                        if (tile != null)
                        {
                            TileTransform trans = GameObject.Instantiate(((ISaveble)GameRegystry.tiels[tile.ID]).GetPrefab()).GetComponent<TileTransform>();

                            TileMap.SetTile(i, j, trans, buildingLayer);
                        }

                        
                    }
                    progress.progress = 50 + i * mapData.height * 50;
                    yield return null;
                }
            }
            else
            {
                //TODO: Make selectablr map size
                mapData.height = mapHeight;

                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapHeight; j++)
                    {
                        TileTransform t = Instantiate(back).GetComponent<TileTransform>();
                        TileMap.SetTile(i, j, t, backLayer);


                    }

                    progress.progress = 50 + (float)i / mapData.height * 50;
                    yield return null;
                }

                //987, 
                System.Random r = new System.Random(mapData.seed);

                for (int i = 0; i < GameRegystry.worldGen.Values.Count; i++)
                {
                    GameRegystry.worldGen.Values.GetEnumerator().MoveNext();
                    GameRegystry.worldGen.Values.GetEnumerator().Current.Generate(r, TileMap);

                    yield return i / GameRegystry.worldGen.Values.Count;
                }

                AddBasicBuildings();
                mapData.SetSize(mapHeight);
                mapData.generated = true;

            }

        }
    }
}