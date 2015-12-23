
using CivMarsEngine;

namespace CivMars
{
    class CopperOre : Item, IRegystratabe
    {

        new public string name = "CopperOre";


        public CopperOre(int am) : base(am, 30)
        {
            texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.CopperOre");
            maxStackSize = 30;
        }

        public CopperOre()
        {
            texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.CopperOre");
            maxStackSize = 30;
        }

        public void Regystrate()
        {
        }
    }
}
