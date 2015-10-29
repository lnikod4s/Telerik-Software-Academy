namespace Phonebook.Command
{
    using System.Collections.Generic;
    using Contracts;

    public class ChangePhonebookCommand : IPhonebookCommand
    {
        private readonly ILogger consoleLogger;
        private readonly IPhonebookRepository data;
        private readonly IPhonebookNumberFormatter numberFormatter;

        public ChangePhonebookCommand(
            ILogger consoleLogger, IPhonebookRepository data, IPhonebookNumberFormatter numberFormatter)
        {
            this.consoleLogger = consoleLogger;
            this.data = data;
            this.numberFormatter = numberFormatter;
        }

        public void ExecuteCommand(IList<string> cmdParameters)
        {
            this.consoleLogger.AppendLine(this.data.ChangePhone(this.numberFormatter.Format(cmdParameters[0]), this.numberFormatter.Format(cmdParameters[1])) + " numbers changed");
        }
    }
}