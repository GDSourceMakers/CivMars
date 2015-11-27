using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class IronPlate:Item, IRegystratabe
{
        public string name = "IronPlate";

    public IronPlate(int am) : base(am, 10)
	{
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.IronPlate");
        maxStackSize = 10;
    }

    public IronPlate()
    {
        texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.IronPlate");
        maxStackSize = 10;
    }

    public void Regystrate()
    {

        Item[] a = { new IronIngot(1) };
        Recipe r = new Recipe("CivMars.Press", a, new IronPlate(2) , 30);
        GameRegystry.RegisterRecepie(r.buildingID, r);
    }
}
