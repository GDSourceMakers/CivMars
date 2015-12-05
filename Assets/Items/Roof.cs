using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Roof : Item
{
    public string name = "Roof";


    public Roof(int am) : base(am, 3)
    {
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.Roof");
        maxStackSize = 3;
    }

    public Roof()
    {
        texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.Roof");
        maxStackSize = 3;
    }

    public void Regystrate()
    {

        Item[] a = { new IronPlate(10), new GlassPlane(5), new StoneBrick(50) };
        Recipe r = new Recipe("CivMars.Furnace", a, new Roof(1), 200);
        GameRegystry.RegisterRecepie(r.buildingID, r);
    }
}