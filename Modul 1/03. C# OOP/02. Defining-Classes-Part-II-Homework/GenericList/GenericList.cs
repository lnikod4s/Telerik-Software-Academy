using System;
using System.Linq;
using System.Text;

/// <summary>
/// Defines a generic class GenericList that keeps a list of elements of some parametric type T. 
/// Keeps the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
/// Implements methods for adding element (Add),
///						   accessing element by index (indexer),
///						   removing element by index (RemoveAt),
///                        inserting element at given position (Insert),
///						   clearing the list (Clear),
///						   finding element by its value (Contains),
///						   auto-grow functionality (Resize),
///						   finding minimal (Min),  
///						   maximal element (Max) and 
///						   override ToString().
/// Checks all input parameters to avoid accessing elements at invalid positions.
/// </summary>
/// <typeparam name="T"></typeparam>
public class GenericList<T>
{
	private const int DEFAULT_COUNT = 1;

	private T[] tArray;

	public GenericList(int capacity = DEFAULT_COUNT)
	{
		this.Count = 0;
		this.Capacity = capacity;
		this.tArray = new T[capacity];
	}

	public int Count { get; private set; }

	public int Capacity { get; private set; }

	public T this[int index]
	{
		get
		{
			if (index >= 0 && index < this.tArray.Length)
			{
				return this.tArray[index];
			}
			else
			{
				throw new IndexOutOfRangeException("Invalid index.");
			}

		}
		set
		{
			if (index >= 0 && index < this.tArray.Length)
			{
				this.tArray[index] = value;
			}
			else
			{
				throw new IndexOutOfRangeException("Invalid index.");
			}
		}
	}

	public void Add(T item)
	{
		this.Count++;
		this.Resize(this.Count);
		this.tArray[this.Count - 1] = item;
	}

	public void Insert(int index, T item)
	{
		if (index < 0 || index > this.tArray.Length)
		{
			throw new IndexOutOfRangeException("Invalid index.");
		}

		this.Count++;
		this.Resize(this.Count);
		Array.Copy(this.tArray, index, this.tArray, index + 1, this.Count - index - 1);
		this.tArray[index] = item;
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index > this.tArray.Length)
		{
			throw new IndexOutOfRangeException("Invalid index.");
		}

		this.Count--;
		this.Resize(this.Count);
		Array.Copy(this.tArray, index + 1, this.tArray, index, this.Count - index);
		this.tArray[index] = default(T);
	}

	public int IndexOf(T item)
	{
		return Array.IndexOf(this.tArray, item);
	}

	public bool Contains(T item)
	{
		return this.tArray.Contains(item);
	}

	public void Clear()
	{
		this.Count = 0;
		this.Capacity = DEFAULT_COUNT;
		this.tArray = new T[this.Capacity];
	}

	public override string ToString()
	{
		if (this.Count == 0)
		{
			return "Empty list!";
		}

		var result = new StringBuilder();
		result.Append("Element(s): ");
		for (int i = 0; i < this.Count; i++)
		{
			result.AppendFormat("{0}", this.tArray[i]);
			if (i + 1 < this.Count)
			{
				result.Append(", ");
			}
		}

		return result.ToString();
	}

	public T Min()
	{
		T minValue = tArray[0];
		for (int i = 0; i < tArray.Length; i++)
		{
			if (minValue > (dynamic)tArray[i])
			{
				minValue = tArray[i];
			}
		}

		return minValue;
	}

	public T Max()
	{
		T maxValue = tArray[0];
		for (int i = 0; i < tArray.Length; i++)
		{
			if (maxValue < (dynamic)tArray[i])
			{
				maxValue = tArray[i];
			}
		}

		return maxValue;
	}

	private void Resize(int capacity)
	{
		this.Capacity = 2 * capacity;
		Array.Resize(ref this.tArray, this.Capacity);
	}
}