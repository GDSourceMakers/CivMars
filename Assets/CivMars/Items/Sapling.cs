using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivMarsEngine;
using UnityEngine;

class Sapling : Item
{

    public string name = "Sapling";


    public Sapling(int am) : base(am, 30)
    {
        texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.Sapling");
        maxStackSize = 30;
    }

    public Sapling()
    {
        texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.Sapling");
        maxStackSize = 30;
    }


}