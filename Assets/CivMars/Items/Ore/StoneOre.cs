
using CivMarsEngine;

namespace CivMars
{
    class StoneOre : Item, IRegystratabe
    {

        new public string name = "StoneOre";


        public StoneOre(int am) : base(am, 30)
        {
            texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.StoneOre");
            maxStackSize = 30;
        }

        public StoneOre()
        {
            texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.StoneOre");
            maxStackSize = 30;
        }

        public void Regystrate()
        {
        }
    }
}
