using CivMarsEngine;

namespace CivMars
{
	class GoldOre : Item, IRegystratabe
	{

        new public string name = "GoldOre";


		public GoldOre(int am) : base(am, 30)
		{
			texture = GameRegystry.GetSprite("Textures/Items/", "CivMars.GoldOre");
			maxStackSize = 30;
		}

		public GoldOre()
		{
			texture = GameRegystry.GetSprite("Texturas/Items/", "CivMars.GoldOre");
			maxStackSize = 30;
		}

		public void Regystrate()
		{
		}
	}
}