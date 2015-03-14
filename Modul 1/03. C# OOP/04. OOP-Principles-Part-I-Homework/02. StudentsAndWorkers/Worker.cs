using System.Text;

namespace _02.StudentsAndWorkers
{
	class Worker : Human
	{
		// Fields
		private double weekSalary;
		private double workHoursPerDay;

		// Constructors
		public Worker()
			: this("Gosho", "Bezizvesten", 40, 8)
		{
		}

		public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.WeekSalary = weekSalary;
			this.WorkHoursPerDay = workHoursPerDay;
		}

		// Properties
		public double WeekSalary { get; set; }

		public double WorkHoursPerDay { get; set; }

		// Methods
		public double MoneyPerHour()
		{
			return this.WeekSalary / (this.WorkHoursPerDay * 5);
		}

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
			result.AppendFormat("Week salary: {0}\n", WeekSalary);
			result.AppendFormat("Work hours per day: {0}\n", WorkHoursPerDay);
			result.AppendFormat("Money per hour: {0:F2}\n", MoneyPerHour());
			return result.ToString();
		}

		#endregion
	}
}
