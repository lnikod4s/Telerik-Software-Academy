namespace PetStore.Importer.DataGenerators
{
    using System.Linq;

    using Contracts;

    using Data;

    public class SpeciesDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            var countryIds = data.Countries.Select(c => c.Id).ToList();
            foreach (var countryId in countryIds)
            {
                var speciesCount = random.GetRandomNumber((int)(0.5 * count), (int)(1.5 * count));
                for (var i = 0; i < speciesCount; i++)
                {
                    var species = new Species
                        {
                            Name = random.GetRandomString(random.GetRandomNumber(5, 50)),
                            CountryId = countryId
                        };

                    data.Species.Add(species);
                }
            }
        }
    }
}