using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using CivMarsEngine;


namespace CivMarsEngine
{
	public class SavedMapLister : MonoBehaviour
	{

		GameController GameCon;

		public List<GameObject> desplayed = new List<GameObject>();

		public GameObject desplayPref;
		public GameObject canvas;

		public TogleGroupAdvanced togGrup;

		public Text mapName;

		/// Use this for initialization
		void Awake()
		{
			GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		}

		// Update is called once per frame
		void Update()
		{
			Toggle num = togGrup.ActiveToggle();
			if (num == null)
			{
				mapName.text = "";
			}
			else
			{

				SavedMapData.DisplayDeteals selected = GameCon.savedMaps[num.transform.GetSiblingIndex()];
				mapName.text = selected.name;
			}
		}

		public void LoadSelected()
		{
			Toggle num = togGrup.ActiveToggle();
			if (num == null)
			{
			}
			else
			{
				GameCon.mapData = GameCon.GetSavedMap(GameCon.savedMaps[num.transform.GetSiblingIndex()].path);
				StartCoroutine(GameCon.LoadLevel("Main"));
			}
		}

		public void Refresh()
		{
			GameCon.LoadMaps();

			foreach (GameObject item in desplayed)
			{
				Destroy(item);
			}

			foreach (SavedMapData.DisplayDeteals item in GameCon.savedMaps)
			{
				GameObject a = Instantiate(desplayPref);
				a.transform.SetParent(canvas.transform);
				a.transform.FindChild("Name").GetComponent<Text>().text = item.name;
				a.GetComponent<Toggle>().group = togGrup;
				desplayed.Add(a);
			}
		}

	}
}