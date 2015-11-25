using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class CivMarsInit
{
	public static void Init()
	{
		GameRegystry.RegisterItem("CivMars.IronIngot", new IronIngot());
	}
}

