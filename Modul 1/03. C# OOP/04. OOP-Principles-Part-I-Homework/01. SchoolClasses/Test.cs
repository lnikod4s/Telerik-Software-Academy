using System;

namespace _01.SchoolClasses
{
	class Test
	{
		static void Main()
		{
			// Even with empty constructors so defined class functionalitites can be tested
			var newSchoolClass = new SchoolClass();
			Console.WriteLine(newSchoolClass);

			var newStudent = new Student();
			Console.WriteLine(newStudent);

			var newTeacher = new Teacher();
			Console.WriteLine(newTeacher);
		}
	}
}
