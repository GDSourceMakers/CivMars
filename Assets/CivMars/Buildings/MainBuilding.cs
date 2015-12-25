using System;
using UnityEngine.UI;
using UnityEngine;
using CivMarsEngine;

namespace CivMars
{
	[AddComponentMenu("Buildings/Main Building")]
	[System.Serializable]
	public class MainBuilding : BuildingWGUI, IInventory, IGasTank, IRegystratabe, ISaveble
	{
		enum States
		{
			None,
			Inv,
			Gas
		}

		new public static string ID = "CivMars.MainBuilding";

		public Text Name;
		public Text InventoryButtonText;


		public Inventory inventory = new Inventory(20);

		public static float[] max = { 1000f, 1000f, 1000f, 1000f };
		public GasTankCluster tanks = new GasTankCluster(4, max);
		[SerializeField]
		States invOn;

		public override void Awake()
		{
			base.Awake();
		}

		public void OpenInventory()
		{
			if (invOn != States.Inv)
			{
				GameCon.guiHandler.defaultGas.gameObject.SetActive(false);

				GameCon.guiHandler.defaultInventory.Activate(this);
				GameCon.guiHandler.defaultGas.SetOtherInv(null);
				invOn = States.Inv;
			}
			else
			{
				GameCon.guiHandler.defaultInventory.gameObject.SetActive(false);

				GameCon.guiHandler.defaultInventory.Deactive();
				invOn = States.None;
			}
		}

		public void OpenGas()
		{

			if (invOn != States.Gas)
			{
				GameCon.guiHandler.defaultInventory.gameObject.SetActive(false);
				GameCon.guiHandler.defaultGas.gameObject.SetActive(true);

				GameCon.guiHandler.defaultInventory.Deactive();
				GameCon.guiHandler.defaultGas.SetOtherInv(this);
				invOn = States.Gas;
			}
			else
			{
				GameCon.guiHandler.defaultGas.gameObject.SetActive(false);

				GameCon.guiHandler.defaultGas.SetOtherInv(null);
				invOn = States.None;
			}

		}

		#region IHasGUI

		public override void Close()
		{
			base.Close();
			GameCon.guiHandler.defaultInventory.gameObject.SetActive(false);
			GameCon.guiHandler.defaultInventory.Deactive();

			GameCon.guiHandler.defaultGas.gameObject.SetActive(false);
			GameCon.guiHandler.defaultGas.SetOtherInv(null);

			invOn = States.None;
		}

		#endregion

		public GasTankCluster GetTankCluster()
		{
			return tanks;
		}

		#region IInventory

		public int GetInventorySize()
		{
			return inventory.size;
		}

		public string GetInventoryName()
		{
			throw new NotImplementedException();
		}

		public bool HasCustomInventoryName()
		{
			return false;
		}

		public Item GetStackInSlot(int i)
		{
			return inventory.Get(i);
		}

		public int GetInventoryStackLimit(int i)
		{
			throw new NotImplementedException();
		}

		public bool IsItemValidForSlot(int slot, Item givenItem)
		{
			throw new NotImplementedException();
		}

		public bool IsUseableByPlayer(Player p_70300_1_)
		{
			return true;
		}

		public Item Add(Item i)
		{
			return inventory.Add(i);
		}

		public Item Remove(Item i)
		{
			inventory.Remove(i);
			throw new NotImplementedException();
		}

		public void TransferItem(IInventory ToInv, int index)
		{
			inventory.TransferItem(ToInv, index);
		}

		public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
		{
			inventory.TransferItemAmount(Toinv, fromindex, transferingAmount);
		}

		#endregion

		#region IRgeistraste
		public void Regystrate()
		{
			base.ID = ID;
			GameRegystry.RegisterBuildableBuilding(ID, this);
		}
		#endregion

		public override GameObject GetPrefab()
		{
			return gameObject;
		}

		public override SavedTile Save()
		{
			return new Saved(this);
		}

		[Serializable]
		public class Saved : SavedTile
		{
			Inventory inv;

			public Saved(MainBuilding c) : base(MainBuilding.ID)
			{
				inv = c.inventory;
			}
		}
	}


}