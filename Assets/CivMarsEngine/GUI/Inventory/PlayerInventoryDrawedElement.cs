using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CivMarsEngine
{
	[AddComponentMenu("Inventory/Inventory Element")]
	public class PlayerInventoryDrawedElement : MonoBehaviour
	{
		GameController GameCon;

		//public bool isPlayer;
		public string drawname_name;
		public int amount;
		public int index;

		public GameObject nameDisplay;
		public GameObject amountDisplay;
		public GameObject iconDesplay;


		// Use this for initialization
		void Awake()
		{
			GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		}

		// Update is called once per frame
		void Update()
		{
		}


		#region Set
		/*
		public void Set(int setAmount)
		{
			this.amount = setAmount;
			amountDisplay.GetComponent<Text>().text = null;
			amountDisplay.GetComponent<Text>().text = setAmount.ToString();

			//Debug.Log("updated drawed inv element:  amount: " + amount + " type: " + this.name + " obj: " + this.GetType().ToString());
		}

		public void Set(string setName)
		{
			this.drawname_name = setName;
			//Debug.Log(setName);

			nameDisplay.GetComponent<Text>().text = setName.ToString();
		}

		public void Set(string setName, int setAmount)
		{
			Set(setName);
			Set(setAmount);
		}
		*/

		public void Set(Item item, int i)
		{
			//isPlayer = isp;
			//other = o;
			//thisinv = t;
			index = i;

			amount = item.amount;
			amountDisplay.GetComponent<Text>().text = amount.ToString();

			drawname_name = item.name;
			nameDisplay.GetComponent<Text>().text = drawname_name;

			iconDesplay.GetComponent<Image>().sprite = item.texture;
		}
		#endregion
	}
}