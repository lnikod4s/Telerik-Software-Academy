using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _05._64BitArray
{
	class BitArray64 : IEnumerable<int>
	{
		// Property
		public ulong Number { get; private set; }

		// Constructors
		public BitArray64() { }
		public BitArray64(ulong number)
		{
			this.Number = number;
		}

		// Indexator
		public int this[int index]
		{
			get
			{
				if (index < 0 || index > 63)
				{
					throw new IndexOutOfRangeException();
				}
				else
				{
					return (this.Number & ((ulong)1 << index)) == 0 ? 0 : 1;
				}
			}
			set
			{
				if (index < 0 || index > 63)
				{
					throw new IndexOutOfRangeException();
				}
				if (value != 0 && value != 1)
				{
					throw new ArgumentOutOfRangeException();
				}

				this.Number = (this.Number & ~((ulong)1 << index) | ((ulong)value << index));
			}
		}

		// Returns an enumerator that iterates through a collection
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 0; i < 64; i++)
			{
				yield return this[i];
			}
		}

		#region Overrides of Object
		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified object  is equal to the current object; otherwise, false.
		/// </returns>
		/// <param name="obj">The object to compare with the current object. </param>
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else
			{
				return this.Number.Equals((obj as BitArray64).Number);
			}
		}
		#endregion

		// Boolean operator ==
		public static bool operator ==(BitArray64 first, BitArray64 second)
		{
			return first.Equals(second);
		}

		// Boolean operator !=
		public static bool operator !=(BitArray64 first, BitArray64 second)
		{
			return !first.Equals(second);
		}

		#region Overrides of Object
		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		public override int GetHashCode()
		{
			return this.Number.GetHashCode();
		}
		#endregion

		#region Overrides of Object
		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			var result = new StringBuilder();
			for (int i = 0; i < 64; i += 4)
			{
				result.AppendFormat("[{0}]={1} \t[{2}]={3} \t[{4}]={5} \t[{6}]={7}\n",
					i, this[i], i + 1, this[i + 1], i + 2, this[i + 2], i + 3, this[i + 3]);
			}

			return result.ToString();
		}
		#endregion
	}
}
