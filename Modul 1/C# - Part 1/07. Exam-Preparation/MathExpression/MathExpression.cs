// C# Fundamentals 2011/2012 Part 1 - Test Exam
// Problem 1. Math Expression

using System;
using System.Globalization;
using System.Threading;

class ExamPrep
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
		decimal N = decimal.Parse(Console.ReadLine());
		decimal M = decimal.Parse(Console.ReadLine());
		decimal P = decimal.Parse(Console.ReadLine());

		int sinBase = (int)M % 180;
		const int firstConst = 1337;
		const decimal secondConst = 128.523123123M;
		decimal nominator = N * N + (1 / (M * P)) + firstConst;
		decimal denominator = N - (secondConst * P);

		decimal firstNum = nominator / denominator;
		decimal secondNum = (decimal)Math.Sin(sinBase);
		decimal sum = firstNum + secondNum;

		Console.WriteLine("{0:F6}", sum);
	}
}