using UnityEngine;
using System.Collections;
using System.IO;

public class TerrainGen{



        public static Tile[,] Generate(float h, float reduce , int seed)
        {

            FileStream file = new FileStream("./file.txt", FileMode.Create);
            StreamWriter wf = new StreamWriter(file);

            int gen = 50;
            float[,] h2 = new float[,] { {3f, 15f}, {2f,20f}, {1f,22f}, {0.2f,30f}, {0.1f,40f}, {0.001f,45}};
            System.Random rand = new System.Random(5000);
            
            Tile[,] map = new Tile[50, 50];
            Tile initial;

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
                    initial = new Ore(rand, i, j);
                    h = h2[(int)initial.type,0];
                    reduce = h2[(int)initial.type, 1];
                    if (rand.Next(0, 100) <= h && !t)
                    {
                        map[i, j] = initial;

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


