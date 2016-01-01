using System;

/// <summary>
/// This class have to test the GenericList functionalities, described in GenericList.cs
/// </summary>
class GenericListTester
{
	static void Main()
	{
		var elements = new GenericList<int>();

		// empty GenericList
		Console.WriteLine(elements);
		Console.WriteLine("Count: {0}", elements.Count);
		Console.WriteLine("Capacity: {0}", elements.Capacity);

		// auto-grow functionality
		elements = new GenericList<int>(3);
		elements.Add(1);
		elements.Add(2);
		elements.Add(3);
		elements.Add(4);

		Console.WriteLine(Environment.NewLine + elements);
		Console.WriteLine("Count: {0}", elements.Count);
		Console.WriteLine("Capacity: {0}", elements.Capacity);

		// Insert, RemoveAt
		elements.Clear();

		elements.Insert(0, 4);
		elements.Insert(0, 3);
		elements.Insert(0, 2);
		elements.Insert(0, 1);

		elements.RemoveAt(0);
		elements.RemoveAt(elements.Count - 1);

		Console.WriteLine(Environment.NewLine + elements);
		Console.WriteLine("Count: {0}", elements.Count);
		Console.WriteLine("Capacity: {0}", elements.Capacity);

		// Contains, IndexOf
		Console.WriteLine(Environment.NewLine + "Contain element 2: {0}", elements.Contains(2));
		Console.WriteLine("Index of element 3: {0}", elements.IndexOf(3));

		// Max, Min
		Console.WriteLine(Environment.NewLine + "Min: {0}", elements.Min());
		Console.WriteLine("Max: {0}", elements.Max());
	}
}
