/*Problem 1. Student class

Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties.
Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
*/

using System;
using System.Collections.Generic;

namespace _01_03.StudentClass
{
	class Test
	{
		static void Main()
		{
			// Create a list of students and some students in there
			List<Student> students = new List<Student>
			                         {
				                         new Student("Todor", "Blagoev", "Petrovski",
				                                     12345, "address1", "0888 88 88 88", "todor.petrovski@gmail.com", "course1",
				                                     University.MIT, Faculty.Mathematics, Specialty.Mathematics),
				                         new Student("Anton", "Dimitrov", "Georgiev",
				                                     12345, "address2", "0888 88 88 88", "anton.georgiev@gmail.com", "course2",
				                                     University.University_of_Cambridge, Faculty.Informatics, 
													 Specialty.Computer_Science)
			                         };

			// Make a copy of the first student
			Student clonedStudent = (Student)students[1].Clone();

			// Print all students
			Console.WriteLine("***** Student 1 *****\n{0}", students[0]);
			Console.WriteLine("***** Student 2 *****\n{0}", students[1]);
			Console.WriteLine("***** Cloned student *****\n{0}", clonedStudent);

			// Testing the clonend student by Equals method and operators == and !=
			if (!students[0].Equals(clonedStudent) && students[1] == clonedStudent)
			{
				Console.WriteLine("***** Cloning is successful! *****\n");
			}
			else if (students[1] != clonedStudent)
			{
				Console.WriteLine("***** Cloning is not successful! *****\n");
			}

			// Testing the CompareTo method
			Console.WriteLine("***** Comparing *****");
			Console.WriteLine("Student 1 and Cloned student: {0}", students[0].CompareTo(clonedStudent));
			Console.WriteLine("Student 2 and Cloned student: {0}", students[1].CompareTo(clonedStudent));
		}
	}
}
