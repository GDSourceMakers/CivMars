using System;
using System.Collections.Generic;
using BasicUtility.TileMap;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CivMarsEngine
{

	[AddComponentMenu("Buildings/Building")]
	public class Building : Tile, ISaveble
	{

		public GameObject graphics;
		public bool guion;
		public GameController GameCon;

		public void Awake()
		{
			//base.Awake();
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