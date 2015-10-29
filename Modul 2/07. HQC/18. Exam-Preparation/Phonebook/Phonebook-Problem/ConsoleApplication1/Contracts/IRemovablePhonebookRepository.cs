namespace Phonebook.Contracts
{
    public interface IRemovablePhonebookRepository : IPhonebookRepository
    {
        void Remove(string phoneNumber);
    }
}