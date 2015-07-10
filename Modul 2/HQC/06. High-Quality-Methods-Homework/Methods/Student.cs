using System;

namespace Methods
{
	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string OtherInfo { get; set; }

		public bool IsOlderThan(Student anotherStudent)
		{
			var firstDate = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
			var secondDate = DateTime.Parse(anotherStudent.OtherInfo.Substring(anotherStudent.OtherInfo.Length - 10));
			return firstDate > secondDate;
		}
	}
}