// Telerik Academy Exam 1 @ 27 Dec 2012
// Problem 4. Carpets

using System;
using System.Text;

class ExamPrep
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		char[,] matrix = new char[n, n];

		for (int i = 0, index = n / 2 - 1; i < n / 2; i++, index--)
		{
			for (int j = 0; j < n / 2; j++)
			{
				matrix[i, j] = '.';
				if (j >= index && (j - index) % 2 == 0)
				{
					matrix[i, j] = '/';
				}
				else if (j >= index && (j - index) % 2 != 0)
				{
					matrix[i, j] = ' ';
				}
			}
		}

		for (int i = 0, index = n / 2 + 1; i < n / 2; i++, index++)
		{
			for (int j = n / 2; j < n; j++)
			{
				matrix[i, j] = '.';
				if (j < index && (j - index) % 2 != 0)
				{
					matrix[i, j] = '\\';
				}
				else if (j < index && (j - index) % 2 == 0)
				{
					matrix[i, j] = ' ';
				}
			}
		}

		for (int i = n / 2, index = 0; i < n; i++, index++)
		{
			for (int j = 0; j < n / 2; j++)
			{
				matrix[i, j] = '.';
				if (j >= index && (j - index) % 2 == 0)
				{
					matrix[i, j] = '\\';
				}
				else if (j >= index && (j - index) % 2 != 0)
				{
					matrix[i, j] = ' ';
				}
			}
		}

		for (int i = n / 2, index = n; i < n; i++, index--)
		{
			for (int j = n / 2; j < n; j++)
			{
				matrix[i, j] = '.';
				if (j < index && (j - index) % 2 != 0)
				{
					matrix[i, j] = '/';
				}
				else if (j < index && (j - index) % 2 == 0)
				{
					matrix[i, j] = ' ';
				}
			}
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				Console.Write(matrix[i, j]);
			}
			Console.WriteLine();
		}
	}
}