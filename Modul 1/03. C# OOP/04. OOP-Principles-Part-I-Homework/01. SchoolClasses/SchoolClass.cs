using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SchoolClasses
{
	class SchoolClass
	{
		// Fields
		private List<Student> students;
		private List<Teacher> teachers;
		private string textID;

		// Constructors
		public SchoolClass()
			: this("A", new List<Student>(), new List<Teacher>())
		{
		}

		public SchoolClass(string textID, List<Student> students, List<Teacher> teachers)
		{
			this.TextID = textID;
			this.Students = students;
			this.Teachers = teachers;
		}

		// Properties
		public List<Student> Students { get; set; }

		public List<Teacher> Teachers { get; set; }

		public string TextID { get; set; }

		// Methods
		public double GetAverageNote()
		{
			int stundentsCount = Students.Count;
			return this.Students.SelectMany(student => student.Notes).Sum() / stundentsCount;
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
			result.AppendFormat("Class unique text identifier: {0}\n", TextID);
			result.AppendFormat("Number of students in class: {0}\n", Students.Count);
			return result.ToString();
		}

		#endregion
	}
}
