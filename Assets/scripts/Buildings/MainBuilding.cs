using System.Collections.Generic;

public class MainBuilding : Building
{

    public Inventory Inventory = new Inventory(20);
    

    public MainBuilding(int xpos, int ypos) :base(xpos,ypos)
    {
        base.Textura = 0;
    }
}

