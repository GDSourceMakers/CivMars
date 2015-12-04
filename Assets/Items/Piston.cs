using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Piston : Item, IRegystratabe
{

    public string name = "Piston";


    public Piston(int am) : base(am, 30)
    {
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.Piston");
        maxStackSize = 30;
    }

    public Piston()
    {
        texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.Piston");
        maxStackSize = 30;
    }

    public void Regystrate()
    {

        Item[] a = { new IronPlate(2), new IronIngot(1), new ControlCircuit(1) };
        Recipe r = new Recipe("CivMars.Press", a, new Piston(1), 150);
        GameRegystry.RegisterRecepie(r.buildingID, r);
    }
}
