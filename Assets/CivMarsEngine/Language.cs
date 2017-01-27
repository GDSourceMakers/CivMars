using UnityEngine;
using System.Collections;

namespace CivMarsEngine
{
    public abstract class Language
    {


        static public string[,] Names =
        {
    {"CoalOre",         "Coal Ore",         "szén érc"  },
    {"StoneOre",        "Stone",            "kő"        },
    {"SandOre",         "Sand",             "homok"     },
    {"IronOre",         "Iron Ore",         "vas érc"   },
    {"UraniumOre",      "Uran Ore",         "urán érc"  },
    {"IronIngot",       "Iron Ingot",       ""          },
    {"CoalOre",         "Coal Ore",         ""          }
    };

        //TODO: Change to directory
        public static string Get(System.Object itemObject, int language)
        {
            string name = "Unlocalized Name";

            for (int i = 0; i < 7; i++)
            {

                if (Names[i, 0] == itemObject.GetType().ToString())
                {
                    if (language == 2)
                    {
                        name = Names[i, 0];
                        break;
                    }
                    name = Names[i, language + 1];
                }
            }

            if (name == "Unlocalized Name")
                Debug.LogError("Cant find: " + itemObject.GetType().ToString());
            return name;
        }
    }
}