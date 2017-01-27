using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CivMarsEngine;

namespace CivMarsEngine
{
	public class PlayerStatsSidebarDesplay : MonoBehaviour
	{
		public Image OxigenSlider;
		public Image CarbonDioxideSlider;
		public Image Health;

		GameController GameCon;

		//GameObject[] hRPeaces = new GameObject[10];

		// Use this for initialization
		void Start()
		{
            GameCon = GameController.instance;
		}

		// Update is called once per frame
		void Update()
		{
			/*
			GasTankCluster t = GameCon.playerclass.GetTankCluster();

			OxigenSlider.value = t.GetTank(GasType.Oxigen).amount / t.GetTank(GasType.Oxigen).maxAmount;
			CarbonDioxideSlider.value = t.GetTank(GasType.CarbonDeOxide).amount / t.GetTank(GasType.CarbonDeOxide).maxAmount;

			Health.color = new Color(0, 0, 0, 1 - GameCon.playerclass.health);

			/*
			foreach (GameObject item in hRPeaces)
			{
				//item.transform.position = new Vector3(item.transform.position.x);
			}
			*/
			
		}
	}
}