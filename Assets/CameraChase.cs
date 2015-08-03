using UnityEngine;
using System.Collections;



//[AddComponentMenu("Camera/CameraChase")]
//public class CameraChase : MonoBehaviour
//{

   
//    public Transform chase;
//    public Rect area;
//    public bool loaded = false;

//    public RectTransform rectTrans;

//    void Start()
//    {
//    }

//    // Use this for initialization
//    public void MapLoaded()
//    {
//        GameController GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
//        if (GameCon.map == null)
//            Debug.LogError("Can't find GameController");

//        chase = GameObject.FindGameObjectWithTag("Player").transform;
//        area = new Rect();

//        /*
//        area.x = 10.50f;
//        area.y = -3f - (GameCon.map.mapHeight * 1.0f - 6f);
//        area.width = GameCon.map.mapHeight * 1.0f - 11f;
//        area.height = GameCon.map.mapHeight * 1.0f - 8f;
//        */

//        Debug.Log(Camera.main.rect);

//        area.x = 0 + (Camera.main.rect.x / 2);
//        area.y = 0f - (GameCon.map.mapHeight);
//        area.width = (GameCon.map.mapHeight);
//        area.height = (GameCon.map.mapHeight);

        
//        Debug.Log(area);
//        loaded = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (chase == null)
//        {

            

//            return;

//        }
//        if (loaded)
//        {
//            if (area.Contains(new Vector2(chase.position.x, chase.position.y)))
//            {
//                transform.position = chase.position + Vector3.back * 10;

//            }
//            else if (chase.position.x > area.xMax && chase.position.y > area.yMax)
//            {
//                transform.position = new Vector3(area.xMax, area.yMax);
//            }
//            else if (chase.position.x > area.xMax && chase.position.y < area.yMin)
//            {
//                transform.position = new Vector3(area.xMax, area.yMin);
//            }
//            else if (chase.position.x < area.xMin && chase.position.y > area.yMax)
//            {
//                transform.position = new Vector3(area.xMin, area.yMax);
//            }
//            else if (chase.position.x < area.xMin && chase.position.y < area.yMin)
//            {
//                transform.position = new Vector3(area.xMin, area.yMin);

//            }
//            else if (chase.position.x < area.xMin && area.yMax > chase.position.y && chase.position.y > area.yMin)
//            {
//                transform.position = new Vector3(area.xMin, chase.position.y);
//            }
//            else if (chase.position.x > area.xMax && area.yMax > chase.position.y && chase.position.y > area.yMin)
//            {
//                transform.position = new Vector3(area.xMax, chase.position.y);
//            }
//            else if (area.xMax > chase.position.x && chase.position.x > area.xMin && chase.position.y < area.yMin)
//            {
//                transform.position = new Vector3(chase.position.x, area.yMin);
//            }
//            else if (area.xMax > chase.position.x && chase.position.x > area.xMin && chase.position.y > area.yMax)
//            {
//                transform.position = new Vector3(chase.position.x, area.yMax);
//            }
//            transform.position = new Vector3(transform.position.x, transform.position.y, -10);

//        }
//    }
//}


[AddComponentMenu("Camera/CameraChase")]
public class CameraChase : MonoBehaviour
{


    public Transform chase;
    public bool loaded = false;


    public RectTransform rectTrans;

    Camera CameraScript;
    GameController GameCon;

    void Start()
    {
        

    }

    // Use this for initialization
    public void MapLoaded()
    {

        CameraScript = this.GetComponent<Camera>();
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (GameCon.map == null)
        {
            Debug.LogError("Can't find GameController");
            Debug.Break();
        }

        loaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (chase == null)
        {

            return;

        }
        if (loaded)
        {
            float xPos = chase.transform.position.x;
            float yPos = chase.transform.position.y;
            float horzExtent = CameraScript.orthographicSize * Screen.width / Screen.height;
           transform.position = new Vector3(Mathf.Clamp(xPos, horzExtent, GameCon.map.mapHeight - horzExtent),-1 * Mathf.Clamp(-1*yPos, CameraScript.orthographicSize, GameCon.map.mapHeight - CameraScript.orthographicSize), transform.position.z);
           //transform.position = new Vector3(Mathf.Clamp(xPos, ratio[0], GameCon.map.mapHeight - ratio[0]), Mathf.Clamp(yPos, ratio[1], GameCon.map.mapHeight - ratio[1]), transform.position.z);

        }
    }
}

