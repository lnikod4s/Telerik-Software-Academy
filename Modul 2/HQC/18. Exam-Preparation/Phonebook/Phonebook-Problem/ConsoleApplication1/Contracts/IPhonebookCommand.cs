namespace Phonebook.Contracts
{
    using System.Collections.Generic;

    public interface IPhonebookCommand
    {
        void ExecuteCommand(IList<string> cmdParameters);
    }
}