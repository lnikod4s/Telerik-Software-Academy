using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InheritanceAndPolymorphism
{
	internal class OffsiteCourse : Course
	{
		internal string town;
		internal OffsiteCourse() { this.town = null; }
		internal OffsiteCourse(string name) : base(name) { }
		internal OffsiteCourse(string courseName, string teacherName) : base(courseName, teacherName) { }

		internal OffsiteCourse(string courseName, string teacherName, IList<string> students)
			: base(courseName, teacherName, students)
		{
		}

		internal string Name
		{
			get { return this.courseName; }
			set
			{
				if (!Regex.IsMatch(value, "^[a-zA-Z\\s]+$"))
				{
					throw new ArgumentException("Invalid course name.");
				}

				this.courseName = value;
			}
		}

		internal string TeacherName
		{
			get { return this.teacherName; }
			set
			{
				if (!Regex.IsMatch(value, "^[a-zA-Z\\s]+$"))
				{
					throw new ArgumentException("Invalid teacher name.");
				}

				this.teacherName = value;
			}
		}

		internal IList<string> Students { get; set; }

		internal string Town
		{
			get { return this.town; }
			set
			{
				if (!Regex.IsMatch(value, "^[a-zA-Z\\s]+$"))
				{
					throw new ArgumentException("Invalid town name.");
				}

				this.town = value;
			}
		}

		public override string ToString()
		{
			var result = new StringBuilder();
			result.Append("OffsiteCourse { Name = ");
			result.Append(this.Name);

			if (this.TeacherName != null)
			{
				result.Append("; Teacher = ");
				result.Append(this.TeacherName);
			}

			result.Append("; Students = ");
			result.Append(this.GetStudentsAsString());

			if (this.Town != null)
			{
				result.Append("; Town = ");
				result.Append(this.Town);
			}

			result.Append(" }");
			return result.ToString();
		}
	}
}