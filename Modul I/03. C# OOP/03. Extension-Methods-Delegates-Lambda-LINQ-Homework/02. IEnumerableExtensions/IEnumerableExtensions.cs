using System;
using System.Collections.Generic;
using System.Linq;

public static class IEnumerableExtensions
{
	/// <summary>Defines the entry point of the application.</summary>
	static void Main()
	{
		var list = new List<int> { 1, 2, 4, 5, 7, 8, 9, 10 };
		Console.WriteLine("Sum of elements: {0}", list.Sum());
		Console.WriteLine("Average sum of elements: {0}", list.Average());
		Console.WriteLine("Product of elements: {0}", list.Product());
		Console.WriteLine("Minimal element: {0}", list.Min());
		Console.WriteLine("Maximal element: {0}", list.Max());
	}

	public static dynamic Sum<T>(this IEnumerable<T> items)
	{
		dynamic sum = default(T);
		foreach (var item in items)
		{
			sum += item;
		}

		return sum;
	}

	public static dynamic Average<T>(this IEnumerable<T> items)
	{
		dynamic sum = default(T);
		double count = 0;
		foreach (var item in items)
		{
			sum += item;
			count++;
		}

		return sum / count;
	}

	public static dynamic Product<T>(this IEnumerable<T> items)
	{
		dynamic product = 1;
		foreach (var item in items)
		{
			product *= item;
		}

		return product;
	}

	public static dynamic Min<T>(this IEnumerable<T> items) where T : IComparable<T>
	{
		var enumerable = items as IList<T> ?? items.ToList();
		var enumerator = enumerable.GetEnumerator();
		enumerator.MoveNext();
		T currElement = enumerator.Current;
		foreach (var item in enumerable)
		{
			if ((dynamic)item < (dynamic)currElement)
			{
				currElement = item;
			}
		}

		return currElement;
	}

	public static dynamic Max<T>(this IEnumerable<T> items)
	{
		var collection = items as IList<T> ?? items.ToList();
		var enumerator = collection.GetEnumerator();
		enumerator.MoveNext();
		T currElement = enumerator.Current;
		foreach (var item in collection)
		{
			if ((dynamic)item > (dynamic)currElement)
			{
				currElement = item;
			}
		}

		return currElement;
	}
}