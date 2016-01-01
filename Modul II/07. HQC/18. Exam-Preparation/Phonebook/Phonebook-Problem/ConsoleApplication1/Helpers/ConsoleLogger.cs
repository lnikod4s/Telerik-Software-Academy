namespace Phonebook.Helpers
{
    using System;
    using System.Text;
    using Contracts;

    public class ConsoleLogger : ILogger
    {
        private readonly StringBuilder output;

        public ConsoleLogger()
        {
            this.output = new StringBuilder();
        }

        public void Append(string textMessage)
        {
            this.output.Append(textMessage);
        }

        public void AppendLine(string textMessage)
        {
            this.output.AppendLine(textMessage);
        }

        public void PrintAll()
        {
            Console.WriteLine(this.output);
        }
    }
}