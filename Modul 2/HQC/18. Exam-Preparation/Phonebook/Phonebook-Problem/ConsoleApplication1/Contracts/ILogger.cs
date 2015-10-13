namespace Phonebook.Contracts
{
    public interface ILogger
    {
        void Append(string textMessage);

        void AppendLine(string textMessage);

        void PrintAll();
    }
}