using UnityEngine;
using System.Collections;

public class MapLoad
{



    public static void MapDraw(Map map, GameObject mapPiece, Sprite[] sprites, float tileSize)
    {

        Vector2 posMultiplyer = new Vector2((tileSize / 2), -(tileSize / 2));
        GameObject allTile = new GameObject("AllTitle");

        Debug.Log("MapShowing started");



        GameObject showLay = new GameObject("");
        showLay.transform.position = new Vector3(0, 0, 0);
        showLay.transform.parent = allTile.transform;





        if (map.mapArray != null)
            Debug.Log("OK");



        Debug.Log(map.seed);
        Debug.Log(map.mapHeight);

        for (int xPos = 0; xPos < map.mapHeight; xPos++)
        {

            for (int yPos = 0; yPos < map.mapHeight; yPos++)
            {

                //Debug.Log(xPos + "," + yPos);

                GameObject go =  GameObject.Instantiate(mapPiece);

                SpriteRenderer curr = go.GetComponent<SpriteRenderer>();

                curr.sprite = sprites[((int)map.mapArray[xPos, yPos, 0].type)];

                curr.transform.parent = showLay.transform;

                Vector2 pos = new Vector3(yPos, -xPos) * tileSize;
                pos = pos + posMultiplyer;

                curr.transform.localPosition = (pos);

                //Debug.Log("Tile Done");
            }
        }
    }

}
