using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CivMarsEngine;

namespace CivMarsEngine.GUI
{
	public class NewMap : MonoBehaviour
	{
		GameController GameCon;

		public InputField nameField;
		public InputField seedField;

		// Use this for initialization
		void Start()
		{
			GameCon = GameController.instance;
		}

		public void CreateMap()
		{
			SavedMapData map = new SavedMapData(int.Parse(seedField.text), nameField.text);

			GameCon.mapData = map;

			GameCon.StartGame();
		}
	}
}