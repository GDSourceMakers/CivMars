using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using CivMarsEngine;

namespace CivMars
{
	[AddComponentMenu("Buildings/Chest")]
	public class Chest : BuildingWGUI, IInventory, IBuildable, IRegystratabe, IHasGui, ISaveble
	{
		new public static string ID = CivMarsInit.BlockSpace + ".Chest";

		public Text Name;
		public Text InventoryButtonText;

		public Inventory inventory = new Inventory(15);

		public Sprite Icon;

		static new Item[] buildingMaterials = { new SandOre(2) };

		bool invOn;

		public override void Awake()
		{
			base.Awake();
		}

		public void OpenInventory()
		{
			invOn = !invOn;
			if (invOn)
				GameCon.guiHandler.defaultInventory.Activate(this);
			else
				GameCon.guiHandler.defaultInventory.Deactive();

		}

		#region IHasGUI

		public override void Close()
		{
			base.Close();
			GameCon.guiHandler.defaultInventory.Deactive();
		}

		#endregion


		#region IBuildable

		public Sprite GetImage()
		{
			return Icon;
		}

		public override GameObject GetPrefab()
		{
			return gameObject;
		}

		public Image GetBuildedState()
		{
			throw new NotImplementedException();
		}

		public Item[] GetNeededMaterials()
		{
			return buildingMaterials;
		}

		public float GetBuildtime()
		{
			return 5f;
		}

		public void Setup()
		{
		}

		#endregion

		public void Regystrate()
		{
			base.ID = ID;
			GameRegystry.RegisterBuildableBuilding(ID, this);
		}

		#region Inventory

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
			return inventory.Remove(i);
		}

		public void TransferItem(IInventory ToInv, int index)
		{
			throw new NotImplementedException();
		}

		public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
		{
			throw new NotImplementedException();
		}



		#endregion

		public override SavedTile Save()
		{
			return new Saved(this);
		}

		[Serializable]
		public class Saved : SavedTile
		{
			Inventory inv;

			public Saved(Chest c) : base(Chest.ID)
			{
				inv = c.inventory;
			}
		}
	}

}