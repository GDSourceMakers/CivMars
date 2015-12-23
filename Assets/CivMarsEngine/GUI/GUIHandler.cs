using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using CivMarsEngine;

public class GUIHandler : MonoBehaviour
{
	GameController GameCon;

	public AccesPanel AccesPanel;

	public InventoryDesplay defaultInventory;
	public GasDesplay defaultGas;
	public CraftingDesplay defaultCrafting;

	public Slider miningSlider;
	public GameObject miningPlanel;

	
	// Use this for initialization
	void Start()
    {
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
		if (GameCon.playerclass.miningTime > 0)
		{

			miningPlanel.SetActive(true);
			miningSlider.maxValue = GameCon.playerclass.fullMiningTime;
			miningSlider.value = GameCon.playerclass.miningTime;
		}
		else
		{
			miningPlanel.SetActive(false);
		}
    }

}
