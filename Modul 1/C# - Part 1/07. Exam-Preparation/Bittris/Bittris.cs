// Telerik Academy Exam 1 @ 24 June 2013 Evening
// Problem 5. Bittris

using System;

class Bittris
{
	static uint score;
	static byte[] field;
	static int fullPiece;

	static void Main()
	{
		field = new byte[4];
		int n = int.Parse(Console.ReadLine());
		for (int i = 0; i < n / 4; i++)
		{
			fullPiece = int.Parse(Console.ReadLine());
			MovePiece((byte)fullPiece);
		}
		Console.WriteLine(score);
	}

	static uint GetScorePiece(byte finalLine)
	{
		byte points = 0;

		for (int i = 0; i < 32; i++)
		{
			if (((fullPiece >> i) & 1) == 1)            //counts the bits equal to 1 in the input int
			{
				points++;
			}
		}

		if (field[finalLine] == 255)                //checks if the line is full with bits equal to 1
		{
			points = (byte)(points * 10);
			for (byte i = finalLine; i >= 1; i--)   //moves the lines down when the full line is deleted
			{
				field[i] = field[i - 1];
			}
			field[0] = 0;
		}

		return points;
	}

	static void MovePiece(byte piece)
	{
		byte line = 0;

		bool isFinal = false;

		for (byte i = 0; i < 3; i++)
		{
			char command = char.Parse(Console.ReadLine());

			if (field[0] != 0 || line >= 3 || isFinal) continue;

			if (command == 'L')
			{
				if (((piece >> 7) & 1) != 1 && (field[line] & (piece << 1)) == 0)
				{
					piece = (byte)(piece << 1);
				}
			}
			else if (command == 'R')
			{
				if ((piece & 1) != 1 && (field[line] & (piece << 1)) == 0)
				{
					piece = (byte)(piece >> 1);
				}
			}
			if ((field[line + 1] & piece) == 0)
			{
				line++;
			}
			else
			{
				isFinal = true;
			}
		}

		field[line] = (byte)(field[line] | piece);
		score += GetScorePiece(line);
	}
}