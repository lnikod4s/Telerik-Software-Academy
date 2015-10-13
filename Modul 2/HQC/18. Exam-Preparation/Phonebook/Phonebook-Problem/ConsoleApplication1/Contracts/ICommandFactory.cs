namespace Phonebook.Contracts
{
    public interface ICommandFactory
    {
        IPhonebookCommand CreateCommand(string commandName, int argumentsCount);
    }
}