using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace civmain
{
    public class Generator:Building
    {

        public MainBuilding main;
        public int a;

        public void Gen()
        {}
        

        public void Transfer()
        {
            if (this.a > 1)
            {
                main.Inventory =+ this.a;
            }
        }
    }
}
