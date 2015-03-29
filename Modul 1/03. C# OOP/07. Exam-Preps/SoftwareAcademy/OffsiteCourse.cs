using System;

namespace SoftwareAcademy
{
	public class OffsiteCourse : Course, IOffsiteCourse
	{
		private string town;

		public string Town
		{
			get { return this.town; }
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("Town is null or empty.");
				}

				this.town = value;
			}
		}

		public OffsiteCourse() { }
		public OffsiteCourse(string name, ITeacher teacher, string town)
			: base(name, teacher) { this.Town = town; }

		public override string ToString() { return "Offsite" + base.ToString() + "; Town=" + this.Town; }
	}
}
