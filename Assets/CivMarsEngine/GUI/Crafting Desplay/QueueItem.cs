using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace CivMarsEngine
{
	public class QueueItem : MonoBehaviour
	{

		public CraftingDesplay parent;

		public Slider slider;
		public Image image;

		/*	
		// Use this for initialization
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{

		}
		*/

		public void Set(float max, float t, Sprite texture, CraftingDesplay p)
		{
			slider.maxValue = max;
			slider.value = t;
			image.sprite = texture;
			parent = p;
		}

		public void Remove()
		{
			parent.RemoveFromQueue(transform.GetSiblingIndex());
		}
	}
}