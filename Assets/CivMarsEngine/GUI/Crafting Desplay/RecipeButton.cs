using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;


namespace CivMarsEngine
{
	public class RecipeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
	{

		public CraftingDesplay parent;

		// Use this for initialization
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			parent.ChangeDetealsTab(transform.GetSiblingIndex());
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			parent.ChangeDetealsTab(-1);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			parent.AddToQueue(transform.GetSiblingIndex());
		}
	}

}