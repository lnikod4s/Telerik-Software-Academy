namespace PetStore.Importer.Contracts
{
    using System;

    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomElementFromArray(string[] array);

        DateTime GetRandomDate(DateTime from, DateTime to);
    }
}