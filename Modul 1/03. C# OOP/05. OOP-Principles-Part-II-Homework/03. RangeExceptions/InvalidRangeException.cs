using System;

namespace _03.RangeExceptions
{
	class InvalidRangeException<T> : ApplicationException
	{
		// Constant
		private const string ERROR_MESSAGE = "The value is out of range.";

		// Constructor
		public InvalidRangeException(T start, T end)
			: base(ERROR_MESSAGE)
		{
			this.Start = start;
			this.End = end;
		}

		// Properties
		public T Start { get; private set; }
		public T End { get; private set; }
	}
}
