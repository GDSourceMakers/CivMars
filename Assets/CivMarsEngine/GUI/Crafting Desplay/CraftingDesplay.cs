using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CivMarsEngine.Registry;

namespace CivMarsEngine
{
	public class CraftingDesplay : MonoBehaviour
	{
		public List<Recipe> recipes;
		public string buildingID;

		public GameObject RecipeListCanvas;
		public GameObject RecipeMaterialsCanvas;
		public GameObject QueueCanvas;
		public GameObject QueueMaterialsCanvas;
		public Image RecipeIcon;
		public Text RecipeText;

		public List<GameObject> recipesDesplayed;
		public List<GameObject> recepiesDetealdMaterials;
		public List<GameObject> queueDesplayed;
		public List<GameObject> queueMaterialDesplayed;

		public GameObject recipeDesplayPref;
		public GameObject queueItemPref;
		public GameObject queueMaterialItemPref;

		public ICrafter crafter;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			UpdateQueue();
		}

		void UpdateQueue()
		{
			CraftingProcess[] k = crafter.GetQueue();

			#region Queue
			for (int i = 0; i < k.Length; i++)
			{
				if (i == queueDesplayed.Count)
				{
					queueDesplayed.Add(Instantiate(queueItemPref));
					queueDesplayed[i].GetComponent<QueueItem>().Set(k[i].recipe.time, k[i].status, k[i].recipe.Crafted.texture, this);
					queueDesplayed[i].transform.SetParent(QueueCanvas.transform);
				}
				else
				{
					queueDesplayed[i].GetComponent<QueueItem>().Set(k[i].recipe.time, k[i].status, k[i].recipe.Crafted.texture, this);
				}
			}

			for (int i = k.Length; i < queueDesplayed.Count; i++)
			{
				Destroy(queueDesplayed[i]);
				queueDesplayed.RemoveAt(i);
			}
			#endregion

			#region Queue Material;
			if (k.Length > 0)
			{

				for (int i = 0; i < k[0].recipe.Materials.Length; i++)
				{
					if (i == queueMaterialDesplayed.Count)
					{
						queueMaterialDesplayed.Add(Instantiate(queueMaterialItemPref));
						queueMaterialDesplayed[i].transform.FindChild("Image").GetComponent<Image>().sprite = k[0].recipe.Materials[i].texture;
						queueMaterialDesplayed[i].transform.FindChild("Text").GetComponent<Text>().text = k[0].recipe.Materials[i].amount - k[0].materials[i] + "/" + k[0].recipe.Materials[i].amount;
						queueMaterialDesplayed[i].transform.SetParent(QueueMaterialsCanvas.transform);
					}
					else
					{
						queueMaterialDesplayed[i].transform.FindChild("Image").GetComponent<Image>().sprite = k[0].recipe.Materials[i].texture;
						queueMaterialDesplayed[i].transform.FindChild("Text").GetComponent<Text>().text = k[0].recipe.Materials[i].amount - k[0].materials[i] + "/" + k[0].recipe.Materials[i].amount;
					}
				}

				for (int i = k.Length; i < queueMaterialDesplayed.Count; i++)
				{
					Destroy(queueMaterialDesplayed[i]);
					queueMaterialDesplayed.RemoveAt(i);
				}
			}
			#endregion


		}

		public void ChangeDetealsTab(int i)
		{
			if (i == -1)
			{
				RecipeIcon.sprite = null;
				RecipeText.text = "";
				for (int j = 0; j < recepiesDetealdMaterials.Count; j++)
				{
					recepiesDetealdMaterials[j].SetActive(false);
				}
			}
			else
			{
				RecipeIcon.sprite = recipes[i].Crafted.texture;
				RecipeText.text = recipes[i].Crafted.ToString();

				for (int j = 0; j < recepiesDetealdMaterials.Count; j++)
				{
					if (j == recipes[j].Materials.Length)
					{
						recepiesDetealdMaterials[j].SetActive(false);
					}
					else
					{
						recepiesDetealdMaterials[j].SetActive(true);
						recepiesDetealdMaterials[j].transform.FindChild("Image").GetComponent<Image>().sprite = recipes[i].Materials[j].texture;
						recepiesDetealdMaterials[j].transform.FindChild("Text").GetComponent<Text>().text = recipes[i].Materials[j].amount.ToString();
						Debug.Log(recipes[i].Materials[j].amount.ToString());

					}
				}

				for (int j = recepiesDetealdMaterials.Count; j < recipes[i].Materials.Length; j++)
				{
					recepiesDetealdMaterials.Add(Instantiate(queueMaterialItemPref));
					recepiesDetealdMaterials[j].transform.SetParent(RecipeMaterialsCanvas.transform);
					recepiesDetealdMaterials[j].transform.FindChild("Image").GetComponent<Image>().sprite = recipes[i].Materials[j].texture;
					recepiesDetealdMaterials[j].transform.FindChild("Text").GetComponent<Text>().text = recipes[i].Materials[j].amount.ToString();

				}
			}

		}

		public void AddToQueue(int i)
		{
			crafter.AddToQueue(i);
		}

		public void RemoveFromQueue(int i)
		{
			crafter.RemoveFromQueue(i);
		}

		public void SetBuilding(ICrafter b)
		{
			for (int i = 0; i < queueDesplayed.Count; i++)
			{
				Destroy(queueDesplayed[i]);
				queueDesplayed.RemoveAt(i);
			}

			for (int i = 0; i < recipesDesplayed.Count; i++)
			{
				Destroy(recipesDesplayed[i]);
			}

			recipesDesplayed = new List<GameObject>();

			if (b != null)
			{
				recipesDesplayed = new List<GameObject>();
				buildingID = b.GetCraftingID();
				crafter = b;

				recipes = GameRegystry.recepies[buildingID];

				foreach (Recipe item in GameRegystry.recepies[buildingID])
				{
					GameObject current = Instantiate(recipeDesplayPref);
					recipesDesplayed.Add(current);
					current.transform.FindChild("Image").GetComponent<Image>().sprite = item.Crafted.texture;
					current.transform.SetParent(RecipeListCanvas.transform);
					current.GetComponent<RecipeButton>().parent = this;
				}
			}
		}

	}
}