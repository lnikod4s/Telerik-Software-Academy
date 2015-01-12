using System;
/*Problem 1. Declare Variables
-------------------------------------------------------------------------------------------------------------------------------------------------------
Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.
Choose a large enough type for each number to ensure it will fit in it. Try to compile the code.
*/

class DeclareVariables
{
	static void Main()
	{
		const uint variable1 = 52130; //uint from 0 to 4,294,967,295; ushort: 0 to 65,635. Isn't ushort a better choice?'
		const sbyte variable2 = -115;
		const int variable3 = 4825932;
		const byte variable4 = 97;
		const short variable5 = -10000;
		Console.WriteLine(variable1);
		Console.WriteLine(variable2);
		Console.WriteLine(variable3);
		Console.WriteLine(variable4);
		Console.WriteLine(variable5);
	}
}
