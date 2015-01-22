// Telerik Academy Exam 1 @ 7 Dec 2011 Morning
// Problem 1. Fighter Attack

using System;

class FighterAttack
{
	static void Main()
	{
		int P_x1 = int.Parse(Console.ReadLine());
		int P_y1 = int.Parse(Console.ReadLine());
		int P_x2 = int.Parse(Console.ReadLine());
		int P_y2 = int.Parse(Console.ReadLine());
		int F_x = int.Parse(Console.ReadLine());
		int F_y = int.Parse(Console.ReadLine());
		int D = int.Parse(Console.ReadLine());

		int hitPoint_x = F_x + D;
		int hitPoint_y = F_y;
		int hitPointUp_y = F_y + 1;
		int hitPointDown_y = F_y - 1;
		int hitPointRight_x = hitPoint_x + 1;
		int hitPointRight_y = hitPoint_y;

		// Find the rectangular bounds
		int min_x = Math.Min(P_x1, P_x2);
		int max_x = Math.Max(P_x1, P_x2);
		int min_y = Math.Min(P_y1, P_y2);
		int max_y = Math.Max(P_y1, P_y2);

		int totalDamage = 0;
		// Calculate the damage
		if (hitPoint_x >= min_x && hitPoint_x <= max_x)
		{
			if (hitPoint_y >= min_y && hitPoint_y <= max_y)
			{
				totalDamage += 100;
			}
			if (hitPointUp_y >= min_y && hitPointUp_y <= max_y)
			{
				totalDamage += 50;
			}
			if (hitPointDown_y >= min_y && hitPointDown_y <= max_y)
			{
				totalDamage += 50;
			}
		}
		if (hitPointRight_x >= min_x && hitPointRight_x <= max_x)
		{
			if (hitPointRight_y >= min_y && hitPointRight_y <= max_y)
			{
				totalDamage += 75;
			}
		}
		Console.WriteLine(totalDamage + "%");
	}
}