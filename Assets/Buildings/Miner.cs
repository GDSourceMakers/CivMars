using System;
using UnityEngine;
using UnityEngine.UI;

public class Miner : Building, IInventory, IHasGui, IRegystratabe, IBuildable
{
	static public string ID = "CivMars.Miner";
	static Item[] neededMaterials = { new SandOre(1) };
	public Sprite icon;


	public OreTile mining;
	public float time;
	public float startTime;
	public bool on;

	public Text TypeDesplay;
	public Slider TimeLeft;

	bool invOn;

	Inventory inv = new Inventory(1);

	public override void Awake()
	{
		base.Awake();
		Graphicks.SetActive(false);
		this.Graphicks.transform.position = Vector3.zero;
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

	#region IInventory

	public Item Add(Item i)
	{
		return i;
	}

	public string GetInventoryName()
	{
		throw new NotImplementedException();
	}

	public int GetInventorySize()
	{
		return 1;
	}

	public int GetInventoryStackLimit(int i)
	{
		throw new NotImplementedException();
	}

	public Item GetStackInSlot(int i)
	{
		return inv.Get(i);
	}

	public bool HasCustomInventoryName()
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

	public Item Remove(Item i)
	{
		return inv.Remove(i);
	}

	public void TransferItem(IInventory ToInv, int index)
	{
		inv.TransferItem(ToInv, index);
	}

	public void TransferItemAmount(IInventory ToInv, int index, int transferingAmount)
	{
		inv.TransferItemAmount(ToInv, index, transferingAmount);
	}
	#endregion

	#region IRegystratabe
	public void Regystrate()
	{
		GameRegystry.RegisterBuildableBuilding(ID, this);
	}
	#endregion

	#region IBuildable
	public float GetBuildtime()
	{
		return 1f;
	}

	public Sprite GetImage()
	{
		return icon;
	}

	public GameObject GetPrefab()
	{
		return gameObject;
	}

	public Image GetBuildedState()
	{
		throw new NotImplementedException();
	}

	public Item[] GetNeededMaterials()
	{
		return neededMaterials;
	}

	#endregion


	// Update is called every frame, if the MonoBehaviour is enabled
	public void Update()
	{
		if (on)
		{
			if (mining != null)
			{
				if (time > 0f)
				{
					time -= Time.deltaTime;
				}
				else
				{
					time = startTime;
					Item minedOre = ((Item)Activator.CreateInstance(((OreTile)mining).GetItemType()));
					minedOre.amount = 1;
					mining.Mine(1);
					inv.Add(minedOre);
				}

				TypeDesplay.text = "Mining: " + mining.GetType();
				TimeLeft.value = time;
			}
			else
			{
				TypeDesplay.text = "No ore was found!";
			}
		}


	}

	public void TurnOn(bool a)
	{
		on = a;
	}

	public void Setup()
	{
		TileVector pos = new TileVector((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y), TileVectorTypes.ySwaped);
		TileTransform tile = GameCon.map.Generated.GetTileOn(pos);

		if (tile != null)
		{
			OreTile ore = ((OreTile)tile.GetComponent<OreTile>());

			if (ore != null)
			{
				mining = ore;
				startTime = ore.GetMiningTime();
				TimeLeft.maxValue = startTime;
			}
		}

	}
}

