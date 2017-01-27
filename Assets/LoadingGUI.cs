using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CivMarsEngine
{
    public class LoadingGUI : MonoBehaviour
    {

        GameController GameCon;

        public Slider bar;
        public GameObject panel;

        // Use this for initialization
        void Start()
        {
            GameCon = GameController.instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameCon.load != null && !GameCon.load.isDone)
            {
                panel.SetActive(true);
                bar.value = GameCon.load.progress;
            }
            else
            {
                panel.SetActive(false);
            }

        }
    }
}