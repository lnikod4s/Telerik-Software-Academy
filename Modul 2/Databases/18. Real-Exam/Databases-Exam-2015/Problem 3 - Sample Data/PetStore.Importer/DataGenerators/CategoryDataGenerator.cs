namespace PetStore.Importer.DataGenerators
{
    using System.Collections.Generic;

    using Contracts;

    using Data;

    public class CategoryDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            var uniqueNames = new HashSet<string>();
            while (uniqueNames.Count < count)
            {
                uniqueNames.Add(random.GetRandomString(random.GetRandomNumber(5, 20)));
            }

            foreach (var uniqueName in uniqueNames)
            {
                data.Categories.Add(new Category { Name = uniqueName });
            }
        }
    }
}