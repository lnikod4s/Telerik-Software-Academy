using System;
using System.Diagnostics;

namespace Assertions.Algorithms
{
	internal static class SearchingAlgorithm
	{
		internal static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
		{
			// Public method --> using exceptions as defensive programming approach
			return BinarySearch(arr, value, 0, arr.Length - 1);
		}

		internal static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
		where T : IComparable<T>
		{
			Debug.Assert(arr != null, "Array is null.");
			Debug.Assert(arr.Length > 0, "Array is empty.");

			Debug.Assert(value != null, "Searching value is null.");

			Debug.Assert(startIndex >= 0 && startIndex <= arr.Length - 1, "Invalid startIndex value.");
			Debug.Assert(endIndex >= 0 && endIndex <= arr.Length - 1, "Invalid endIndex value.");
			Debug.Assert(startIndex <= endIndex, "Invalid start- and endIndex values.");

			while (startIndex <= endIndex)
			{
				int midIndex = (startIndex + endIndex) / 2;
				if (arr[midIndex].Equals(value))
				{
					return midIndex;
				}

				if (arr[midIndex].CompareTo(value) < 0)
				{
					// Search on the left half
					startIndex = midIndex + 1;
				}
				else
				{
					// Search on the right half
					endIndex = midIndex - 1;
				}
			}

			Debug.Assert(startIndex > endIndex, "Searching algorithm logic is error-prone.");
			// Searched value not found
			return -1;
		}
	}
}