using System;
/*Problem 4. Triangle surface
----------------------------------------------------------------
Write methods that calculate the surface of a triangle by given:
Side and an altitude to it;
Three sides;
Two sides and an angle between them;
Use System.Math.
*/
class TriangleSurface
{
	static void Main()
	{
		Console.WriteLine("This is a program that calculate the surface of a triangle by given:");
		Console.WriteLine("1) Side and an altitude to it");
		Console.WriteLine("2) Three sides");
		Console.WriteLine("3) Two sides and an angle between them");
		Console.WriteLine("Please choose an option: 1, 2 or 3!");
		int choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1: CalcSurfaceBySideAndAltitude(); break;
			case 2: CalcSurfaceByThreeSides(); break;
			case 3: CalcSurfaceByTwoSidesAndAngle(); break;
		}
	}

	private static void CalcSurfaceBySideAndAltitude()
	{
		Console.Write("Enter a real number for the side: ");
		decimal side = decimal.Parse(Console.ReadLine());
		Console.Write("Enter a real number for the altitude: ");
		decimal altitude = decimal.Parse(Console.ReadLine());

		decimal area = (side * altitude) / 2;
		Console.WriteLine("The triangle area is: {0:F2}", area);
	}

	private static void CalcSurfaceByThreeSides()
	{
		Console.Write("Enter a real number for the first side: ");
		decimal a = decimal.Parse(Console.ReadLine());
		Console.Write("Enter a real number for the second side: ");
		decimal b = decimal.Parse(Console.ReadLine());
		Console.Write("Enter a real number for the third side: ");
		decimal c = decimal.Parse(Console.ReadLine());

		decimal p = (a + b + c) / 2;
		decimal area = (decimal)Math.Sqrt((double)(p * (p - a) * (p - b) * (p - c)));
		Console.WriteLine("The triangle area is: {0:F2}", area);
	}

	private static void CalcSurfaceByTwoSidesAndAngle()
	{
		Console.Write("Enter a real number for the first side: ");
		decimal a = decimal.Parse(Console.ReadLine());
		Console.Write("Enter a real number for the second side: ");
		decimal b = decimal.Parse(Console.ReadLine());
		Console.Write("Enter a real number for the angle between two sides in grad: ");
		decimal angle = decimal.Parse(Console.ReadLine());

		decimal sinusAngle = (decimal)Math.Sin((double)angle);
		decimal area = (a * b * sinusAngle) / 2;
		Console.WriteLine("The triangle area is: {0:F2}", area);
	}
}
