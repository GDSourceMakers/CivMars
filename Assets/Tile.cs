
public class Tile
{
    public OreType type;
    public int x, y;
    public Tile(OreType t, int xpos, int ypos)
    {
        this.type = t;
        this.x = xpos;
        this.y = ypos;
    }

    public Tile(int xpos, int ypos)
    {
        this.x = xpos;
        this.y = ypos;
    }


}
