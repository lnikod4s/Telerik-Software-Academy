namespace Phonebook
{
    using System;
    using Contracts;
    using Helpers;

    internal class PhonebookEntryPoint
    {
        private static void Main()
        {
            ILogger logger = new ConsoleLogger();
            IPhonebookRepository repository = new PhonebookRepository();
            IPhonebookNumberFormatter numberFormatter = new PhoneNumberFormatter();
            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(logger, repository, numberFormatter);

            while (true)
            {
                var textLine = Console.ReadLine();
                if (textLine == "End" || textLine == null)
                {
                    break;
                }

                var firstOpeningBracketIndex = textLine.IndexOf('(');
                if (firstOpeningBracketIndex == -1)
                {
                    throw new ArgumentException("Invalid input data.");
                }

                var cmd = textLine.Substring(0, firstOpeningBracketIndex);
                if (!textLine.EndsWith(")"))
                {
                    throw new ArgumentException("Invalid input data.");
                }

                var phoneEntryData = textLine.Substring(
                    firstOpeningBracketIndex + 1, textLine.Length - firstOpeningBracketIndex - 2);
                var splittedCmdParameters = phoneEntryData.Split(',');
                for (var j = 0; j < splittedCmdParameters.Length; j++)
                {
                    splittedCmdParameters[j] = splittedCmdParameters[j].Trim();
                }

                var command = commandFactory.CreateCommand(cmd, splittedCmdParameters.Length);
                command.ExecuteCommand(splittedCmdParameters);
            }

            logger.PrintAll();
        }
    }
}