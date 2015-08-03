using UnityEngine;
using System.Collections;

public abstract class Language
{


    static public string[,] Names =
    {
    {"CoalOre","Coal Ore"},
    {"StoneOre","Stone"},
    {"SandOre","Sand"},
    {"IronOre","Iron Ore"},
    {"UraniumOre","Uran Ore"},
    {"CoalOre","Coal Ore"},
    {"CoalOre","Coal Ore"}
    };

    public static string Get(System.Object itemObject)
    {
        string name = "Unlocalized Name";

        for (int i = 0; i < 7; i++)
	    {
        
            if (Names[i,0] == itemObject.GetType().ToString())
            {
                name = Names[i, 1];
            }
        }

        if (name == "Unlocalized Name")
            Debug.LogError("Cant find: " + itemObject.GetType().ToString());
        return name;
    }
}
