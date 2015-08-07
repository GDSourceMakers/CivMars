using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

    public class UniverzalMiner:Miner
    {
        public int capacity;
        public int speed;
        public OreType type;
    
        public UniverzalMiner(int xpos, int ypos) : base(xpos,ypos)
        {}
    }

