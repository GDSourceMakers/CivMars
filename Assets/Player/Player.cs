using System;
using System.Collections.Generic;
using UnityEngine;



    public class Player : MonoBehaviour
    {
        public GameController GameCon;



        public Inventory Inventory = new Inventory(10);

        public int eatSpeed;
        public int breathAmount;
        public int speed;

        public void Start()
        {
            GameCon = GameObject.Find("_GameController").GetComponent<GameController>();

        }



        public void Eat()
        {
            throw new System.NotImplementedException();
        }

        public void Breath()
        {
            throw new System.NotImplementedException();
        }

        public void walk()
        {
            throw new System.NotImplementedException();
        }

        public void Mine()
        {

            Item mined;
            Vector2 pos = new Vector2(-1 * (int)Mathf.Round(transform.position.y * 10) / 10, (int)Mathf.Round(transform.position.x * 10) / 10);


            GeneratedTile ore = ((GeneratedTile)GameCon.map.mapGenerated[(int)pos.x, (int)pos.y]);

            if (ore.GetType() == typeof(OreTile))
            {



                ((OreTile)ore).amount -= 1;
                mined = (((Item)Activator.CreateInstance(null, ore.type.ToString() + "Ore").Unwrap()));
                mined.amount = 1;
                Inventory.Add(mined);
                GameCon.guiHandler.InventoryDisplay.UpdateInventory();
                Debug.Log(((OreTile)ore).amount);

                if (((OreTile)ore).Mine(1))
                {
                    Debug.Log("Out Mined");
                    MapLoad.MapUpdate((int)pos.x, (int)pos.y, GameCon.map);
                }
            }


        }

        public void MineStar()
        {
            Vector2 pos = new Vector2(-1 * (int)Mathf.Round(transform.position.y * 10) / 10, (int)Mathf.Round(transform.position.x * 10) / 10);


            GeneratedTile ore = ((GeneratedTile)GameCon.map.mapGenerated[(int)pos.x, (int)pos.y]);

            if (ore.GetType() == typeof(OreTile))
            {
                Debug.Log("asd");
                 GameCon.guiHandler.actions[0].Action(((OreTile)ore).miningTime[(int)ore.type], "Mine");
                 Debug.Log("asd2");
            }
        }

    }

