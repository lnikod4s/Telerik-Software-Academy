using System;
using System.Text;

/*
*/
class MatrixClass
{
	static void Main()
	{
		Matrix matrix1 = new Matrix(3, 3,
			1, 2, 0,
			0, 1, 1,
			2, 0, 1);

		Matrix matrix2 = new Matrix(3, 3,
			1, 1, 2,
			2, 1, 1,
			1, 2, 1);

		Console.WriteLine("First Matrix is:");
		Console.WriteLine(matrix1);

		Console.WriteLine("Second Matrix is:");
		Console.WriteLine(matrix2);

		Console.WriteLine("Addition of the Matrices:");
		Console.WriteLine(matrix1 + matrix2);

		Console.WriteLine("Subtraction of the Matrices:");
		Console.WriteLine(matrix1 - matrix2);

		Console.WriteLine("Multiplication of the Matrices:");
		Console.WriteLine(matrix1 * matrix2);
	}
}

class Matrix
{
	// Fields
	private readonly int Rows;
	private readonly int Cols;
	private readonly int[,] matrix;

	// Constructors
	private Matrix(int rows, int cols)
		: this(rows, cols, new int[] { })
	{
	}

	public Matrix(int rows, int cols, params int[] numbers)
	{
		if (rows * cols != numbers.Length && numbers.Length != 0)
		{
			throw new ArgumentException();
		}

		matrix = new int[rows, cols];
		Rows = rows;
		Cols = cols;

		if (numbers.Length > 0)
		{
			Buffer.BlockCopy(numbers, 0, matrix, 0, rows * cols * sizeof(int));
		}
	}

	// Indexer for accessing the matrix content
	private int this[int row, int col]
	{
		get { return matrix[row, col]; }
		set { matrix[row, col] = value; }
	}

	// Override method ToString() to print appropriately matrix elements 
	public override string ToString()
	{
		StringBuilder result = new StringBuilder();

		for (int row = 0; row < this.Rows; row++)
		{
			for (int col = 0; col < this.Cols; col++)
			{
				result.AppendFormat("{0,4}", matrix[row, col]);
			}
			result.AppendLine();
		}

		return result.ToString();
	}

	// Аddition (m1 + m2)
	public static Matrix operator +(Matrix matrix1, Matrix matrix2)
	{
		if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
		{
			Console.WriteLine("-> Invalid operation! Matrices must be of one and same type...");
			return null;
		}

		Matrix result = new Matrix(matrix1.Rows, matrix1.Cols);

		for (int row = 0; row < result.Rows; row++)
		{
			for (int col = 0; col < result.Cols; col++)
			{
				result[row, col] = matrix1[row, col] + matrix2[row, col];
			}
		}

		return result;
	}

	// Subtraction (m1 - m2)
	public static Matrix operator -(Matrix matrix1, Matrix matrix2)
	{
		if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
		{
			Console.WriteLine("-> Invalid operation! Matrices must be of one and same type...");
			return null;
		}

		Matrix result = new Matrix(matrix1.Rows, matrix1.Cols);

		for (int row = 0; row < result.Rows; row++)
			for (int col = 0; col < result.Cols; col++)
				result[row, col] = matrix1[row, col] - matrix2[row, col];

		return result;
	}

	// Multiplication (m1 * m2)
	public static Matrix operator *(Matrix matrix1, Matrix matrix2)
	{
		Matrix result = new Matrix(matrix1.Rows, matrix2.Cols);

		for (int row = 0; row < result.Rows; row++)
		{
			for (int col = 0; col < result.Cols; col++)
			{
				for (int k = 0; k < matrix1.Cols; k++) // or i < matrix2.Rows
				{
					result[row, col] += matrix1[row, k] * matrix2[k, col];
				}
			}
		}

		return result;
	}
}