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
            int qpoints = 6, pos = 0, endpos = 4, pathnow = 0, beg = 0;
            int[] minpath = { 0, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };
            int[,] lines =
            {  /* 1  2  3  4  5  6 */
                { 0, 2, 3, 0, 0, 4 },//1
                { 2, 0, 2, 6, 0, 0 },//2
                { 3, 2, 0, 3, 0, 5 },//3
                { 0, 6, 3, 0, 4, 0 },//4
                { 0, 0, 0, 4, 0, 1 },//5
                { 4, 0, 5, 0, 1, 0 } //6
            };
            //for(int i = 0; i < qpoints; i++)
            do
            {

                for (int j = 0; j < qpoints; j++)
                {
                    if (lines[pos, j] != 0)
                        if (lines[pos, j] + pathnow < minpath[j])
                            minpath[j] = lines[pos, j];
                }
                pos++;
                int tmp = 1;
                foreach (int c in minpath)
                    Console.WriteLine($"{tmp} - " + c, tmp++);
                break;
            } while (true);
            Console.ReadKey();
        }
    }
}
