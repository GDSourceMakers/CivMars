using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class CivMarsInit
{
	public static void Init()
	{
		GameRegystry.RegisterItem("CivMars.IronIngot", new IronIngot());
        GameRegystry.RegisterItem("CivMars.IronPlate", new IronPlate());
        GameRegystry.RegisterItem("CivMars.GlassPlane", new GlassPlane());
        GameRegystry.RegisterItem("CivMars.IronPipe", new IronPipe());
        
    }
}

