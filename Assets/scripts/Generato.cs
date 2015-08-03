using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
    public class Generator:Building
    {

        public MainBuilding main;
        public int internalsorage;

        public void Gen()
        {}
        

        public void Transfer()
        {
            if (this.internalsorage > 1)
            {
                main.Inventory =+ this.internalsorage;
            }
        }
    }

