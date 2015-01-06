using System;
/*Problem 3. Variable in Hexadecimal Format
------------------------------------------------------------------------------------------
Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##).
Use Windows Calculator to find its hexadecimal representation.
Print the variable and ensure that the result is 254.
*/

class VariableInHexFormat
{
	static void Main()
	{
		const int variable = 0xFE;
		Console.WriteLine(variable);
	}
}