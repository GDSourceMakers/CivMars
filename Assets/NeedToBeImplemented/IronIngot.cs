using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class IronIngot : Item, IRegystratabe
{
	public string name = "IronIngot";



	public void Regystrate()
	{
		Item[] a = { new IronOre(2) };
        Recipe r = new Recipe("CivMars.Furnance", a , this);
		GameRegystry.RegisterRecepie(r.buildingID, r);
	}
}

