using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CivMarsEngine
{
	[AddComponentMenu("Inventory/Inventory Element")]
	public class InventoryDrawedElement : MonoBehaviour
	{
		//GameController GameCon;

		public bool isPlayer;
		public string drawname_name;
		public int amount;
		public int index;

		public IInventory other;
		public IInventory thisinv;


		public Text nameDisplay;
		public Text amountDisplay;
		public Button button;


		// Use this for initialization
		void Awake()
		{
           // GameCon = GameController.instance;
		}

		// Update is called once per frame
		void Update()
		{
			if (other == null)
			{
				button.gameObject.SetActive(false);
			}
			else
			{
				button.gameObject.SetActive(true);
			}
		}


		#region Set
		public void Set(int setAmount)
		{
			this.amount = setAmount;
			amountDisplay.text = setAmount.ToString();

			//Debug.Log("updated drawed inv element:  amount: " + amount + " type: " + this.name + " obj: " + this.GetType().ToString());
		}

		public void Set(string setName)
		{
			this.drawname_name = setName;
			nameDisplay.text = setName.ToString();
		}

		public void Set(string setName, int setAmount)
		{
			Set(setName);
			Set(setAmount);
		}

		public void Set(Item item, bool isp, IInventory o, IInventory t, int i)
		{
			isPlayer = isp;
			other = o;
			thisinv = t;
			index = i;


			Set(item.amount);
			//Set(Language.Get(item, GameCon.language));
			Set(item.name);
		}
		#endregion


		public void Transfer()
		{
			Debug.Log("Transfer");
			if (Input.GetButton("Specific"))
			{
				thisinv.TransferItemAmount(other, index, 1);
				return;
			}


			thisinv.TransferItem(other, index);

		}
	}
}