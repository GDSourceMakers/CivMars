using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace BasicUtility
{
    public class TogleGroupAdvanced : ToggleGroup
    {
        public Toggle ActiveToggle()
        {
            int a = ActiveToggles().Count();

            for (int i = 0; i < a; i++)
            {

            }

            IEnumerator<Toggle> g = ActiveToggles().GetEnumerator();
            g.MoveNext();
            Toggle d = g.Current;

            return d;
        }
    }

}