using UnityEngine;
using System.Collections;

public enum AccesPanelState
{
	Inventory,
	Gas,
	Stats
}

interface IAccesTab <T>
{
	void UpdateData(T datas);
}

public class AccesPanel : MonoBehaviour
{
	public AccesPanelState state;


	public GameObject[] AccesTabs;



	public void ChangeTab<T>(AccesPanelState a, T data)
	{
		state = a;
		AccesTabs[(int)state].GetComponent<IAccesTab<T>>().UpdateData(data);
        UpdateTab();
	}

	public void ChangeTab(AccesPanelState a)
	{
		state = a;
		UpdateTab();
	}

	void UpdateTab()
	{
		for (int i = 0; i < AccesTabs.Length; i++)
		{
			if ((int)state == i)
			{
				AccesTabs[i].SetActive(true);
				
			}
			else
			{
				AccesTabs[i].SetActive(false);
			}
		}
	}

}
