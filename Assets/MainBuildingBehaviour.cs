using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class MainBuildingBehaviour : BuildingBehaviour
{
    public Text Name;
    public Text InventoryButtonText;
    public Text asd;
    public GameObject Canvas;
    public bool guion;


    GameController GameCon;

    void Start()
    {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Canvas.SetActive(false);
        Canvas.transform.position = Vector3.zero;
    }

    void OnMouseDown()
    {
        if (guion)
        {
            Canvas.SetActive(false);
            guion = false;
        }
        else
        {
            Canvas.SetActive(true);
            guion = true;
        }
    }

    public void OpenInventory()
    {
        GameCon.TogleDualInventory(((MainBuilding)properties).Inventory);
    }

}
