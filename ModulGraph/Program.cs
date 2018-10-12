using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 6, minindex, min, end = 4;
            int[]
                minpath = { 0, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue },
                path = { 1, 1, 1, 1, 1, 1 },
                way = new int[size];
            int[,] lines =
            {  /* 1  2  3  4  5  6 */
                { 0, 2, 3, 0, 0, 4 },//1
                { 2, 0, 2, 6, 0, 0 },//2
                { 3, 2, 0, 3, 0, 5 },//3
                { 0, 6, 3, 0, 4, 0 },//4
                { 0, 0, 0, 4, 0, 1 },//5
                { 4, 0, 5, 0, 1, 0 } //6
            };
            Console.WriteLine("Таблица связей:");
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                    Console.Write($"{lines[i, j],4}");
                Console.WriteLine();
            }
            do
            {
                minindex = int.MaxValue;
                min = int.MaxValue;
                for (int i = 0; i < size; i++)
                {
                    if (path[i] == 1 && minpath[i] < min)
                    {
                        min = minpath[i];
                        minindex = i;
                    }
                }
                if (minindex != int.MaxValue)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (lines[minindex, i] > 0)
                        {
                            int tmp = min + lines[minindex, i];
                            if (tmp < minpath[i])
                                minpath[i] = tmp;
                        }
                    }
                    path[minindex] = 0;
                }
            } while (minindex < int.MaxValue);

            Console.WriteLine("\nКратчайшие пути:");
            for (int i = 0; i < size; i++)
                Console.Write($"{minpath[i], 4}");

            way[0] = end + 1;
            int p = 1, val = minpath[end];
            while(end > 0)
            {
                for (int i = 0; i < size; i++)
                    if (lines[end, i] != 0)
                    {
                        int tmp = val - lines[end, i];
                        if(tmp == minpath[i])
                        {
                            val = tmp;
                            end = i;
                            way[p] = i + 1;
                            p++;
                        }
                    }
            }

            Console.WriteLine("\n\nПуть до конечной точки");
            for (int i = p - 1; i >= 0; i--)
                Console.Write($"{way[i],4}");

            Console.ReadKey();
        }
    }
}
