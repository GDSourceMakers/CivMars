using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GlassPlane:Item, IRegystratabe
{
        public string name = "GlassPlane";


    public GlassPlane(int am) : base(am, 30)
	{
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.GlassPlane");
        maxStackSize = 30;
    }

    public GlassPlane()
    {
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.GlassPlane");
        maxStackSize = 30;
    }

    public void Regystrate()
    {

        Item[] a = { new SandOre(4) };
        Recipe r = new Recipe("CivMars.Furnace", a, new GlassPlane(1), 50);
        GameRegystry.RegisterRecepie(r.buildingID, r);
    }

}

