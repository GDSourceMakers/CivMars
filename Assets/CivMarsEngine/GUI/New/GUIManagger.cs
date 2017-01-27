using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using CivMarsEngine;

namespace CivMarsEngine.GUI
{
    public class GUIManagger: MonoBehaviour
    {
		GameController GameCon;

		public int CanTurnOf;
		IGUI openGui;

		public static GUIManagger instance;

		void Awake()
		{
			instance = this;
		}

		public bool HasOpendGui()
		{
			return openGui != null;
		}

		public bool OpenGUI(IGUI gui)
		{
			if (gui == null)
			{
				return false;
			}
			else if (openGui == null)
			{
				gui.Open();
				return true;
			}
			else
			{
				if (gui.ClosingLevel() > openGui.ClosingLevel())
				{
					openGui.Close();
					gui.Open();

					return true;
				}

				return false;
			}
		}

		public bool CloseGUI(IGUI gui)
		{
			if (gui == null)
			{
				return false;
			}
			else if (openGui == null)
			{
				return false;
			}
			else if (gui == openGui)
			{
				openGui.Close();
				return true;
			}
			else
			{
				if (gui.ClosingLevel() > openGui.ClosingLevel())
				{
					openGui.Close();
					return true;
				}

				return false;
			}
		}

		/*
		public void TogleAccesPanel()
		{
			guiHandler.AccesPanel.TogelGui();
		}
		*/
	}

}

/*
public class GUIManagger : MonoBehaviour
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
        GameCon = GameController.instance;
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
*/