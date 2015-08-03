using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryDrawedElement : MonoBehaviour {

    public string name;
    public int amount;


    public GameObject nameDisplay;
    public GameObject amountDisplay;


	// Use this for initialization
	void Awake () {
        nameDisplay = transform.FindChild("Name").gameObject;
        amountDisplay = transform.FindChild("Icon").gameObject;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Set(int setAmount)
    {
        this.amount = setAmount;
        amountDisplay.GetComponent<Text>().text = null;
        amountDisplay.GetComponent<Text>().text = setAmount.ToString();

        Debug.Log("updated drawed inv element:  amount: " + amount + " type: "+ this.name + " obj: " + this.GetType().ToString());
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

        Set(Language.Get(item));
    }
}
