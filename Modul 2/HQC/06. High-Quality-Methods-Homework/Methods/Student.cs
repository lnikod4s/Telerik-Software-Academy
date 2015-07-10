using System;

namespace Methods
{
	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string OtherInfo { get; set; }

		public bool IsOlderThan(Student other)
		{
			var firstDate = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
			var secondDate = DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
			return firstDate > secondDate;
		}
	}
}