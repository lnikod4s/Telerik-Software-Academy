using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
	public class Teacher : ITeacher
	{
		private string name;
		public Teacher() { }

		public Teacher(string name)
		{
			this.Name = name;
			this.Courses = new List<ICourse>();
		}

		public IList<ICourse> Courses { get; private set; }

		public string Name
		{
			get { return this.name; }
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("Teacher's name is null or empty.");
				}

				this.name = value;
			}
		}

		public void AddCourse(ICourse course) { this.Courses.Add(course); }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendFormat("Teacher: Name={0}", this.Name);
			if (this.Courses.Count > 0)
			{
				sb.AppendFormat("; Courses=[{0}]", string.Join(", ", this.Courses.Select(c => c.Name)));
			}

			return sb.ToString();
		}
	}
}