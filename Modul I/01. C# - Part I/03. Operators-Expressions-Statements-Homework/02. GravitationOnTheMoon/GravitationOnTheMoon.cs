using System;
/*Problem 2. Gravitation on the Moon
-----------------------------------------------------------------------------------------------
The gravitational field of the Moon is approximately 17% of that on the Earth.
Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
Examples:

weight	weight on the Moon
86		14.62
74.6	12.682
53.7	9.129
*/

class GravitationOnTheMoon
{
	static void Main()
	{
		Console.WriteLine("Please enter your weight on the Earth: ");
		int weight = int.Parse(Console.ReadLine());
		const decimal moonWeightFactor = 0.17M;
		Console.Write("Your weight on the Moon would be: ");
		Console.WriteLine(weight * moonWeightFactor);
	}
}