using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
	internal class CoursesExamples
	{
		private static void Main()
		{
			var localCourse = new LocalCourse("Databases");
			Console.WriteLine(localCourse);

			localCourse.Lab = "Enterprise";
			Console.WriteLine(localCourse);

			localCourse.Students = new List<string> {"Peter", "Maria"};
			Console.WriteLine(localCourse);

			localCourse.TeacherName = "Svetlin Nakov";
			localCourse.Students.Add("Milena");
			localCourse.Students.Add("Todor");
			Console.WriteLine(localCourse);

			var offsiteCourse = new OffsiteCourse(
				"PHP and WordPress Development", "Mario Peshev",
				new List<string> {"Thomas", "Ani", "Steve"});
			Console.WriteLine(offsiteCourse);
		}
	}
}