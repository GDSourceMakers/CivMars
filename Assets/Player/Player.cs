using System;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
	public GameController GameCon;



	public float OxigenTank;
	static public float OxigenTankFull = 200;


	public float CarbonDioxideTank;
	static public float CarbonDioxideTankFull = 200;

	public float health = 1;



	public Inventory Inventory = new Inventory(10);

	public int eatSpeed;
	public int breathAmount = 1;
	public int speed;

	public void Start()
	{
		OxigenTank = OxigenTankFull;
		CarbonDioxideTank = 0;
		GameCon = GameObject.Find("_GameController").GetComponent<GameController>();

	}

	void Update()
	{
		Breath();
		

		

		float OxigenHp =			Mathf.Clamp((OxigenTank * 5)		/ OxigenTankFull		,0, 1);
		float CarbonDioxideHp =		Mathf.Clamp(((CarbonDioxideTankFull - CarbonDioxideTank) * 5) / CarbonDioxideTankFull	,0, 1); ;

		health =
			(
				((OxigenHp) * 10)		*
				((CarbonDioxideHp) * 10)
			)/Mathf.Pow(10,2);
		//Debug.Log("Deadly Carbon percent: " + CarbonDioxideHp + "  Deadly Oxigen percent: " + OxigenHp + "  health: "+ health);
	}

	public void Eat()
	{
		throw new System.NotImplementedException();
	}

	public void Breath()
	{
		if (OxigenTank - (breathAmount * Time.deltaTime) > 0)
		{
			OxigenTank -= breathAmount * Time.deltaTime;
			CarbonDioxideTank += (breathAmount * Time.deltaTime) / 2;

		}
		else
		{
			OxigenTank = 0;
		}
	}

	public void walk()
	{
		throw new System.NotImplementedException();
	}

	public void Mine()
	{

		Item mined;
		Vector2 pos = new Vector2((int)Mathf.Round(transform.position.x), -1*(int)Mathf.Round(transform.position.y));


		GeneratedTile ore = ((GeneratedTile)GameCon.map.mapGenerated[(int)pos.x, (int)pos.y]);

		if (ore.GetType() == typeof(OreTile))
		{

			//((OreTile)ore).amount -= 1;

			mined = (((Item)Activator.CreateInstance(null, ore.type.ToString() + "Ore").Unwrap()));
			mined.amount = 1;

			Inventory.Add(mined);

			GameCon.guiHandler.InventoryDisplay.UpdateInventory();

			Debug.Log("Ore: "+ ((OreTile)ore).amount+ " Item: "+((OreTile)ore).amount);

			if (((OreTile)ore).Mine(1))
			{
				Debug.Log("Out Mined");
				GameCon.map.MapUpdate((int)pos.x, (int)pos.y, GameCon.map);
			}
		}


	}

	public void MineStar()
	{
		Vector2 pos = new Vector2((int)Mathf.Round(transform.position.x), -1*(int)Mathf.Round(transform.position.y));


		GeneratedTile ore = ((GeneratedTile)GameCon.map.mapGenerated[(int)pos.x, (int)pos.y]);

		if (ore.GetType() == typeof(OreTile))
		{
			GameCon.guiHandler.actions[0].Action(((OreTile)ore).miningTime[(int)ore.type], "Mine");
		}
	}

}

