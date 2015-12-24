using UnityEngine;
using System.Collections;
using System;
using CivMarsEngine;

namespace CivMars
{
	public class StoneOreTile : OreTile
	{
        new public string ID = CivMarsInit.BlockSpace + ".SandOre";

		static Type item = typeof(StoneOre);

		override public void Regystrate()
		{
			chanche = 300;
			chanche2 = 7000;
			chancheReduce = 500;
			distance = -1;
			GameRegystry.RegisterWorldGen(ID, this);
		}

		public override void Generate(System.Random r, TileMap map)
		{
			base.Generate(r, map);
		}

		public override float GetMiningTime()
		{
			return 4.5f;
		}

		public override Type GetItemType()
		{
			return item;
		}

		public override bool Mine(int remAmount)
		{
			amount -= remAmount;
			if (amount <= 0)
			{
				transform.tileMap.RemoveTile(transform.position);
				return true;
			}
			return false;
		}

		public override float GetAmountLeft()
		{
			return amount;
		}

	}
}