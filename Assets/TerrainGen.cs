using UnityEngine;
using System.Collections;
using System.IO;

public class TerrainGen{



        public static Tile[,] Generate(float h, float reduce , int seed)
        {

            FileStream file = new FileStream("./file.txt", FileMode.Create);
            StreamWriter wf = new StreamWriter(file);

            int gen = 200;
            System.Random rand = new System.Random(seed);
            
            Tile[,] map = new Tile[200, 200];

            bool t = false;


            for (int i = 0; i < gen; i++)
            {
                for (int j = 0; j < gen; j++)
                {
                    map[i, j] = new Tile(OreType.Surface, i, j);
                }
            }

            for (int i = 0; i < gen; i++)
            {
                for (int j = 0; j < gen; j++)
                {
                    if (rand.Next(0, 100) <= h && !t)
                    {
                        map[i, j] = new Ore(rand, i, j);

                        map = ((Ore)map[i, j]).Spread(map, h, rand, reduce);

                        t = false;
                    }
                    if (map[i, j] != null)
                    {
                        wf.Write((int)map[i, j].type + ",");
                    }

                }
                wf.WriteLine();
            }
            wf.Close();

            return map;

        }
    }


