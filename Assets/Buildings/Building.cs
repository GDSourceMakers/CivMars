using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("Buildings/Building")]
public class Building : Tiled, IHasGui, IPointerClickHandler, ISaveble
{
	public string ID;

	public List<Item> buildingMaterials;

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

	#region IhasGui
	public void TogelGui()
	{
		if (!guion)
		{
			if (GameCon.AlloweGUI(this as IHasGui))
			{
				Open();
			}
		}
		else
		{
			GameCon.CloseGUI(this as IHasGui);
			Close();
		}
	}

	public virtual void Open()
	{
		guion = true;
		Graphicks.SetActive(true);
	}

	public virtual void Close()
	{
		guion = false;
		Graphicks.SetActive(false);
	}

	public int ClosingLevel()
	{
		return 1;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!eventData.rawPointerPress.transform.IsChildOf(Graphicks.transform))
			TogelGui();
	}
	#endregion

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

	public GameObject GetPrefab()
	{
		throw new NotImplementedException();
	}
	#endregion
}