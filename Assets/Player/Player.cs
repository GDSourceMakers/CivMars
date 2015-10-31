using System;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour, IGasTank, IInventory
{
	public GameController GameCon;

	SpaceSuit suit = new SpaceSuit();

	public float health = 1;

	OreTile mining;

	public Inventory inventory = new Inventory(10);

	public int eatSpeed;
	public float breathAmount = 1;
	public int speed;

	public void Start()
	{
		GetTankCluster().GetTank(0).gasType = GasType.Oxigen;
		GetTankCluster().GetTank(0).SetLocked(true);
		GetTankCluster().GetTank(1).gasType = GasType.CarbonDeOxide;
		GetTankCluster().GetTank(1).SetLocked(true);

		GetTankCluster().GetTank(0).AddAmount(GetTankCluster().GetTank(0).maxAmount);
		GameCon = GameObject.Find("_GameController").GetComponent<GameController>();

	}

	void Update()
	{
		//Breath();
		GasTank oxigen = GetTankCluster().GetTank(0);
		GasTank carbonDioxide = GetTankCluster().GetTank(1);

		float OxigenTank = oxigen.amount;
		float OxigenTankFull = oxigen.maxAmount;

		float CarbonDioxideTank = carbonDioxide.amount;
		float CarbonDioxideTankFull = carbonDioxide.maxAmount;

		float OxigenHp = Mathf.Clamp((OxigenTank * 5) / OxigenTankFull, 0, 1);
		float CarbonDioxideHp = Mathf.Clamp(((CarbonDioxideTankFull - CarbonDioxideTank) * 5) / CarbonDioxideTankFull, 0, 1); ;

		health =
			(
				((OxigenHp) * 10) *
				((CarbonDioxideHp) * 10)
			) / Mathf.Pow(10, 2);
		//Debug.Log("Deadly Carbon percent: " + CarbonDioxideHp + "  Deadly Oxigen percent: " + OxigenHp + "  health: "+ health);
	}

	public void Eat()
	{
		throw new System.NotImplementedException();
	}

	public void Breath()
	{
		GetTankCluster().GetTank(0).RemoveAmount(breathAmount * Time.deltaTime, GasType.Oxigen);
		GetTankCluster().GetTank(1).AddAmount(breathAmount * Time.deltaTime, GasType.CarbonDeOxide);
	}

	public void walk()
	{
		throw new System.NotImplementedException();
	}

	public void Mine()
	{
		Item mined;

		mined = ((Item)Activator.CreateInstance(((OreTile)mining).GetItemType()));
		mined.amount = 1;

		inventory.Add(mined);

		Debug.Log("Ore: " + ((OreTile)mining).GetAmountLeft() + " Item: " + ((OreTile)mining).GetAmountLeft());

		((OreTile)mining).Mine(1);
	}

	public void MineStar()
	{

		TileVector pos = new TileVector((int)Mathf.Round(transform.position.x), -1 * (int)Mathf.Round(transform.position.y));

		OreTile ore = ((OreTile)GameCon.map.mapManagger.GetTileOn(pos).GetComponent<OreTile>());

		if (ore.GetType() != null)
		{
			mining = ore;
			GameCon.guiHandler.actions[0].Action(((OreTile)ore).GetMiningTime(), "Mine");
		}

	}

	public GasTankCluster GetTankCluster()
	{
		return suit.GetTankCluster();
	}

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
		inventory.TransferItem(ToInv, index);
	}

	public void TransferItemAmount(IInventory Toinv, int fromindex, int transferingAmount)
	{
		inventory.TransferItemAmount(Toinv, fromindex, transferingAmount);
	}
}

