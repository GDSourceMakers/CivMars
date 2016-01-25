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
				if (tank.gasType != GasType.Null)
				{
					gasName.text = tank.gasType.ToString();
				}
				else
				{
					gasName.text = "Nothing";
				}
				amount.text = tank.amount + " / " + tank.maxAmount;
				amountSlider.value = tank.amount / tank.maxAmount;

				inButton.gameObject.SetActive(true);
				outButton.gameObject.SetActive(true);
			}
			else
			{
				//inButton.gameObject.SetActive(false);
				//outButton.gameObject.SetActive(false);
			}

			ChangedState();
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
			GasController.SetInput(this);
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