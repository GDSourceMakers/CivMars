
using CivMarsEngine;

namespace CivMars
{
    class IronOre : Item, IRegystratabe
    {

        new public string name = "IronOre";


        public IronOre(int am) : base(am, 30)
        {
            texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.IronOre");
            maxStackSize = 30;
        }

        public IronOre()
        {
            texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.IronOre");
            maxStackSize = 30;
        }

        public void Regystrate()
        {
        }
    }
}
