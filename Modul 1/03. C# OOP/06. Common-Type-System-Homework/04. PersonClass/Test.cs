/*Problem 4. Person class

Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so.
Write a program to test this functionality.
*/

using System;
using System.Collections.Generic;

namespace _04.PersonClass
{
	class Test
	{
		static void Main()
		{
			// Create a list of people and add some people in there
			List<Person> people = new List<Person>
			                      {
				                      new Person("Ivan Petrov", null),
				                      new Person("Maria Ilieva", 32),
				                      new Person("Stefan Kirov", 27),
				                      new Person("Nadia Ivanova", null)
			                      };

			// Print the result
			foreach (Person person in people)
			{
				Console.WriteLine(person);
			}
		}
	}
}
