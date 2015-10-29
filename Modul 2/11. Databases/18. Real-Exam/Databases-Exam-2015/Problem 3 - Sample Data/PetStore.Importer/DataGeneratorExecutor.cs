namespace PetStore.Importer
{
    using Contracts;

    using Data;

    public class DataGeneratorExecutor
    {
        public DataGeneratorExecutor(IDataGenerator dataGenerator, int entriesCount)
        {
            this.DataGenerator = dataGenerator;
            this.EntriesCount = entriesCount;
        }

        public int EntriesCount { get; }

        public IDataGenerator DataGenerator { get; }

        public void Execute(PetStoreEntities data, IRandomGenerator randomGenerator)
        {
            this.DataGenerator.GenerateData(data, randomGenerator, this.EntriesCount);
        }
    }
}