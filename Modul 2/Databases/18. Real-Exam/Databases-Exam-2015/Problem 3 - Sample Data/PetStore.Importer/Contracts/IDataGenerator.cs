namespace PetStore.Importer.Contracts
{
    using Data;

    public interface IDataGenerator
    {
        void GenerateData(PetStoreEntities data, IRandomGenerator random, int count);
    }
}