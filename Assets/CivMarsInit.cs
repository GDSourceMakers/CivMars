using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Mod]
public static class CivMarsInit
{
	[ModInit]
	public static void Init()
	{
		GameRegystry.RegisterItem("CivMars.IronIngot", new IronIngot());
        GameRegystry.RegisterItem("CivMars.IronPlate", new IronPlate());
        GameRegystry.RegisterItem("CivMars.GlassPlane", new GlassPlane());
        GameRegystry.RegisterItem("CivMars.IronPipe", new IronPipe());
        //GameRegystry.RegisterItem("CivMars.StoneBrick", new StoneBrick());
        //GameRegystry.RegisterItem("CivMars.InteriorPlate", new InteriorPlate());
        //GameRegystry.RegisterItem("CivMars.Roof", new Roof());
    }
}

