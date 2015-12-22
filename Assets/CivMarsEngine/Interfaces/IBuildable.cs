using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace CivMarsEngine
{
	public interface IBuildable
	{
		float GetBuildtime();

		Sprite GetImage();

		GameObject GetPrefab();

		Image GetBuildedState();

		Item[] GetNeededMaterials();

		void Setup();
	}
}