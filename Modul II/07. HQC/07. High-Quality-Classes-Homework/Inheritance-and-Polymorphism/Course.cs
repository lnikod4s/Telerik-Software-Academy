using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
	internal abstract class Course
	{
		internal readonly IList<string> students;
		internal string courseName;
		internal string teacherName;
		internal Course() { }

		internal Course(string name)
		{
			this.courseName = name;
			this.teacherName = null;
			this.students = new List<string>();
		}

		internal Course(string courseName, string teacherName)
		{
			this.courseName = courseName;
			this.teacherName = teacherName;
			this.students = new List<string>();
		}

		internal Course(string courseName, string teacherName, IList<string> students)
		{
			this.courseName = courseName;
			this.teacherName = teacherName;
			this.students = students;
		}

		internal string GetStudentsAsString()
		{
			if (this.students == null ||
			    this.students.Count == 0)
			{
				return "{ }";
			}
			else
			{
				return "{ " + string.Join(", ", this.students) + " }";
			}
		}
	}
}