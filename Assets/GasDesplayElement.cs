using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GasDesplayElement : MonoBehaviour {

	public Text gasName;
	public Text amount;
	public Slider amountSlider;

	public Toggle inButton;
	public Toggle outButton;

	public bool inPressed;
	public bool outPressed;

    public	GasTank tank;
	GasDesplay other;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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

	public void Set(GasTank thisTnak, GasDesplay otherD)
	{
		other = otherD;

		if (thisTnak != null)
		{
			tank = thisTnak;
		}
		else
		{
			tank = null;
		}
	}

	public void Set(GasTank thisTnak)
	{
		if (thisTnak != null)
		{
			tank = thisTnak;
		}
		else
		{
			tank = null;
		}
	}

	public void ChangedState()
	{
		bool h = false;
		if (inButton.isOn != inPressed )
		{
			if (inButton.isOn)
			{
				if (!(other.SetInput(this)))
				{
					inButton.isOn = false;
				}

				if (outPressed)
				{
					other.SetOutput(null);
				}
			}
			else
			{
				other.SetInput(null);
            }
			inPressed = inButton.isOn;
			outPressed = outButton.isOn;
			h = true;
		}
		if(outButton.isOn != outPressed) 
		{
			if (outButton.isOn)
			{
				if (!(other.SetOutput(this)))
				{
					outButton.isOn = false;
				}

				if (inPressed)
				{
					other.SetInput(null);
				}
			}
			else
			{
				other.SetOutput(null);
			}
			inPressed = inButton.isOn;
			outPressed = outButton.isOn;
			h = true;
		}
		/*
		if(!h)
		{
			if (outPressed)
			{
				other.SetOutput(null);
			}
			if (inPressed)
			{
				other.SetInput(null);
			}
			inPressed = inButton.isOn;
			outPressed = outButton.isOn;
		}
		*/
	}

	public void SetInput(bool a)
	{
		inPressed = a;
		inButton.isOn = a;
	}

	public void SetOutput(bool a)
	{
		outPressed = a;
       outButton.isOn = a;
	}
}
