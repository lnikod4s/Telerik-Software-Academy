namespace CompanySampleData.ConsoleClient
{
    using System;

    using Contracts;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance => instance ?? (instance = new RandomGenerator());

        public int GenerateRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GenerateRandomString(int length)
        {
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GenerateRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }
    }
}