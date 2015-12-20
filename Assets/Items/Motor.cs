using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Motor : Item, IRegystratabe
{

    public string name = "Motor";


    public Motor(int am) : base(am, 30)
    {
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.Motor");
        maxStackSize = 30;
    }

    public Motor()
    {
        texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.Motor");
        maxStackSize = 30;
    }

    public void Regystrate()
    {

        Item[] a = { new IronIngot(6), new IronPipe(2)};
        Recipe r = new Recipe("CivMars.Furnace", a, new Motor(1), 100);
        GameRegystry.RegisterRecepie(r.buildingID, r);
    }
}