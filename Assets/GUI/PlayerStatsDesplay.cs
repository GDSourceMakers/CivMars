using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatsDesplay : MonoBehaviour
{
	public Slider OxigenSlider;
	public Slider CarbonDioxideSlider;
	public Image Health;

	GameController GameCon;

	GameObject[] hRPeaces = new GameObject[10];

	// Use this for initialization
	void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update()
	{
		
		OxigenSlider.value = GameCon.playerclass.OxigenTank / Player.OxigenTankFull;
		CarbonDioxideSlider.value = GameCon.playerclass.CarbonDioxideTank / Player.CarbonDioxideTankFull;
		
		Health.color = new Color(0, 0, 0,1- GameCon.playerclass.health);

		foreach (GameObject item in hRPeaces)
		{
			//item.transform.position = new Vector3(item.transform.position.x);
		}

	}
}
