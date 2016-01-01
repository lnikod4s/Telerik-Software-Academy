using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SchoolClasses
{
	class Student : People
	{
		// Fields
		private byte ucn;
		private List<double> notes;
 
		// Constructors
		public Student()
			: this("Petkan", 10, "male", 17, new List<double>())
		{
		}

		public Student(string fullname, byte age, string gender, byte ucn, List<double> notes)
		{
			this.Fullname = fullname;
			this.Age = age;
			this.Gender = gender;
			this.UniqueClassNumber = ucn;
			this.Notes = notes;
		}

		// Properties
		public byte UniqueClassNumber { get; set; }

		public List<double> Notes { get; set; }

		// Methods
		public double GetAverageNote()
		{
			int notesCounts = Notes.Count;
			return this.Notes.Sum() / notesCounts;
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
			result.AppendFormat("Full name: {0}\n", Fullname);
			result.AppendFormat("Age: {0}\n", Age);
			result.AppendFormat("Gender: {0}\n", Gender);
			result.AppendFormat("Unique class number: {0}\n", UniqueClassNumber);
			result.AppendFormat("Number of notes: {0}\n", Notes.Count);
			return result.ToString();
		}

		#endregion
	}
}
