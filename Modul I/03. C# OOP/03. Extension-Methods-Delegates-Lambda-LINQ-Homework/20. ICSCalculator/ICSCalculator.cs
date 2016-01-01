using System;
using System.Collections.Generic;
using System.Linq;

namespace _20.ICSCalculator
{
	/// <summary>
	/// Problem 20.* Infinite convergent series
	/// By using delegates develop an universal static method to calculate the sum of infinite convergent series with given precision depending on 
	/// a function of its term. By using proper functions for the term calculate with a 2-digit precision the sum of the infinite series:
	/// 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
	/// 1 + 1/2! + 1/3! + 1/4! + 1/5! + …
	/// 1 + 1/2 - 1/4 + 1/8 - 1/16 + …
	/// </summary>
	class ICSCalculator
	{
		public static double precision = 0.0;
		public static int digitsToUse = 0;

		public static List<string> functionElements = new List<string>();
		public static List<char> functionSigns = new List<char>();

		public static double answer = 0;
		public static double prevAnswer = 0;

		public static bool useOneSide = false;

		public static bool factorielUp = false;
		public static bool factorielDown = false;

		public static double elementToUseNextUP = 0;
		public static double elementToUseNextDown = 0;

		public static double elementCreatorUp = 0;
		public static double elementCreatorDown = 0;

		public static int counterToShowAsInformation = 0;

		public static Action ICSOperations;

		public static Func<double, double, double> GetNextElementUp;
		public static Func<double, double, double> GetNextElementDown;


		static void Main()
		{
			ReadInput();
			PutFirstFunctionElementAsAnswer();
			InicializeDelegateWithProperActions();
			GenerateNextElementGenerator();
			GenerateFirstElementsToUse();

			Console.WriteLine("--------------");
			Console.WriteLine("Element {0} is {1} ", ++counterToShowAsInformation, answer);

			while (Math.Abs(answer - prevAnswer) > precision)
			{
				ICSOperations();
				if (counterToShowAsInformation >= 100000)
				{
					Console.WriteLine("This series is not convergent !");
					return;
				}
			}

			Console.WriteLine("--------------");
			Console.WriteLine("Final answer : ");
			Console.WriteLine(Math.Round(answer, digitsToUse));
		}

		private static double Sum(double one, double two)
		{
			return one + two;
		}

		private static double Multiplication(double one, double two)
		{
			return one * two;
		}

		private static double GetFactoriel(double number)
		{
			double result = 1;
			for (int i = 1; i <= number; i++)
			{
				result *= (i);
			}

			return result;
		}

		private static void VoidSum()
		{
			prevAnswer = answer;

			double createElement = CreateNextElement();

			Console.WriteLine("Element {0} is {1} ", ++counterToShowAsInformation, createElement);

			answer = prevAnswer + createElement;
		}

		private static void VoidSubstraction()
		{
			prevAnswer = answer;

			double createElement = CreateNextElement();

			Console.WriteLine("Element {0} is {1} ", ++counterToShowAsInformation, createElement);

			answer = prevAnswer - createElement;
		}

		private static double CreateNextElement()
		{
			double createElement = elementToUseNextUP;
			if (factorielUp)
			{
				createElement = GetFactoriel(createElement);
			}

			if (!useOneSide)
			{
				double botElement = elementToUseNextDown;

				if (factorielDown)
				{
					botElement = GetFactoriel(botElement);
				}

				createElement = createElement / botElement;

				elementToUseNextDown = GetNextElementDown(elementToUseNextDown, elementCreatorDown);
			}

			elementToUseNextUP = GetNextElementUp(elementToUseNextUP, elementCreatorUp);

			return createElement;
		}

		private static void GenerateFirstElementsToUse()
		{
			if (!useOneSide)
			{
				string[] upDown = functionElements[0].Split('/');

				elementToUseNextUP = double.Parse(upDown[0].TrimEnd('!'));
				elementToUseNextDown = double.Parse(upDown[1].TrimEnd('!'));
			}
			else
			{
				elementToUseNextUP = double.Parse(functionElements[0].TrimEnd('!'));
			}
		}

		private static double GetElementFromStringOperations(string StringOperations)
		{
			double answerToReturn = 0;

			if (StringOperations.Contains('/'))
			{
				string[] upDown = StringOperations.Split('/');
				double up = 0;
				double down = 0;

				up = upDown[0].EndsWith("!") ? 
					GetFactoriel(double.Parse(upDown[0].TrimEnd('!'))) : 
					double.Parse(upDown[0]);

				down = upDown[1].EndsWith("!") ? 
					GetFactoriel(double.Parse(upDown[1].TrimEnd('!'))) : 
					double.Parse(upDown[1]);

				answerToReturn = up / down;
			}
			else
			{
				answerToReturn = StringOperations.EndsWith("!") ? 
					GetFactoriel(Math.Abs(double.Parse(StringOperations.TrimEnd('!')))) : 
					Math.Abs(double.Parse(StringOperations));
			}

			return answerToReturn;
		}

		private static void PutFirstFunctionElementAsAnswer()
		{
			answer = GetElementFromStringOperations(functionElements[0]);

			functionElements.RemoveAt(0);

			if (functionSigns.Count == 5)
			{
				if (functionSigns[0] == '-')
				{
					answer *= -1;
				}
				functionSigns.RemoveAt(0);
			}
		}

		private static void GenerateNextElementGenerator()
		{
			int countDivisionSighns = functionElements.Count(x => x.Contains('/'));

			if (countDivisionSighns == 0)
			{
				GenerateNextElementGeneratorWithNoDivision();
			}
			else if (countDivisionSighns == 4)
			{
				GenerateNextElementGeneratorWithAllDivision();
			}
			else
			{
				throw new ArgumentException("Can not find a logical pattern");
			}
		}

		private static void GenerateNextElementGeneratorWithAllDivision()
		{
			double[] upperElements = new double[4];
			double[] bottomElements = new double[4];

			for (int i = 0; i < 4; i++)
			{
				string[] upDown = functionElements[i].Split('/');

				if (upDown[0].EndsWith("!"))
				{
					factorielUp = true;
					upDown[0] = upDown[0].TrimEnd('!');
				}
				if (upDown[1].EndsWith("!"))
				{
					factorielDown = true;
					upDown[1] = upDown[1].TrimEnd('!');
				}

				upperElements[i] = double.Parse(upDown[0]);
				bottomElements[i] = double.Parse(upDown[1]);
			}

			if (upperElements[1] - upperElements[0] == upperElements[2] - upperElements[1]
				&& upperElements[3] - upperElements[2] == upperElements[2] - upperElements[1])
			{
				elementCreatorUp = upperElements[1] - upperElements[0];
				GetNextElementUp = Sum;
			}
			else if (upperElements[1] / upperElements[0] == upperElements[2] / upperElements[1]
				&& upperElements[3] / upperElements[2] == upperElements[2] / upperElements[1])
			{
				elementCreatorUp = upperElements[1] / upperElements[0];
				GetNextElementUp = Multiplication;
			}
			else
			{
				throw new ArgumentException("Can not find suitable pattern!");
			}

			if (bottomElements[1] - bottomElements[0] == bottomElements[2] - bottomElements[1]
				&& bottomElements[3] - bottomElements[2] == bottomElements[2] - bottomElements[1])
			{
				elementCreatorDown = bottomElements[1] - bottomElements[0];
				GetNextElementDown = Sum;
			}
			else if (bottomElements[1] / bottomElements[0] == bottomElements[2] / bottomElements[1]
				&& bottomElements[3] / bottomElements[2] == bottomElements[2] / bottomElements[1])
			{
				elementCreatorDown = bottomElements[1] / bottomElements[0];
				GetNextElementDown = Multiplication;
			}
			else
			{
				throw new ArgumentException("Can not find suitable pattern!");
			}
		}

		private static void GenerateNextElementGeneratorWithNoDivision()
		{
			useOneSide = true;

			if (functionElements[0].EndsWith("!"))
			{
				factorielUp = true;
				functionElements = functionElements.Select(x => x.TrimEnd('!')).ToList();
			}

			double[] elements = functionElements.Select(double.Parse).ToArray();

			if (elements[1] - elements[0] == elements[2] - elements[1]
				&& elements[3] - elements[2] == elements[2] - elements[1])
			{
				elementCreatorUp = elements[1] - elements[0];
				GetNextElementUp = Sum;
			}
			else if (elements[1] / elements[0] == elements[2] / elements[1]
				&& elements[3] / elements[2] == elements[2] / elements[1])
			{
				elementCreatorUp = elements[1] / elements[0];
				GetNextElementUp = Multiplication;
			}
			else
			{
				throw new ArgumentException("Can not find suitable pattern!");
			}
		}

		private static void InicializeDelegateWithProperActions()
		{
			for (int i = 0; i < 4; i++)
			{
				if (functionSigns[i] == '+')
				{
					ICSOperations += VoidSum;
				}
				else
				{
					ICSOperations += VoidSubstraction;
				}
			}
		}

		private static void ReadInput()
		{
			Console.WriteLine("Take a look at the given examples:");
			Console.WriteLine("1! + 2! – 3! + 4! -5!");
			Console.WriteLine("1 + 1/2 + 1/3 + 1/4 + 1/5");
			Console.WriteLine("1 + 1/2! + 1/4! + 1/8! + 1/16!");
			Console.WriteLine("1 + 1/2! + 1/3! + 1/4! + 1/5!");
			Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16");
			Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16");
			Console.WriteLine("So, now enter the first 5 elements of the function: ");

			string function = Console.ReadLine();

			function = function.Replace(" ", "");

			functionElements = function.Split(new[] { '-', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();

			functionSigns = function.Where(x => x == '-' || x == '+').ToList();

			Console.WriteLine("Enter how many signs precision do you want:");
			digitsToUse = int.Parse(Console.ReadLine());
			precision = 1.0 / Math.Pow(10, digitsToUse);
		}
	}
}
