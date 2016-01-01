namespace Simplechat.ConsoleClient
{
    using System;
    using Data;
    using Models;

    internal class Program
    {
        private static readonly SimplechatData Simplechat = new SimplechatData();

        private static void Main()
        {
            var user = new User
                       {
                           Name = "Pesho",
                           ServerRole = ServerRole.Serveradmin,
                           LoginTime = DateTime.Now
                       };

            var message = new Message
                          {
                              Text = "Gosho, something bad happened! Please help me out.",
                              PostDate = DateTime.Now.AddMinutes(2),
                              PostUser = user
                          };

            var messageAsString = SimplechatData.GenerateMessageAsString(message);
            Console.WriteLine(messageAsString);
        }
    }
}