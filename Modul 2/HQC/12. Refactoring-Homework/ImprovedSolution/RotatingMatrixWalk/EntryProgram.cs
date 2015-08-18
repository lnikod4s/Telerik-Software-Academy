namespace RotatingMatrixWalk
{
    using System;

    internal class EntryProgram
    {
        public static void Main()
        {
            var matrixSize = ReadMatrixSize();
            var matrix = MatrixGenerator.Generate(matrixSize);
            PrintMatrix(matrix);
        }

        private static int ReadMatrixSize()
        {
            Console.WriteLine("Enter a positive number ");
            var input = Console.ReadLine();

            int n;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}