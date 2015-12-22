using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine
{
	interface ISaveble
	{
		SavedTile Save();

		void Load(SavedTile data);

		GameObject GetPrefab();
	}
}