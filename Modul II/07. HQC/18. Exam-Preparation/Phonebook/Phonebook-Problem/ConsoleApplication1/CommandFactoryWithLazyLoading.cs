namespace Phonebook
{
    using System;
    using Command;
    using Contracts;

    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private readonly ILogger consoleLogger;
        private readonly IPhonebookRepository data;
        private readonly IPhonebookNumberFormatter numberFormatter;

        private IPhonebookCommand addCommand;
        private IPhonebookCommand changeCommand;
        private IPhonebookCommand listCommand;

        public CommandFactoryWithLazyLoading(
            ILogger consoleLogger, IPhonebookRepository data, IPhonebookNumberFormatter numberFormatter)
        {
            this.consoleLogger = consoleLogger;
            this.data = data;
            this.numberFormatter = numberFormatter;
        }

        public IPhonebookCommand CreateCommand(string commandName, int argumentsCount)
        {
            IPhonebookCommand command;

            if (commandName.StartsWith("AddPhone") && argumentsCount >= 2)
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new AddPhonebookCommand(this.consoleLogger, this.data, this.numberFormatter);
                }

                command = this.addCommand;
            }
            else if ((commandName == "ChangePhone") && (argumentsCount == 2))
            {
                if (this.changeCommand == null)
                {
                    this.changeCommand = new ChangePhonebookCommand(this.consoleLogger, this.data, this.numberFormatter);
                }

                command = this.changeCommand;
            }
            else if ((commandName == "List") && (argumentsCount == 2))
            {
                if (this.listCommand == null)
                {
                    this.listCommand = new ListPhonebookCommand(this.consoleLogger, this.data);
                }

                command = this.listCommand;
            }
            else
            {
                throw new StackOverflowException();
            }

            return command;
        }
    }
}