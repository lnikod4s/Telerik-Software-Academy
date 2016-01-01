namespace CompanySampleData.ConsoleClient.Contracts
{
    public interface IRandomGenerator
    {
        int GenerateRandomNumber(int min, int max);

        string GenerateRandomString(int length);
    }
}