namespace _02.StudentsAndWorkers
{
	public abstract class Human
	{
		// Fields
		private string firstName;
		private string lastName;

		// Constructors
		protected Human()
			: this("Unknown", "Unknown")
		{
		}

		protected Human(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		// Properties
		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
