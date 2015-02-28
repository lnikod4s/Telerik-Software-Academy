using System;
using System.Text;

class Trails3D
{
	static void Main()
	{
		string[] xyz = Console.ReadLine().Split(' ');
		int x = int.Parse(xyz[0]);
		int y = int.Parse(xyz[1]);
		int z = int.Parse(xyz[2]);

		string[] commands =
		{
			ParseCommand(Console.ReadLine()),
			ParseCommand(Console.ReadLine())
		};

		var result = Solve(x, y, z, commands);
		Console.WriteLine(result);
	}

	private static string Solve(int x, int y, int z, string[] commands)
	{
		int[] dims = { y + 1, 2 * x + 2 * z };
		bool[,] visited = new bool[dims[0], dims[1]];

		// red player / blue player
		int[] direction = { 0, 2 };
		int[] directionH = { 0, -1, 0, 1, };
		int[] directionV = { 1, 0, -1, 0, };
		int[,] position = { { y / 2, x / 2 }, { y / 2, x + z + x / 2 } };
		// did player go on forbidden walls?
		bool[] outside = { false, false };

		// index into the 'commands' strings we read from the console
		int[] commandIndex = { 0, 0 };

		while (true)
		{
			// for both players
			for (int player = 0; player <= 1; player += 1)
			{
				visited[position[player, 0], position[player, 1]] = true;

				// read next command from player's string
				char cmd = commands[player][commandIndex[player]];
				commandIndex[player] += 1;

				// turn?
				if (cmd == 'L' || cmd == 'R')
				{
					// adjust direction index
					direction[player] += (cmd == 'L') ? 1 : 3;
					direction[player] %= 4;
					// read more commands for same player
					player -= 1;
					continue;
				}
				else
				{
					int newH = position[player, 0] + directionH[direction[player]];
					int newV = position[player, 1] + directionV[direction[player]];

					// went on forbidden wall
					if (newH < 0 || newH >= dims[0])
					{
						outside[player] = true;
						continue;
					}

					// went above top or below bottom?
					if (newV < 0 || newV >= dims[1])
					{
						// loop over to other side
						newV += dims[1];
						newV %= dims[1];
					}

					position[player, 0] = newH;
					position[player, 1] = newV;
				}
			}

			bool headOnCollision = position[0, 0] == position[1, 0] &&
								   position[0, 1] == position[1, 1];

			bool redDied = visited[position[0, 0], position[0, 1]] || headOnCollision || outside[0];
			bool blueDied = visited[position[1, 0], position[1, 1]] || headOnCollision || outside[1];

			if (redDied || blueDied)
			{
				string result = "";
				if (redDied && blueDied)
				{
					result = "DRAW";
				}
				else if (redDied)
				{
					result = "BLUE";
				}
				else if (blueDied)
				{
					result = "RED";
				}
				result += "\n" + GetDistanceFromStart(position[0, 0], position[0, 1], x, y, z);
				return result;
			}
		}
	}

	private static string ParseCommand(string command)
	{
		StringBuilder commandBuilder = new StringBuilder();
		for (var i = 0; i < command.Length; i++)
		{
			var cmd = command[i];
			if ('0' < cmd && cmd <= '9')
			{
				i++;
				var count = cmd - '0';
				var ch = command[i];
				for (int j = 0; j < count; j++)
				{
					commandBuilder.Append(ch);
				}
			}
			else
			{
				commandBuilder.Append(cmd);
			}
		}
		return commandBuilder.ToString();
	}

	static double GetDistanceFromStart(int h, int v, int x, int y, int z)
	{
		var dx = Math.Abs(v - x / 2);
		if (dx > x + z)
		{
			dx = 2 * x + 2 * z - dx;
		}
		var dy = Math.Abs(y / 2 - h);
		return dx + dy;
	}
}