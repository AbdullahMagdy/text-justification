using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_algorithm
{
    class TextJustification
    {
        public String justify(String[] words, int width, ref double minbadness, ref int num_line,
             ref int size_arr)
        {
            long x1 = words.Count();
            int[] arr_to = new int[x1];
            long[,] cost = new long[x1, x1];

            /*
             next 2 for loop is used to calculate cost of putting words from
            i to j in one line. If words don't fit in one line then we put
            Integer.MAX_VALUE there.
             */
            for (int i = 0; i < words.Count(); i++)
            {
                cost[i, i] = width - words[i].Length;
                for (int j = i + 1; j < words.Count(); j++)
                {

                    cost[i, j] = cost[i, j - 1] - words[j].Length - 1;

                }

            }

            for (int i = 0; i < words.Count(); i++)
            {
                for (int j = i; j < words.Count(); j++)
                {
                    if (cost[i, j] < 0)
                    {
                        cost[i, j] = Int32.MaxValue;
                    }
                    else
                    {
                        cost[i, j] = (int)Math.Pow(cost[i, j], 3);

                    }
                }

            }


            num_line = 0;
            //minCost from i to len is found by trying
            //j between i to len and checking which
            //one has min value
            long[] minCost = new long[words.Count()];
            long[] result = new long[words.Count()];
            for (int i = words.Count() - 1; i >= 0; i--)
            {
                minCost[i] = cost[i, words.Count() - 1];
                result[i] = words.Count();

                for (int j = words.Count() - 1; j > i; j--)
                {
                    if (cost[i, j - 1] == Int32.MaxValue)
                    {
                        continue;
                    }
                    if (minCost[i] > minCost[j] + cost[i, j - 1])
                    {
                        minCost[i] = minCost[j] + cost[i, j - 1];
                        result[i] = j;


                    }
                }
            }


            size_arr = minCost.Length;



            /*   Console.WriteLine("Minimum cost is " + minCost[0]);
               minbadness = minCost[0];*/
            double mini = 0;
            minbadness = 0;

            long x = 0;
            long y;
            StringBuilder builder = new StringBuilder();
            do
            {
                y = result[x];
                for (long k = x; k < y; k++)
                {
                    builder.Append(words[k] + " ");
                    mini += (double)minCost[k];
                }
                minbadness += mini;
                mini = 0;
                builder.Append("\n");
                num_line++;
                x = y;

            } while (y < words.Length);





            return builder.ToString();



        }
    }
}

