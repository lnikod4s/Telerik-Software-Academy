namespace Phonebook.Command
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class ListPhonebookCommand : IPhonebookCommand
    {
        private readonly ILogger consoleLogger;
        private readonly IPhonebookRepository data;

        public ListPhonebookCommand(ILogger consoleLogger, IPhonebookRepository data)
        {
            this.consoleLogger = consoleLogger;
            this.data = data;
        }

        public void ExecuteCommand(IList<string> cmdParameters)
        {
            try
            {
                var entries = this.data.ListEntries(int.Parse(cmdParameters[0]), int.Parse(cmdParameters[1]));
                if (entries == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(entries));
                }

                foreach (var entry in entries)
                {
                    this.consoleLogger.AppendLine(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.consoleLogger.AppendLine("Invalid range");
            }
        }
    }
}