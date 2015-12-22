using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CivMarsEngine
{
	class SpaceSuit : IGasTank
	{
		static float[] maxs = { 200f, 200f };
		GasTankCluster tanks = new GasTankCluster(2, maxs);

		public GasTankCluster GetTankCluster()
		{
			return tanks;
		}
	}
}