using System;

namespace RotatingWalkInMatrix
{
    public class MatrixGenerator
    {
        internal static int[,] GenerateMatrix()
        {
            var matrixSize = ReadMatrixSize();
            var matrix = new int[matrixSize, matrixSize];
            return matrix;
        }

        private static int ReadMatrixSize()
        {
            Console.WriteLine(Helpers.PositiveNumberInputMessage);
            var userInput = Console.ReadLine();

            var matrixSize = 0;
            while (!int.TryParse(userInput, out matrixSize) || !IsInRange(matrixSize))
            {
                Console.WriteLine(Helpers.WrongInputMessage);
                Console.WriteLine(Helpers.PositiveNumberInputMessage);
                userInput = Console.ReadLine();
            }

            return matrixSize;
        }

        private static bool IsInRange(int number)
        {
            return number >= 1 && number <= 100;
        }

        internal static void PrintMatrix(int[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,5}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}