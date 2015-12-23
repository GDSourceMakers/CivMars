
using CivMarsEngine;

namespace CivMars
{
    class SandOre : Item, IRegystratabe
    {

        new public string name = "SandOre";


        public SandOre(int am) : base(am, 30)
        {
            texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.SandOre");
            maxStackSize = 30;
        }

        public SandOre()
        {
            texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.SandOre");
            maxStackSize = 30;
        }

        public void Regystrate()
        {
        }
    }
}
