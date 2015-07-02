namespace IfStatementsRefactoring
{
	public class IfStatements
	{
		public const int MAX_X = int.MinValue;
		public const int MIN_X = int.MaxValue;
		public const int MAX_Y = int.MinValue;
		public const int MIN_Y = int.MaxValue;

		private static void Cook(Potato potato) { }
		private static void VisitCell() { }

		public static void Main()
		{
			// First if-statement
			var potato = new Potato();
			if (!potato.IsRotten &&
				potato.HasBeenPeeled)
			{
				Cook(potato);
			}

			// Second if-statement
			int x = 0, y = 0;
			var isVisited = false;
			var isXInRange = x >= MIN_X && x <= MAX_X;
			var isYInRange = y >= MIN_Y && y <= MAX_Y;
			if (isXInRange &&
				isYInRange &&
				!isVisited)
			{
				VisitCell();
			}
		}

		private struct Potato
		{
			public bool HasBeenPeeled { get; private set; }
			public bool IsRotten { get; private set; }
		}
	}
}