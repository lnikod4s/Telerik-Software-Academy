using System;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Defines a class Matrix to hold a matrix of numbers (e.g. integers, floats, decimals).
/// Implements an indexer this[row, col] to access the inner matrix cells.
/// Implements the operators + and - (addition and subtraction of matrices of the same size) and 
///							 * for matrix multiplication. 
/// Throws an exception when the operation cannot be performed. 
/// Implements the true operator (check for non-zero elements).
/// </summary>
class Matrix<T>
{
	private const int DEFAULT_ROWS = 1;
	private const int DEFAULT_COLS = 1;

	private readonly T[,] matrix;

	public Matrix(int rows = DEFAULT_ROWS, int cols = DEFAULT_COLS, params T[] elements)
	{
		if (rows * cols != elements.Length &&
			elements.Length != 0)
		{
			throw new ArgumentException("The product of matrix dimensions and count of input elements must must be equal.");
		}

		this.matrix = new T[rows, cols];
		this.Rows = rows;
		this.Cols = cols;

		// Copy the input elements in the matrix
		if (elements.Length > 0)
		{
			Buffer.BlockCopy(elements, 0, this.matrix, 0, (rows * cols * Marshal.SizeOf(typeof(T))));
		}
	}

	public int Rows { get; set; }
	public int Cols { get; set; }

	public T this[int row, int col]
	{
		get { return this.matrix[row, col]; }
		set { this.matrix[row, col] = value; }
	}

	public override string ToString()
	{
		var result = new StringBuilder();
		for (int row = 0; row < this.Rows; row++)
		{
			for (int col = 0; col < this.Cols; col++)
			{
				result.AppendFormat("{0,5}", this.matrix[row, col]);
			}

			result.AppendLine();
		}

		return result.ToString();
	}

	public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
	{
		if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
		{
			throw new InvalidOperationException("Matrices must have same dimensions.");
		}

		var result = new Matrix<T>();
		for (int row = 0; row < result.Rows; row++)
		{
			for (int col = 0; col < result.Cols; col++)
			{
				result[row, col] = (dynamic)matrix1[row, col] + (dynamic)matrix2[row, col];
			}
		}

		return result;
	}

	public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
	{
		if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
		{
			throw new InvalidOperationException("Matrices must have same dimensions.");
		}

		var result = new Matrix<T>(matrix1.Rows, matrix2.Cols);
		for (int row = 0; row < result.Rows; row++)
		{
			for (int col = 0; col < result.Cols; col++)
			{
				result[row, col] = (dynamic)matrix1[row, col] - (dynamic)matrix2[row, col];
			}
		}

		return result;
	}

	public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
	{
		if (matrix1.Rows != matrix2.Cols || matrix1.Cols != matrix2.Rows)
		{
			throw new InvalidOperationException("Matrices must have propertional dimensions.");
		}

		var result = new Matrix<T>(matrix1.Rows, matrix2.Cols);
		for (int row = 0; row < result.Rows; row++)
		{
			for (int col = 0; col < result.Cols; col++)
			{
				for (int index = 0; index < matrix1.Cols; index++)
				{
					result[row, col] += (dynamic)matrix1[row, index] * matrix2[index, col];
				}
			}
		}

		return result;
	}

	public static bool operator true(Matrix<T> matrix)
	{
		return BooleanOperator(matrix, true);
	}

	public static bool operator false(Matrix<T> matrix)
	{
		return BooleanOperator(matrix, false);
	}

	private static bool BooleanOperator(Matrix<T> matrix, bool trueOrFalse)
	{
		foreach (var element in matrix.matrix)
		{
			if (!element.Equals(default(T)))
			{
				return trueOrFalse;
			}
		}

		return !trueOrFalse;
	}
}