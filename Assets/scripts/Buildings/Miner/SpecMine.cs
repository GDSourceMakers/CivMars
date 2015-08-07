using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

    public class SpecMine : Miner
    {
        public OreType type;
        public int capacity;

        public SpecMine(int xpos, int ypos)
            : base(xpos, ypos)
        { }
    }

