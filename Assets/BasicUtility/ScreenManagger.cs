using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace BasicUtility
{
    public class ScreenManagger : MonoBehaviour
    {

        public List<ScreenState> States;

        //public Dictionary<string,ScreenState> States2;

        public void SetState(string Name)
        {
            foreach (ScreenState item in States)
            {
                if (item.name == Name)
                {
                    item.SetState();
                }
            }

        }

    }

    [System.Serializable]
    public class ScreenState
    {
        public string name;
        public UnityEvent events;

        public void SetState()
        {
            events.Invoke();
        }
    }
}