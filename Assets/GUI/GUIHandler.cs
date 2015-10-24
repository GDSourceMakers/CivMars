using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GUIHandler : MonoBehaviour
{
	public AccesPanel AccesPanel;

	public GameObject gameGui;

	public ActionButton[] actions = new ActionButton[10];

    //public bool isGUIOpen;

	public IHasGui OpenGUI;
	public bool isGUIOpen;

    // Use this for initialization
    void Start()
    {
        GameObject ac = GameObject.Find("Actions");
        for (int i = 0; i < ac.transform.childCount; i++)
        {
            GameObject go = ac.transform.GetChild(i).gameObject;
            //actions[i] = go.AddComponent<ActionButton>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
