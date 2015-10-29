namespace Phonebook.Command
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class AddPhonebookCommand : IPhonebookCommand
    {
        private readonly ILogger consoleLogger;
        private readonly IPhonebookRepository data;
        private readonly IPhonebookNumberFormatter numberFormatter;

        public AddPhonebookCommand(ILogger consoleLogger, IPhonebookRepository data, IPhonebookNumberFormatter numberFormatter)
        {
            this.consoleLogger = consoleLogger;
            this.data = data;
            this.numberFormatter = numberFormatter;
        }

        public void ExecuteCommand(IList<string> cmdParameters)
        {
            var name = cmdParameters[0];
            var listOfPhones = cmdParameters.Skip(1).ToList();
            for (var i = 0; i < listOfPhones.Count; i++)
            {
                listOfPhones[i] = this.numberFormatter.Format(listOfPhones[i]);
            }

            var isPhoneEntryCreated = this.data.AddPhone(name, listOfPhones);
            this.consoleLogger.AppendLine(isPhoneEntryCreated ? "Phone entry created" : "Phone entry merged");
        }
    }
}