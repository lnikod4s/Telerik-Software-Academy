using System;

namespace LoopRefactoring
{
	public class Loop
	{
		public static void Main()
		{
			const int EXPECTED_VALUE = 60;
			var array = new int[100];
			for (var i = 0; i < array.Length; i++)
			{
				if (i % 10 == 0)
				{
					Console.WriteLine(array[i]);
					if (array[i] == EXPECTED_VALUE)
					{
						Console.WriteLine("Value Found");
					}
				}
				else
				{
					Console.WriteLine(array[i]);
				}
			}
		}
	}
}