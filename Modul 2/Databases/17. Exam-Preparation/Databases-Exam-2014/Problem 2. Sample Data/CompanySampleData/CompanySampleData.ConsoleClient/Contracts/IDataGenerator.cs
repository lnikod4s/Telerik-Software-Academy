namespace CompanySampleData.ConsoleClient.Contracts
{
    using Data;

    public interface IDataGenerator
    {
        void Generate(CompanyEntities data, IRandomGenerator random, int entriesCount);
    }
}