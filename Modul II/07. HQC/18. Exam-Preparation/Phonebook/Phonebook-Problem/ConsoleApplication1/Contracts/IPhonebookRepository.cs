namespace Phonebook.Contracts
{
    using System.Collections.Generic;
    using Helpers;

    public interface IPhonebookRepository
    {
        bool AddPhone(string contactName, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldNumber, string newNumber);

        IEnumerable<ContactNameComparator> ListEntries(int startIndex, int count);
    }
}