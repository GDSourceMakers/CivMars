using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CraftingDesplay : MonoBehaviour
{

	public List<Recipe> a;
	public string buildingID;

	public GameObject RecipeListCanvas;
	public GameObject RecipeMaterialsCanvas;
	public GameObject QueueCanvas;
	public Image RecipeIcon;
	public Text RecipeText;

	public List<GameObject> recipesDesplayed;
	public List<GameObject> queueDesplayed;

	public GameObject recipeDesplayPref;
	public GameObject queueItemPref;

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

		for (int i = 0; i < k.Length; i++)
		{
			if (i == queueDesplayed.Count)
			{
				queueDesplayed.Add(Instantiate(queueItemPref));
				queueDesplayed[i].transform.FindChild("Slider").GetComponent<Slider>().maxValue = k[i].recipe.time;
				queueDesplayed[i].transform.FindChild("Slider").GetComponent<Slider>().value = k[i].status;
				queueDesplayed[i].transform.FindChild("Image").GetComponent<Image>().sprite = k[i].recipe.Crafted.texture;
				queueDesplayed[i].transform.SetParent(QueueCanvas.transform);
			}
			else
			{
				queueDesplayed[i].transform.FindChild("Slider").GetComponent<Slider>().maxValue = k[i].recipe.time;
				queueDesplayed[i].transform.FindChild("Slider").GetComponent<Slider>().value = k[i].status;
				queueDesplayed[i].transform.FindChild("Image").GetComponent<Image>().sprite = k[i].recipe.Crafted.texture;
			}
		}

		for (int i = k.Length; i < queueDesplayed.Count - k.Length; i++)
		{
			Destroy(queueDesplayed[i]);
		}

	}

	public void ChangeDetealsTab(int i)
	{
		if (i == -1)
		{
			RecipeIcon.sprite = null;
			RecipeText.text = "";
		}
		else
		{
			RecipeIcon.sprite = a[i].Crafted.texture;
			RecipeText.text = a[i].Crafted.ToString();
		}
	}

	public void AddToQueue(int i)
	{
		crafter.AddToQueue(i);
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

			a = GameRegystry.recepies[buildingID];

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
