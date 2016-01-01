﻿using System.Globalization;
using System.Threading;
using ArmyOfCreatures.Console.Commands;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Console
{
	// No comments for you! It was hard to write so it should be hard to read.
	public static class Program
	{
		public static void Main()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

			var creaturesFactory = GetCreaturesFactory();
			ILogger logger = new ConsoleLogger();
			var battleManager = GetBattleManager(creaturesFactory, logger);

			// Process commands
			ICommandManager commandManager = new CommandManager();
			while (true)
			{
				var commandLine = System.Console.ReadLine();
				commandManager.ProcessCommand(commandLine, battleManager);
			}
		}

		private static IBattleManager GetBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
		{
			// You are allowed to add, change and remove code here
			return new ExtendedBattleManager(creaturesFactory, logger);
		}

		private static ICreaturesFactory GetCreaturesFactory()
		{
			// You are allowed to add, change and remove code here
			return new ExtendedCreaturesFactory();
		}
	}
}