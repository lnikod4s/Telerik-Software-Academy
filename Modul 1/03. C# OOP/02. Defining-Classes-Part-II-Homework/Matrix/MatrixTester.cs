using System;
/// <summary>
/// This class have to test the Matrix class functionalities
/// </summary>
class MatrixTester
{
	static readonly Random rnd = new Random();
	static void Main()
	{
		var matrix1 = new Matrix<int>(3, 3, // dimensions
									  1, 2, 0, // elements
									  0, 1, 1,
									  2, 0, 1);

		var matrix2 = new Matrix<int>(3, 3);
		for (int row = 0; row < matrix2.Rows; row++)
		{
			for (int col = 0; col < matrix2.Cols; col++)
			{
				matrix2[row, col] = rnd.Next(10);
			}
		}

		Console.WriteLine("First Matrix ({0}x{1}) is:", matrix1.Rows, matrix1.Cols);
		Console.WriteLine(matrix1);

		Console.WriteLine("Second Matrix ({0}x{1}) is:", matrix2.Rows, matrix2.Cols);
		Console.WriteLine(matrix2);

		Console.WriteLine("Addition of the Matrices:");
		Console.WriteLine(matrix1 + matrix2);

		Console.WriteLine("Subtraction of the Matrices:");
		Console.WriteLine(matrix1 - matrix2);

		Console.WriteLine("Multiplication of the Matrices:");
		Console.WriteLine(matrix1 * matrix2);

		Console.WriteLine("First matrix: {0}", matrix1 ? "Non-empty!" : "Empty!");
		Console.WriteLine("New matrix: {0}" + Environment.NewLine, new Matrix<double>(1, 1) ? "Non-empty!" : "Empty!");
	}
}