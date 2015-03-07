using System;

public class Ball
{
	public int Width { get; set; }

	public int Heigth { get; set; }

	public int Depth { get; set; }

	public Ball(int ballWidth, int ballHeigth, int ballDepth)
	{
		this.Width = ballWidth;
		this.Heigth = ballHeigth;
		this.Depth = ballDepth;
	}
}

class Slides3D
{
	/// <summary>
	/// C# Part 2 - 2012/2013 @ 4 Feb 2013 - Morning
	/// 3. Slides => only 75/100 (time limit)
	/// </summary>
	private static int width, heigth, depth;
	private static string[,,] cuboid;
	private static Ball playingBall;

	static void Main()
	{
		ReadInput();
		ApplyCommands();
	}

	private static void ApplyCommands()
	{
		while (true)
		{
			string currCell = cuboid[playingBall.Width, playingBall.Heigth, playingBall.Depth];
			string[] splittedCell = currCell.Split();

			string command = splittedCell[0];
			switch (command)
			{
				case "S": ApplyCurrSlide(splittedCell[1]); break;
				case "T": 
					playingBall.Width = int.Parse(splittedCell[1]);
					playingBall.Depth = int.Parse(splittedCell[2]);
					break;
				case "B": PrintMessage(); return;
				case "E":
					if (playingBall.Heigth == heigth - 1)
					{
						PrintMessage();
					}
					else
					{
						playingBall.Heigth++;
					}

					break;
				default: throw new ArgumentException("Invalid command!");
			}
		}
	}

	private static void ApplyCurrSlide(string command)
	{
		var newBall = new Ball(playingBall.Width, playingBall.Heigth, playingBall.Depth);
		switch (command)
		{
			case "R":
				newBall.Width++;
				newBall.Heigth++;
				break;
			case "L":
				newBall.Width--;
				newBall.Heigth++;
				break;
			case "F":
				newBall.Depth--;
				newBall.Heigth++;
				break;
			case "B":
				newBall.Depth++;
				newBall.Heigth++;
				break;
			case "FL":
				newBall.Width--;
				newBall.Depth--;
				newBall.Heigth++;
				break;
			case "FR":
				newBall.Width++;
				newBall.Depth--;
				newBall.Heigth++;
				break;
			case "BL":
				newBall.Width--;
				newBall.Depth++;
				newBall.Heigth++;
				break;
			case "BR":
				newBall.Width++;
				newBall.Depth++;
				newBall.Heigth++;
				break;
			default: throw new ArgumentException("Invalid command!");
		}

		if (IsTraversable(newBall))
		{
			playingBall = new Ball(newBall.Width, newBall.Heigth, newBall.Depth);
		}
		else
		{
			PrintMessage();
			Environment.Exit(0);
		}
	}

	private static void PrintMessage()
	{
		string currCell = cuboid[playingBall.Width, playingBall.Heigth, playingBall.Depth];
		if (currCell == "B" || playingBall.Heigth != heigth - 1)
		{
			Console.WriteLine("No");
		}
		else
		{
			Console.WriteLine("Yes");
		}

		Console.WriteLine("{0} {1} {2}", playingBall.Width, playingBall.Heigth, playingBall.Depth);
	}

	private static bool IsTraversable(Ball ball)
	{
		if (ball.Width >= 0 &&
			ball.Heigth >= 0 &&
			ball.Depth >= 0 &&
			ball.Width < width &&
			ball.Heigth < heigth &&
			ball.Depth < depth)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private static void ReadInput()
	{
		string[] dimensions = Console.ReadLine().Split();
		width = int.Parse(dimensions[0]);
		heigth = int.Parse(dimensions[1]);
		depth = int.Parse(dimensions[2]);

		cuboid = new string[width, heigth, depth];
		for (int h = 0; h < heigth; h++)
		{
			string[] currLine = Console.ReadLine().Split(new[] {" | "}, StringSplitOptions.RemoveEmptyEntries);
			for (int d = 0; d < depth; d++)
			{
				string[] commands = currLine[d].Split(new[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries);
				for (int w = 0; w < width; w++)
				{
					cuboid[w, h, d] = commands[w];
				}
			}
		}

		string[] ballCoordinates = Console.ReadLine().Split();
		int ballW = int.Parse(ballCoordinates[0]);
		int ballD = int.Parse(ballCoordinates[1]);

		playingBall = new Ball(ballW, 0, ballD);
	}
}