using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	public GameObject load;
	public GameObject menu;
	public Text bar;
	public float loadProgress;

	AsyncOperation loadingmap;

	public bool loading;

	// Use this for initialization
	void Start()
	{
		loadingmap = new AsyncOperation();
	}

	// Update is called once per frame
	public void Update()
	{
		if (loading)
		{
			loadProgress = loadingmap.progress * 100;
			bar.text = loadProgress + "!!";
		}
	}

	public void StartGame()
	{
		StartCoroutine(LoadLevel("Main"));
	}

	public IEnumerator LoadLevel(string a)
	{
		load.SetActive(true);
		menu.SetActive(false);

		loading = true;

		loadingmap = Application.LoadLevelAsync(a);

		while (!loadingmap.isDone)
		{
			yield return loadingmap;
		}
	}
}
