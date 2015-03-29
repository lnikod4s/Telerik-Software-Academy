using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareAcademy
{
	public abstract class Course : ICourse
	{
		private string name;

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

		public ITeacher Teacher { get; set; }
		public IList<string> Topics { get; set; }

		protected Course() { }
		protected Course(string name, ITeacher teacher)
		{
			this.Name = name;
			this.Teacher = teacher;
			this.Topics = new List<string>();
		}

		public void AddTopic(string topic)
		{
			this.Topics.Add(topic);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendFormat("Course: Name={0}", this.Name);
			if (this.Teacher != null)
			{
				sb.AppendFormat("; Teacher={0}", this.Teacher.Name);
			}
			if (this.Topics.Count > 0)
			{
				sb.AppendFormat("; Topics=[{0}]", string.Join(", ", this.Topics));
			}

			return sb.ToString();
		}
	}
}
