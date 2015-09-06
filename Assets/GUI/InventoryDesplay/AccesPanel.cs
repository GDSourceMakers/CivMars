using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public enum AccesPanelState
{
	Inventory,
	Gas,
	Stats
}

interface IAccesTab
{
	void UpdateData(Building datas);
}

public class AccesPanel : MonoBehaviour
{


	public Building OpenBuilding;

	public AccesPanelState state;


	public GameObject[] AccesTabs;



	public void ChangeTab(AccesPanelState a, Building data)
	{
		state = a;
		OpenBuilding = data;
        UpdateTab();
	}

	public void ChangeTab(AccesPanelState a)
	{
		state = a;
		UpdateTab();
	}

	public void ChangeTab(string a)
	{
		state = (AccesPanelState)Enum.Parse(typeof(AccesPanelState), a);

		UpdateTab();
	}



	void UpdateTab()
	{
		for (int i = 0; i < AccesTabs.Length; i++)
		{
			if ((int)state == i)
			{
				AccesTabs[i].SetActive(true);
				if (AccesTabs[i].GetComponent<IAccesTab>() != null)
				{
					AccesTabs[i].GetComponent<IAccesTab>().UpdateData(OpenBuilding);
				}
				
			}
			else
			{
				AccesTabs[i].SetActive(false);
			}
		}
	}

}
