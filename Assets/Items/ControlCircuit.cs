using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ControlCircuit : Item, IRegystratabe
{

    public string name = "ControlCircuit";


    public ControlCircuit(int am) : base(am, 30)
    {
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.ControlCircuit");
        maxStackSize = 30;
    }

    public ControlCircuit()
    {
        texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.ControlCircuit");
        maxStackSize = 30;
    }

    public void Regystrate()
    {

        Item[] a = { new IronPlate(2), new GlassPlane(5), new IronIngot(1) };
        Recipe r = new Recipe("CivMars.Press", a, new ControlCircuit(3), 100);
        GameRegystry.RegisterRecepie(r.buildingID, r);
    }
}


