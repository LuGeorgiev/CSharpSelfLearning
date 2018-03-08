using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lybirinth
{
    class Lybirinth
    {
        static char[,] lab =
        {
            {' ',' ',' ','*',' ',' ',' '},
            {'*','*',' ','*',' ','*',' '},
            {' ',' ',' ',' ',' ',' ',' '},
            {' ','*','*','*','*','*',' '},
            {' ',' ',' ',' ',' ',' ','e'},

        };

        static void FinExit(int row, int coll)
        {
            if ((coll<0)||(row<0)||(row>lab.GetLength(0)-1)||(coll>lab.GetLength(1)-1))
            {
                return;
            }
            if (lab[row,coll]=='e')
            {
                PrintPath(row,coll);
            }
            if (lab[row, coll] !=' ')
            {
                return;  
            }
            lab[row, coll] = 's';
            path.Add(new Tuple<int, int>(row, coll));

            FinExit(row, coll - 1); //Left
            FinExit(row-1, coll ); //Up
            FinExit(row, coll + 1); //right
            FinExit(row+1, coll); //down

            lab[row, coll] = ' ';  //Mark back current cell free
        }

        private static void PrintPath(int finalRow, int finalCol)
        {
            Console.Write("Found exit: ");
            foreach (var cel in path)
            {
                Console.Write("({0},{1})->", cel.Item1,cel.Item2);
            }
            Console.WriteLine();
        }
        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        static void Main(string[] args)
        {
            FinExit(0, 0);
        }
    }
}
