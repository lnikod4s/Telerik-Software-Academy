namespace RegistrationTelerikAcademyTests.Utils
{
    using System;
    using System.Linq;

    public static class RandomStringGenerator
    {
        public static string Generate(int length)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(Chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}