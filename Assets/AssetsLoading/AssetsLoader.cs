using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetsLoader : MonoBehaviour
{

	public void CallRegister()
	{
		GameObject[] goBuild = Resources.LoadAll<GameObject>("Buildings");

		foreach (GameObject item in goBuild)
		{
			IRegystratabe a = item.GetComponent<IRegystratabe>();

			if (a != null)
			{
				//Debug.Log(item.name);
				a.Regystrate();
			}
		}

		GameObject[] goTiles = Resources.LoadAll<GameObject>("GeneratedTiles");

		foreach (GameObject item in goTiles)
		{
			IRegystratabe a = item.GetComponent<IRegystratabe>();

			if (a != null)
			{
				//Debug.Log(item.name);
				a.Regystrate();
			}
		}

		CivMarsInit.Init();
		/*
		for (int i = 0; i < length; i++)
		{
			xasd.y = (total * (Scrollbar / 100)) + (total - xasd.height);
		}
		*/
	}

}

