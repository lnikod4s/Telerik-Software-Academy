using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public int Rank { get; set; }

	public string Position { get; set; }
}

class Employees
{
	/// <summary>
	/// C# Fundamentals 2011/2012 Part 2 - Sample Exam
	/// Problem 3 Employees
	/// </summary>

	static void Main()
	{
		int posCount = int.Parse(Console.ReadLine());

		var posAndRank = new Dictionary<string, int>();
		for (int i = 0; i < posCount; i++)
		{
			string currLine = Console.ReadLine();

			string[] rawInput = currLine.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

			if (!posAndRank.ContainsKey(rawInput[0]))
			{
				posAndRank.Add(rawInput[0], int.Parse(rawInput[1]));
			}
		}

		int numberOfEmployees = int.Parse(Console.ReadLine());

		var employees = new List<Employee>();
		for (int i = 0; i < numberOfEmployees; i++)
		{
			string currLine = Console.ReadLine();

			string[] rawInput = currLine.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

			string[] splittedNames = rawInput[0].Split();

			var currEmployee = new Employee
							   {
								   FirstName = splittedNames[0],
								   LastName = splittedNames[1],
								   Position = rawInput[1]

							   };
			currEmployee.Rank = posAndRank[currEmployee.Position];

			employees.Add(currEmployee);
		}

		var sortedEmployees = employees.OrderByDescending(x => x.Rank)
		                               .ThenBy(x => x.LastName)
		                               .ThenBy(x => x.FirstName);

		foreach (var employee in sortedEmployees)
		{
			Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
		}
	}
}