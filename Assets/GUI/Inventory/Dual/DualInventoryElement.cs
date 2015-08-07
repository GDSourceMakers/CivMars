using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("Dual Inventory/Dual Inventory Element")]
public class DualInventoryElement : MonoBehaviour
{
    public bool isPlayer;
    public string name;
    public int amount;
    public int index;

    public Inventory other;
    public Inventory thisinv;

    public GameController GameCon;
    public GameObject nameDisplay;
    public GameObject amountDisplay;


    // Use this for initialization
    void Awake()
    {
        nameDisplay = transform.FindChild("Name").gameObject;
        amountDisplay = transform.FindChild("Icon").gameObject;
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();


    }

    // Update is called once per frame
    void Update()
    {

    }


    #region Set
    public void Set(int setAmount)
    {
        this.amount = setAmount;
        amountDisplay.GetComponent<Text>().text = null;
        amountDisplay.GetComponent<Text>().text = setAmount.ToString();

        //Debug.Log("updated drawed inv element:  amount: " + amount + " type: " + this.name + " obj: " + this.GetType().ToString());
    }

    public void Set(string setName)
    {
        this.name = setName;
        Debug.Log(setName);

        nameDisplay.GetComponent<Text>().text = setName.ToString();
    }

    public void Set(string setName, int setAmount)
    {
        Set(setName);
        Set(setAmount);
    }

    public void Set(Item item)
    {
        Set(item.amount);

        Debug.Log(GameCon.language);
        Set(Language.Get(item, GameCon.language));
    }
    #endregion


    public void Transfer()
    {
        Debug.Log("Transfer");


        other.TransferItem(thisinv, index);

    }
}
