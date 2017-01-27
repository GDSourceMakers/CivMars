using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivMarsEngine.Registry
{
    [AttributeUsage(AttributeTargets.Class)]
    class ModAttribute : Attribute
    {

    }


    [AttributeUsage(AttributeTargets.Method)]
    class ModInitAttribute : Attribute
    {

    }
}