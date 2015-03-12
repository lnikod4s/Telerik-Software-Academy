using System;
using System.Linq;

class AgeRange
{
	static void Main()
	{
		var students = new[] 
		{
								new { FirstName = "Filip", LastName = "Georgiev", Age = 19 },
								new { FirstName = "Dimityr", LastName = "Cvetkov", Age = 18 },
								new { FirstName = "Cvetelina", LastName = "Dimitrova", Age = 25 },
								new { FirstName = "Boris", LastName = "Angelov", Age = 22 },
								new { FirstName = "Angel", LastName = "Borisov", Age = 17 } 
		};

		var sortedStudents =
			from student in students
			where student.Age >= 18 && student.Age <= 24
			select student;

		Console.WriteLine("1. Using LINQ query:");
		Console.WriteLine(new string('=', 60));
		Console.WriteLine(string.Join(Environment.NewLine, sortedStudents));
		Console.WriteLine();
	}
}