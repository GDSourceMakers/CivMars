using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIHandler : MonoBehaviour
{

    public InventoryDesplay InventoryDisplay;
    public DualInventoryDesplay DualInventory;

    public GameObject actionGroup;

    public ActionButton[] actions = new ActionButton[10];

    public bool inventoryOn;
    public bool dualinventoryOn;

    // Use this for initialization
    void Start()
    {
        GameObject ac = GameObject.Find("Actions");
        actionGroup = ac;
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
