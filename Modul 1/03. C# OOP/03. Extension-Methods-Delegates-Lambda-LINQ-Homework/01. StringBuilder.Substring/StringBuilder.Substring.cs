using System;
using System.Text;

/// <summary>
/// Problem 1. StringBuilder.Substring
/// Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and 
/// has the same functionality as Substring in the class String.
/// </summary>
public static class StringBuilderExtensions
{
	/// <summary>Defines the entry point of the application.</summary>
	static void Main()
	{
		var sb1 = new StringBuilder();
		sb1.Append("Are you master programmer?");
		sb1.Append("Sure, i am.");

		// Tests first substring method by given index and length
		var sb2 = sb1.Substring(26, 11);
		Console.WriteLine(sb1);
		Console.WriteLine(sb2);
		sb2.Clear();

		// Tests second substring method by given index
		sb2 = sb1.Substring(26);
		Console.WriteLine(sb2);
	}

	public static StringBuilder Substring(this StringBuilder sb, int index, int length)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (index > sb.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (index > sb.Length - length)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (length == 0)
		{
			return sb.Clear();
		}
		if (index == 0 && length == sb.Length)
		{
			return sb;
		}

		return new StringBuilder(sb.ToString().Substring(index, length));
	}

	public static StringBuilder Substring(this StringBuilder sb, int index)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (index > sb.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}

		return new StringBuilder(sb.ToString().Substring(index));
	}
}