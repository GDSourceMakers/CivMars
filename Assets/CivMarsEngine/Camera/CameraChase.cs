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

namespace CivMarsEngine
{
	[AddComponentMenu("Camera/CameraChase")]
	public class CameraChase : MonoBehaviour
	{

		public Transform chase;
		public bool loaded = false;

		//public float eventHorizont = 1.5f;

		public float eventHorizontX = 1f;
		public float eventHorizontY = 1f;

		//public RectTransform rectTrans;

		Camera CameraScript;
		GameController GameCon;

		float xCameraH;
		float yCameraH;

		void Start()
		{

           // MapLoaded();
		}

		// Use this for initialization
		public void MapLoaded()
		{
			CameraScript = this.GetComponent<Camera>();
			GameCon = GameController.instance;

			if (GameCon == null)
			{
				Debug.LogError("Can't find GameController");
				//Debug.Break();
			}

			loaded = true;
			
			float f = (float)((float)Screen.width / (float)Screen.height);
			float s = CameraScript.orthographicSize;
			float a = CameraScript.rect.width;
			xCameraH = s*f*a;

            Debug.Log("f: "+ f);
			Debug.Log("s: "+ s);
			Debug.Log("a: "+ a);
			Debug.Log("xCameraH: "+xCameraH);

			yCameraH = CameraScript.orthographicSize * (CameraScript.rect.height);
		}

		// Update is called once per frame
		void Update()
		{
			if (chase == null)
			{
				return;
			}
			//TODO Chnage loaded to something
			if (loaded)
			{
				float xCamPos = transform.position.x;
				float yCamPos = -1 * transform.position.y;

				float xPos = chase.transform.position.x;
				float yPos = -1 * chase.transform.position.y;

				//transform.position = new Vector3(Mathf.Clamp(xPos, xCameraH, GameCon.map.mapHeight - xCameraH),-1 * Mathf.Clamp(-1*yPos, yCameraH, GameCon.map.mapHeight - yCameraH), transform.position.z);
				transform.position = new Vector3(
													Mathf.Clamp(
													xCamPos + OutRangeClamp(xPos, xCamPos - xCameraH * eventHorizontX, xCamPos + xCameraH * eventHorizontX),
													xCameraH,
													MapManagger.instance.mapHeight - xCameraH
													),

												-1 * Mathf.Clamp(
													yCamPos + OutRangeClamp(yPos, yCamPos - yCameraH * eventHorizontY, yCamPos + yCameraH * eventHorizontY),
													yCameraH,
                                                    MapManagger.instance.mapHeight - yCameraH
													),
												transform.position.z);
			}
		}

		float OutRangeClamp(float value, float Min, float Max)
		{
			if (value < Min)
			{
				//Debug.Log("if");
				return value - Min;
			}
			else if (value > Max)
			{
				//Debug.Log("else");

				return value - Max;
			}
			return 0;
		}
	}

}