using System.Collections.Generic;
using System.Text;

namespace _01.SchoolClasses
{
	class Teacher : People
	{
		// Fields
		private List<Discipline> disciplines;
		private double ratingAmongStudents;

		// Constructors
		public Teacher()
			: this("Mr. Frankenstein", 99, "unspecified", new List<Discipline>(), 0.0)
		{
		}

		public Teacher(string fullName, byte age, string gender, List<Discipline> disciplines, double ratingAmongStudents)
		{
			this.Fullname = fullName;
			this.Age = age;
			this.Gender = gender;
			this.Disciplines = disciplines;
			this.RatingAmongStudents = ratingAmongStudents;
		}

		// Properties
		public List<Discipline> Disciplines { get; set; }

		public double RatingAmongStudents { get; set; }

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
			result.AppendFormat("Full name: {0}\n", Fullname);
			result.AppendFormat("Age: {0}\n", Age);
			result.AppendFormat("Gender: {0}\n", Gender);
			result.AppendFormat("Teaching disciplines: {0}\n", Disciplines.Count);
			result.AppendFormat("Rating among stundents: {0}\n", RatingAmongStudents);
			return result.ToString();
		}

		#endregion
	}
}
