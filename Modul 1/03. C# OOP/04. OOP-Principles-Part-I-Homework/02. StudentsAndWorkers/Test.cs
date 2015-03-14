using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StudentsAndWorkers
{
	class Test
	{
		static void Main()
		{
			var students = new List<Student>
			               {
				               new Student("Pesho", "Vasilev", 3.46),
							   new Student("Gosho", "Petrakiev", 2.98),
							   new Student("Dragan", "Tzvetkov", 4.5),
							   new Student("Emil", "Kodjabashev", 5.6),
							   new Student("Vasil", "Dragoev", 3.78),
							   new Student("Petko", "Atanasov", 3.9),
							   new Student("Merhat", "Petrakiev", 5.46),
							   new Student("Todor", "Petrovski", 2.49),
							   new Student("Anton", "Georgiev", 2.34),
							   new Student("Martin", "Tsvetanov", 4.76),
							   new Student("Marin", "Apostolov", 6.00)
			               };

			var sortdedStudents = students.OrderBy(st => st.Grade);
			Console.WriteLine("***** Sorted students *****\n");
			foreach (var student in sortdedStudents)
			{
				Console.WriteLine(student);
			}

			var workers = new List<Worker>
			               {
				               new Worker("Pesho", "Vasilev", 127.76, 8),
							   new Worker("Gosho", "Petrakiev", 134.78, 7),
							   new Worker("Dragan", "Tzvetkov", 154.34, 8),
							   new Worker("Emil", "Kodjabashev", 257.89, 8),
							   new Worker("Vasil", "Dragoev", 327.8, 7),
							   new Worker("Petko", "Atanasov", 167.9, 8),
							   new Worker("Merhat", "Petrakiev", 137.89, 6),
							   new Worker("Todor", "Petrovski", 267.45, 8),
							   new Worker("Anton", "Georgiev", 231.45, 9),
							   new Worker("Martin", "Tsvetanov", 90.67, 6),
							   new Worker("Marin", "Apostolov", 126.9, 9)
			               };

			var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour());
			Console.WriteLine("***** Sorted workers *****\n");
			foreach (var worker in sortedWorkers)
			{
				Console.WriteLine(worker);
			}

			var mergedList = new List<Human>();
			mergedList.AddRange(sortdedStudents);
			mergedList.AddRange(sortedWorkers);

			var sortedList = mergedList.OrderBy(x => x.FirstName)
			                           .ThenBy(x => x.LastName);

			Console.WriteLine("***** Merged and sorted list of students and workers *****\n");
			foreach (var human in sortedList)
			{
				Console.WriteLine(human);
			}
		}
	}
}
