﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CivMarsEngine
{

	[AddComponentMenu("Buildings/Building")]
	public class Building : Tiled, ISaveble
	{
		public string ID;

		//public List<Item> buildingMaterials;

		public GameObject Graphicks;
		public bool guion;

		public override void Awake()
		{
			base.Awake();
		}

		public void PositionUpdate()
		{
			Graphicks.SetActive(false);
			this.Graphicks.transform.position = Vector3.zero;
		}

		

		#region ISaveble

		public virtual SavedTile Save()
		{
			SavedTile s = new SavedTile(ID);
			return s;
		}

		public void Load(SavedTile data)
		{
			throw new NotImplementedException();
		}

		public virtual GameObject GetPrefab()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}