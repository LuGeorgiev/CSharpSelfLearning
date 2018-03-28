using System;
using System.Linq;

namespace RubiksMartix
{
    class RubiksMatrix
    {

        static void Main(string[] args)
        {
            var matrixDiemnsions = Console.ReadLine()
                .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var row = matrixDiemnsions[0];
            var col = matrixDiemnsions[1];
            int[,] matrix = new int[row, col];
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
            counter = 0;

            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var currentCommandLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var rowOrCol = int.Parse(currentCommandLine[0]);
                var command = currentCommandLine[1];
                var step = int.Parse(currentCommandLine[2]);
                if (command=="up")
                {
                    var collToSfift = rowOrCol;
                    var currentStep = step % matrix.GetLength(0);
                    for (int k = 0; k < currentStep; k++)
                    {
                        var temp = matrix[0, collToSfift];
                        for (int j = 0; j < matrix.GetLength(0)-1; j++)
                        {
                            matrix[j, collToSfift] = matrix[j + 1, collToSfift];
                        }
                        matrix[matrix.GetLength(0) - 1, collToSfift] = temp;
                    }
                }
                else if (command == "down")
                {
                    var collToSfift = rowOrCol;
                    var currentStep = step % matrix.GetLength(0);
                    for (int k = 0; k < currentStep; k++)
                    {
                        var temp = matrix[matrix.GetLength(0) - 1, collToSfift];
                        for (int j = matrix.GetLength(0) - 1; j > 0; j--)
                        {
                            matrix[j, collToSfift] = matrix[j - 1, collToSfift];
                        }
                        matrix[0, collToSfift] = temp;
                    }
                }
                else if (command == "left")
                {
                    var rowToSfift = rowOrCol;
                    var currentStep = step % matrix.GetLength(1);
                    for (int k = 0; k < currentStep; k++)
                    {
                        var temp = matrix[rowToSfift, 0];
                        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                        {
                            matrix[rowToSfift,j] = matrix[rowToSfift, j+1];
                        }
                        matrix[rowToSfift, matrix.GetLength(0)-1] = temp;
                    }
                }
                else if (command == "right")
                {
                    var rowToSfift = rowOrCol;
                    var currentStep = step % matrix.GetLength(1);
                    for (int k = 0; k < currentStep; k++)
                    {
                        var temp = matrix[rowToSfift, matrix.GetLength(1) - 1];
                        for (int j = matrix[rowToSfift, matrix.GetLength(1) - 1]; j > 0; j--)
                        {
                            matrix[rowToSfift, j] = matrix[rowToSfift, j - 1];
                        }
                        matrix[rowToSfift, 0] = temp;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]==counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int k = 0; k < matrix.GetLength(0); k++)
                        {
                            var isCounterFound = false;
                            for (int l = 0; l < matrix.GetLength(1); l++)
                            {
                                if (matrix[k,l]==counter)
                                {
                                    Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})");
                                    matrix[i, j] = matrix[i, j] ^ matrix[k, l];
                                    matrix[k, l] = matrix[i, j] ^ matrix[k, l];
                                    matrix[i, j] = matrix[i, j] ^ matrix[k, l];
                                    isCounterFound = true;
                                    break;
                                }
                                if (isCounterFound)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    counter++;
                }
            }

        }
    }
}
