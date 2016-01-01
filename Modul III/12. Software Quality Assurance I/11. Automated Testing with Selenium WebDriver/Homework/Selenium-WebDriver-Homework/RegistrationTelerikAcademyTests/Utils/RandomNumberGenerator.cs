namespace RegistrationTelerikAcademyTests.Utils
{
    using System;

    public static class RandomNumberGenerator
    {
        private static readonly Random RandomInstance = new Random();

        private static readonly object SyncLock = new object();

        public static int Generate(int min, int max)
        {
            lock (SyncLock)
            {
                // synchronize
                return RandomInstance.Next(min, max);
            }
        }
    }
}