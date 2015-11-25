﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class IronIngot : Item, IRegystratabe
{
	public string name = "IronIngot";

	public IronIngot(int am) : base(am, 10)
	{
		texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.StealIngot");
		maxStackSize = 10;
	}

	public IronIngot()
	{
		texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.StealIngot");
		maxStackSize = 10;
	}

	public void Regystrate()
	{

		Item[] a = { new SandOre(2) };
        Recipe r = new Recipe("CivMars.Furnance", a , this,10);
		GameRegystry.RegisterRecepie(r.buildingID, r);
	}
}


