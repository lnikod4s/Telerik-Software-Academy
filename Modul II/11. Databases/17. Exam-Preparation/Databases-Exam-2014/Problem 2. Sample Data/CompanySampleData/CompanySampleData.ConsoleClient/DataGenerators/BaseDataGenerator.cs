namespace CompanySampleData.ConsoleClient.DataGenerators
{
    using Contracts;

    using Data;

    public class BaseDataGenerator
    {
        public BaseDataGenerator(IDataGenerator dataGenerator, int entriesCount)
        {
            this.DataGenerator = dataGenerator;
            this.EntriesCount = entriesCount;
        }

        public int EntriesCount { get; }

        public IDataGenerator DataGenerator { get; }

        public void Generate(CompanyEntities data, IRandomGenerator random)
        {
            this.DataGenerator.Generate(data, random, this.EntriesCount);
        }
    }
}