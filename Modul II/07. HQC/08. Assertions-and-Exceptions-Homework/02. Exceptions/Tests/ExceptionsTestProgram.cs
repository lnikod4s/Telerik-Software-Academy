using System;
using System.Collections.Generic;

namespace Exceptions
{
	internal class ExceptionsTestProgram
	{
		static void Main()
		{
			var substr = Helpers.HelperMethods.Subsequence("Hello!".ToCharArray(), 2, 3);
			Console.WriteLine(substr);

			var subarr = Helpers.HelperMethods.Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
			Console.WriteLine(string.Join(" ", subarr));

			var allarr = Helpers.HelperMethods.Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
			Console.WriteLine(string.Join(" ", allarr));

			var emptyarr = Helpers.HelperMethods.Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
			Console.WriteLine(string.Join(" ", emptyarr));

			Console.WriteLine(Helpers.HelperMethods.ExtractEnding("I love C#", 2));
			Console.WriteLine(Helpers.HelperMethods.ExtractEnding("Nakov", 4));
			Console.WriteLine(Helpers.HelperMethods.ExtractEnding("beer", 4));
			Console.WriteLine(Helpers.HelperMethods.ExtractEnding("Hi", 100));

			try
			{
				Helpers.HelperMethods.CheckPrime(23);
				Console.WriteLine("23 is prime.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("23 is not prime.");
				Console.WriteLine("ErrorMessage: {0}", ex.Message);
			}

			try
			{
				Helpers.HelperMethods.CheckPrime(33);
				Console.WriteLine("33 is prime.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("33 is not prime");
				Console.WriteLine("ErrorMessage: {0}", ex.Message);
			}

			var peterExams = new List<Exam>
									{
				                        new SimpleMathExam(2),
										new CSharpExam(55),
										new CSharpExam(100),
										new SimpleMathExam(1),
										new CSharpExam(0)
			                        };
			var peter = new Student("Peter", "Petrov", peterExams);
			double peterAverageResult = peter.CalcAverageExamResultInPercents();
			Console.WriteLine("Average results = {0:p0}", peterAverageResult);
		}
	}
}
