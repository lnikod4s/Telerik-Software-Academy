using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InheritanceAndPolymorphism
{
	internal class LocalCourse : Course
	{
		internal string lab;
		internal LocalCourse() { this.lab = null; }
		internal LocalCourse(string name) : base(name) { }
		internal LocalCourse(string courseName, string teacherName) : base(courseName, teacherName) { }

		internal LocalCourse(string courseName, string teacherName, IList<string> students)
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

		internal string Lab
		{
			get { return this.lab; }
			set
			{
				if (!Regex.IsMatch(value, "^[a-zA-Z\\s]+$"))
				{
					throw new ArgumentException("Invalid lab name.");
				}

				this.lab = value;
			}
		}

		public override string ToString()
		{
			var result = new StringBuilder();
			result.Append("LocalCourse { Name = ");
			result.Append(this.Name);

			if (this.TeacherName != null)
			{
				result.Append("; Teacher = ");
				result.Append(this.TeacherName);
			}

			result.Append("; Students = ");
			result.Append(this.GetStudentsAsString());

			if (this.Lab != null)
			{
				result.Append("; Lab = ");
				result.Append(this.Lab);
			}

			result.Append(" }");
			return result.ToString();
		}
	}
}