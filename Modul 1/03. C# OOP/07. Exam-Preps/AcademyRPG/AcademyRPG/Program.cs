using System;

namespace AcademyRPG
{
	internal class Program
	{
		private static Engine GetEngineInstance() { return new ExtendedEngine(); }

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