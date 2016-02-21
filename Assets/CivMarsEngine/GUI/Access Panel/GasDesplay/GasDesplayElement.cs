using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CivMarsEngine
{
	public class GasDesplayElement : MonoBehaviour
	{

		bool show;

		int index;

		public Text gasName;
		public Text amount;
		public Slider amountSlider;

		public Toggle inButton;
		public Toggle outButton;

		public IGasTank tank;
		GasDesplay GasController;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (tank != null)
			{
				if (tank.GetGas(index) != null)
				{
					gasName.text = tank.GetGas(index).name;

					amount.text = tank.GetGas(index).amount + " / " + tank.GetMaxAmount(index);
					amountSlider.value = tank.GetGas(index).amount / tank.GetMaxAmount(index);

					//inButton.gameObject.SetActive(true);
					//outButton.gameObject.SetActive(true);
				}
				else
				{
					gasName.text = "Nothing";
				}


			}
		}

		public void Set(IGasTank setTank, bool s)
		{
			show = s;
			gameObject.SetActive(show);

			tank = setTank;
		}

		public void SetUp(int thisTank, GasDesplay controll)
		{
			index = thisTank;
			GasController = controll;
		}

		public void SetInput(bool a)
		{
			GasController.SetInput(this);
        }

		public void SetOutput(bool a)
		{
			GasController.SetOutput(this);
		}

		public void TurnInput(bool a)
		{
			inButton.isOn = a;
		}

		public void TurnOutput(bool a)
		{
			outButton.isOn = a;
		}
	}
}