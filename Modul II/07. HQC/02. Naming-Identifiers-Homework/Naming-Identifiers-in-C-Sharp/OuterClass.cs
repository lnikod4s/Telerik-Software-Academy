using System;

namespace Naming_Identifiers_in_C_Sharp
{
	public class OuterClass
	{
		const int MaxCount = 6;

		public class InnerClass
		{
			public static void printVariable(bool boolVariable)
			{
				var variableAsString = boolVariable.ToString();
				Console.WriteLine(variableAsString);
			}
		}

		public static void Main()
		{
			var newInnerClass = new InnerClass();
			InnerClass.printVariable(true);
		}
	}
}
