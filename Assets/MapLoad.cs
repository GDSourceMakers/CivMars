using UnityEngine;
using System.Collections;

public class MapLoad
{



    public static void MapDraw(Map map, GameObject mapPiece, Sprite[] GeneratedSprites, GameObject[] BuildingSprites, float tileSize)
    {

        Vector2 posMultiplyer = new Vector2((tileSize / 2), -(tileSize / 2));
        GameObject allTile = new GameObject("AllTitle");

        Debug.Log("MapShowing started");



        GameObject showLay = new GameObject("");
        showLay.transform.position = new Vector3(0, 0, 0);
        showLay.transform.parent = allTile.transform;





        if (map.mapGenerated != null)
            Debug.Log("OK");



        Debug.Log(map.seed);
        Debug.Log(map.mapHeight);

        #region load generated
        for (int xPos = 0; xPos < map.mapHeight; xPos++)
        {

            for (int yPos = 0; yPos < map.mapHeight; yPos++)
            {

                //Debug.Log(xPos + "," + yPos);

                GameObject go = GameObject.Instantiate(mapPiece);
                go.name = "Tile_" + xPos + "_" + yPos;
                SpriteRenderer curr = go.GetComponent<SpriteRenderer>();

                //Debug.Log(xPos + "," + yPos);
                curr.sprite = GeneratedSprites[((int)map.mapGenerated[xPos, yPos].type)];

                curr.transform.parent = showLay.transform;

                Vector2 pos = new Vector3(yPos, -xPos) * tileSize;
                pos = pos + posMultiplyer;

                curr.transform.localPosition = (pos);

                //Debug.Log("Tile Done");
            }
        }
        #endregion


        #region Building load
        for (int xPos = 0; xPos < map.mapHeight; xPos++)
        {

            for (int yPos = 0; yPos < map.mapHeight; yPos++)
            {
                if (map.mapBuilt[xPos, yPos] != null)
                {
                    //Debug.Log(xPos + "," + yPos);

                    GameObject go = GameObject.Instantiate(BuildingSprites[((int)map.mapBuilt[xPos, yPos].Textura)]);

                    go.GetComponent<BuildingBehaviour>().properties = map.mapBuilt[xPos, yPos];

                    Vector3 pos = new Vector3(yPos + posMultiplyer.x, -xPos + posMultiplyer.y, -5) * tileSize;

                    go.transform.localPosition = (pos);

                    

                    //Debug.Log("Tile Done");
                }
            }
        }
        #endregion



    }


    public static void MapUpdate(int x, int y, Map map)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Texturas/Generated");

        GameObject go = GameObject.Find("Tile_" + x + "_" + y);
        SpriteRenderer curr = go.GetComponent<SpriteRenderer>();

        curr.sprite = sprites[((int)map.mapGenerated[x, y].type)];

    }
}
