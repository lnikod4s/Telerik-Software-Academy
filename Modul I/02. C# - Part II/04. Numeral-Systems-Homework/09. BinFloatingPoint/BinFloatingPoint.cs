using System;
/*Problem 9.* Binary floating-point
------------------------------------------------------------------------------------------------------------------------
Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
Example:

number	sign	exponent	mantissa
-27,25	1		10000011	10110100000000000000000
*/
class BinFloatingPoint
{
	static void Main()
	{
		Console.Write("Enter a floating-point number with single precision: ");
		float number = float.Parse(Console.ReadLine());

		int sign = number < 0 ? 1 : 0;
		number = Math.Abs(number);

		string binary = FloatNumberToBinary(number);

		// 0.1 (Exponent: 01111011) \ 1.1 (Exponent: 01111111) \ 2.2 (Exponent: 10000000)
		if ((int)number == 0 || (int)number == 1) binary = "0" + binary;

		Console.WriteLine("\nSign: {0} {1}", sign, sign == 1 ? "(minus)" : "(plus)");
		Console.WriteLine("Exponent: {0}", GetExponent(binary));
		Console.WriteLine("Mantissa: {0}\n", GetMantissa(binary));
	}

	static string FloatNumberToBinary(float number)
	{
		int dec = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
		return Convert.ToString(dec, 2);
	}

	static string GetExponent(string binary)
	{
		return binary.Substring(0, 8);
	}

	static string GetMantissa(string binary)
	{
		return binary.Substring(8);
	}
}