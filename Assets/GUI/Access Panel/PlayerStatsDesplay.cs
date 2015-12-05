using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class PlayerStatsTabDesplay : MonoBehaviour
{
	GameController GameCon;
	Player player;

	public Text health;
	public Text hearthRate;

	void Start()
	{
		GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		player = GameCon.playerclass;
	}

	void Update()
	{
		health.text = player.health.ToString();
		hearthRate.text = "60 rp";
	}

	public void UpdateData(Building datas)
	{
		//throw new NotImplementedException();
	}
}

