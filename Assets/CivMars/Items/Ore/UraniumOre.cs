
using CivMarsEngine;

namespace CivMars
{
    class UraniumOre : Item, IRegystratabe
    {

        new public string name = "UraniumOre";


        public UraniumOre(int am) : base(am, 30)
        {
            texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.UraniumOre");
            maxStackSize = 30;
        }

        public UraniumOre()
        {
            texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.UraniumOre");
            maxStackSize = 30;
        }

        public void Regystrate()
        {
        }
    }
}
