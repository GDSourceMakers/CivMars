using System;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour, IGasTank, IInventory
{
	public GameController GameCon;

	SpaceSuit suit = new SpaceSuit();

	public float health = 1;



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
/*
		Item mined;
		Vector2 pos = new Vector2((int)Mathf.Round(transform.position.x), -1 * (int)Mathf.Round(transform.position.y));


		GeneratedTile ore = ((GeneratedTile)GameCon.map.mapManagger.tiles[(int)pos.x, (int)pos.y]);

		if (ore.GetType() == typeof(OreTile))
		{

			//((OreTile)ore).amount -= 1;

			mined = (((Item)Activator.CreateInstance(null, ore.type.ToString() + "Ore").Unwrap()));
			mined.amount = 1;

			inventory.Add(mined);

			Debug.Log("Ore: " + ((OreTile)ore).amount + " Item: " + ((OreTile)ore).amount);

			if (((OreTile)ore).Mine(1))
			{
				Debug.Log("Out Mined");
				GameCon.map.MapUpdate((int)pos.x, (int)pos.y, GameCon.map);
			}
		}
		*/

	}

	public void MineStar()
	{
		/*
		Vector2 pos = new Vector2((int)Mathf.Round(transform.position.x), -1 * (int)Mathf.Round(transform.position.y));

		GeneratedTile ore = ((GeneratedTile)GameCon.map.mapGenerated[(int)pos.x, (int)pos.y]);

		if (ore.GetType() == typeof(OreTile))
		{
			GameCon.guiHandler.actions[0].Action(((OreTile)ore).miningTime[(int)ore.type], "Mine");
		}
		*/
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

