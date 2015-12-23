using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;
using UnityEngine;

class Wood : Item
{

    new public string name = "Wood";


    public Wood(int am) : base(am, 10)
    {
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.Wood");
        maxStackSize = 10;
    }

    public Wood()
    {
        texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.Wood");
        maxStackSize = 10;
    }


}