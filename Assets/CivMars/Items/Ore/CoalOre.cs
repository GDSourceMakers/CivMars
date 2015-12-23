
using CivMarsEngine;

namespace CivMars
{
    class CoalOre : Item, IRegystratabe
    {

        new public string name = "CoalOre";


        public CoalOre(int am) : base(am, 30)
        {
            texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.CoalOre");
            maxStackSize = 30;
        }

        public CoalOre()
        {
            texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.CoalOre");
            maxStackSize = 30;
        }

        public void Regystrate()
        {
        }
    }
}
