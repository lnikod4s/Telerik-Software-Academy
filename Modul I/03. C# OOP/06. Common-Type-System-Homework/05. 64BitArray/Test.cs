/*Problem 5. 64 Bit array

Define a class BitArray64 to hold 64 bit values inside an ulong value.
Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
*/

using System;

namespace _05._64BitArray
{
	class Test
	{
		static void Main()
		{
			// Creating two variables of type BitArray64
			const ulong number = 12345678901234567890;
			BitArray64 array1 = new BitArray64(number);
			BitArray64 array2 = new BitArray64(number / 2);

			// Printing the arrays
			PrintArray(array1, "array1: ");
			PrintArray(array2, "array2: ");

			// Comparing both arrays
			Console.WriteLine("\n{0,-24} →  {1}", "array1.Equals(array2)", array1.Equals(array2));
			Console.WriteLine("{0,-24} →  {1}\n", "array1 != array2", array1 != array2);

			// Testing ToString() method
			Console.WriteLine(array1);

			// Testing the indexer
			Console.WriteLine("array1[7] = {0}", array1[7]);
		}

		// Printing some array with foreach
		private static void PrintArray(BitArray64 array1, string text)
		{
			Console.Write(text);
			foreach (var bit in array1)
			{
				Console.Write(bit);
			}
			Console.WriteLine();
		}
	}
}
