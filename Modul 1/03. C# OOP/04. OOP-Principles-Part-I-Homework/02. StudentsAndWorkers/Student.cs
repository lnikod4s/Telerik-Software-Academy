using System.Text;

namespace _02.StudentsAndWorkers
{
	class Student : Human
	{
		// Fields
		private double grade;

		// Constructors
		public Student()
			: this("Petkan", "Bezizvesten", 2.49)
		{
		}

		public Student(string firstName, string lastName, double grade)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Grade = grade;
		}

		// Properties
		public double Grade { get; set; }

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
			result.AppendFormat("First name: {0}\n", FirstName);
			result.AppendFormat("Last name: {0}\n", LastName);
			result.AppendFormat("Grade: {0}\n", Grade);
			return result.ToString();
		}

		#endregion
	}
}
