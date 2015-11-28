using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Wood : Item
{

    public Wood(int am) : base(am)
    {
        maxStackSize = 4;
    }

    public Wood()
    {
        maxStackSize = 4;
    }


}