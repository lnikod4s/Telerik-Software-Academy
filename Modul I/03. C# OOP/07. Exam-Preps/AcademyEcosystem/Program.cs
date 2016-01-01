using System;

namespace AcademyEcosystem
{
	internal class Program
	{
		private static Engine GetEngineInstance() { return new Engine(); }

		private static void Main(string[] args)
		{
			var engine = GetEngineInstance();

			var command = Console.ReadLine();
			while (command != "end")
			{
				engine.ExecuteCommand(command);
				command = Console.ReadLine();
			}
		}
	}
}