using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;

namespace CivMars
{
	class CoalOreTile : OreTile
	{
		public new string ID = CivMarsInit.BlockSpace + ".CoalOre";

		static Type item = typeof(CoalOre);


		public override void Generate(System.Random r, TileMap map)
		{
			base.Generate(r, map);
		}


		override public void Regystrate()
		{
			base.ID = this.ID;

			chanche = 0;
			chanche2 = 250;
			chancheReduce = 5;
			distance = -1;


			GameRegystry.RegisterWorldGen(ID, this);
		}

		public override float GetMiningTime()
		{
			return 5f;
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