using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    public GameController GameCon;

    // Use this for initialization
    void Start()
    {
            GameCon = GameObject.Find("_GameController").GetComponent<GameController>();
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameCon.gameIsOn)
        {
            //Debug.Log("Check key");

            if (Input.GetButtonUp("Mine") && (GameCon.gameS == GameState.InGame))
            {
                Debug.Log("Mine");
                GameCon.playerclass.MineStar();
            }
        }
    }
}
