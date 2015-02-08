using System;
using System.Text;

/*Problem 1. Strings in C
--------------------------------------------------------
Describe the strings in C#.
What is typical for the string data type?
Describe the most important methods of the String class.
*/
class StringsInCSharp
{
	static void Main()
	{
		Console.WriteLine("1) Describe the strings in C#:");
		DefinitionOfStrings();
		Console.WriteLine("2) What is typical for the string data type?");
		TypicalForStringDataType();
		Console.WriteLine("3) Describe the most important methods of the String class:");
		ImportantMethodsOfTheStringClass();
	}

	private static void DefinitionOfStrings()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("Strings are immutable sequences of characters (instances of the System.String Class in .NET Framework)");
		sb.AppendLine("->Declared by the keyword string in C#");
		sb.AppendLine("->Can be initialized by string literals");
		sb.AppendLine("->Use Unicode to support multiple languages and alphabets");
		sb.AppendLine("->Stored in the dynamic memory (managed heap)");
		Console.WriteLine(sb);
	}

	private static void TypicalForStringDataType()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("System.String is reference type");
		sb.AppendLine("String objects are like arrays of characters (char[])");
		sb.AppendLine("->Have fixed length (String.Length)");
		sb.AppendLine("->Elements can be accessed directly by index (the index is in the range [0..Length-1])");
		Console.WriteLine(sb);
	}

	private static void ImportantMethodsOfTheStringClass()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("Most important string processing members are:");
		sb.AppendLine("->Length, this[], Compare(str1, str2), IndexOf(str), LastIndexOf(str), Substring(startIndex, length), Replace(oldStr, newStr), Remove(startIndex, length), ToLower(), ToUpper(), Trim()");
		Console.WriteLine(sb);
	}
}