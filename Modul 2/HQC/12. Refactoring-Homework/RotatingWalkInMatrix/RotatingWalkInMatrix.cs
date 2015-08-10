using System;

namespace RotatingWalkInMatrix
{
    public class RotatingWalkInMatrix
    {
        static void Main()
        {
            var matrix = GenerateMatrix();
            RotatingWalkInMatrixSolver.SetMatrixValues(matrix);
            PrintMatrix(matrix);
        }

        private static int[,] GenerateMatrix()
        {
            var matrixSize = ReadMatrixSize();
            var matrix = new int[matrixSize, matrixSize];
            return matrix;
        }

        private static int ReadMatrixSize()
        {
            Console.WriteLine(Utils.PositiveNumberInputMessage);
            string userInput = Console.ReadLine();

            int matrixSize = 0;
            while (!int.TryParse(userInput, out matrixSize) || !IsInRange(matrixSize))
            {
                Console.WriteLine(Utils.WrongInputMessage);
                Console.WriteLine(Utils.PositiveNumberInputMessage);
                userInput = Console.ReadLine();
            }

            return matrixSize;
        }

        private static bool IsInRange(int number)
        {
            return number >= 1 && number <= 100;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
