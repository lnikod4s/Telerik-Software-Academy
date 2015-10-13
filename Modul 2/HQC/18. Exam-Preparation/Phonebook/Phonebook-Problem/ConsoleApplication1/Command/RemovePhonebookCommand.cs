namespace Phonebook.Command
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Contracts;

    public class RemovePhonebookCommand : IPhonebookCommand
    {
        private readonly ILogger logger;

        public RemovePhonebookCommand(ILogger logger)
        {
            this.logger = logger;
        }

        public void ExecuteCommand(IList<string> cmdParameters)
        {
            var phoneNumber = cmdParameters[0];
            if (!this.IsValidPhone(phoneNumber))
            {
                this.logger.AppendLine("Invalid phone number");
            }

            if (cmdParameters.Contains(phoneNumber))
            {
                cmdParameters.Remove(phoneNumber);
            }
            else
            {
                this.logger.AppendLine("Phone number could not be found");
            }
        }

        private bool IsValidPhone(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            var regex = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
            return regex.IsMatch(phoneNumber);
        }
    }
}