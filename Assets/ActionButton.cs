using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{


    public float countdown;
    public float fullcount;

    public GameController GameCon;

    GameObject playergo;

    public Button buttonscript;


    public float defaultYPos;
    public float defaultXPos;

    public RectTransform maskRect;
    public string action = "Mine";


    public bool ActionRuned = true;

    // Use this for initialization
    void Start()
    {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        countdown = 0;

        buttonscript = gameObject.GetComponent<Button>();

        if (buttonscript == null)
            Debug.LogError("Can't find Button Script");

        maskRect = gameObject.transform.FindChild("Mask").GetComponent<RectTransform>();


        defaultYPos = maskRect.localPosition.y;


    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            buttonscript.interactable = false;
            
            

            maskRect.localPosition = new Vector2(maskRect.localPosition.x, Mathf.Lerp(defaultYPos + maskRect.rect.height, defaultYPos, (countdown / fullcount)));
            ActionRuned = false;
            GameCon.playerclass.GetComponent<Rigidbody2D>().isKinematic = true;
            countdown -= Time.deltaTime;
        }
        else
        {
            buttonscript.interactable = true;
            maskRect.position = new Vector2(maskRect.position.x, defaultYPos + maskRect.rect.height);

            if (ActionRuned == false)
            {

                MethodInfo m = GameCon.playerclass.GetComponent<Player>().GetType().GetMethod(action);
                m.Invoke(GameCon.playerclass.GetComponent<Player>(), null);
                ActionRuned = true;
                GameCon.playerclass.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }

    }

    public void Action(float time, string functionname)
    {
        if (countdown <= 0)
        {
            action = functionname;
            countdown = time;
            fullcount = time;
        }
    }


}
