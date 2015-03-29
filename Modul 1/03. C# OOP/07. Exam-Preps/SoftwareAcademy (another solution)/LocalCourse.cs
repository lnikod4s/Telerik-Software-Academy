using System;

namespace SoftwareAcademy
{
	public class LocalCourse : Course, ILocalCourse
	{
		private string lab;
		public LocalCourse() { }

		public LocalCourse(string name, ITeacher teacher, string lab)
			: base(name, teacher) { this.Lab = lab; }

		public string Lab
		{
			get { return this.lab; }
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("Local course's lab is null or empty.");
				}

				this.lab = value;
			}
		}

		public override string ToString() { return "Local" + base.ToString() + "; Lab=" + this.Lab; }
	}
}