using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        //static char[][] room;
        static void Main()
        {
            char[][]room = CreateRoome();           

            var samMoves = Console.ReadLine().ToCharArray();
            int[] samRowCol = FindSam(room);
                
            for (int i = 0; i < samMoves.Length; i++)
            {
                room = EnemyMoves(room);

                int[] enemyOnSamRow = FindTheEnemy(room, samRowCol);

                bool samIsLeftOnD = samRowCol[1] < enemyOnSamRow[1] 
                    && room[enemyOnSamRow[0]][enemyOnSamRow[1]] == 'd' 
                    && enemyOnSamRow[0] == samRowCol[0];
                bool samIsRightonB = enemyOnSamRow[1] < samRowCol[1]
                    && room[enemyOnSamRow[0]][enemyOnSamRow[1]] == 'b' 
                    && enemyOnSamRow[0] == samRowCol[0];
                if (samIsLeftOnD)
                {
                    room[samRowCol[0]][samRowCol[1]] = 'X';
                    Console.WriteLine($"Sam died at {samRowCol[0]}, {samRowCol[1]}");
                    PrintRoomFinalState(room);
                    
                    break;
                }
                else if (samIsRightonB)
                {
                    room[samRowCol[0]][samRowCol[1]] = 'X';
                    Console.WriteLine($"Sam died at {samRowCol[0]}, {samRowCol[1]}");
                    PrintRoomFinalState(room);
                    break;
                }

                room = SamNextMove(room, samRowCol,samMoves[i]);
                enemyOnSamRow = FindTheEnemy(room, samRowCol);
                bool isNikoladzeReached = room[enemyOnSamRow[0]][enemyOnSamRow[1]] == 'N' 
                    && samRowCol[0] == enemyOnSamRow[0];

                if (isNikoladzeReached)
                {
                    room[enemyOnSamRow[0]][enemyOnSamRow[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintRoomFinalState(room);
                    break;
                }
            }
        }

        private static char[][] SamNextMove(char[][] room, int[] samRowCol, char samMoves)
        {
            room[samRowCol[0]][samRowCol[1]] = '.';
            switch (samMoves)
            {
                case 'U':
                    samRowCol[0]--;
                    break;
                case 'D':
                    samRowCol[0]++;
                    break;
                case 'L':
                    samRowCol[1]--;
                    break;
                case 'R':
                    samRowCol[1]++;
                    break;
                default:
                    break;
            }
            room[samRowCol[0]][samRowCol[1]] = 'S';
            return room;
        }

        private static void PrintRoomFinalState(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static int[] FindTheEnemy(char[][] room, int[] samRowCol)
        {
            var enemyOnSamRow =new int[2];
            for (int j = 0; j < room[samRowCol[0]].Length; j++)
            {
                if (room[samRowCol[0]][j] != '.' && room[samRowCol[0]][j] != 'S')
                {
                    enemyOnSamRow[0] = samRowCol[0];
                    enemyOnSamRow[1] = j;
                }
            }
            return enemyOnSamRow;
        }

        private static char[][] EnemyMoves(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        bool canMoveRight = col + 1 < room[row].Length;
                        if (canMoveRight)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        bool canMoveLeft = col - 1 >= 0;
                        if (canMoveLeft)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
            return room;
        }

        private static int[] FindSam(char[][] room)
        {
            var samRowCol = new int[2];

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samRowCol[0] = row;
                        samRowCol[1] = col;
                    }
                }
            }
            return samRowCol;
        }

        private static char[][] CreateRoome()
        {
            int n = int.Parse(Console.ReadLine());
            char[][]room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
            return room;
        }
    }
}
