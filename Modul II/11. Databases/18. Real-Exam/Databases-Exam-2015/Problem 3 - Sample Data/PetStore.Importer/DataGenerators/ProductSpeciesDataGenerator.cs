namespace PetStore.Importer.DataGenerators
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Data;

    public class ProductSpeciesDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            var productIds = data.Products.Select(p => p.Id).ToList();
            var speciesIds = data.Species.Select(s => s.Id).ToList();
            foreach (var speciesId in speciesIds)
            {
                var productSpeciesCount = random.GetRandomNumber((int)(count * 0.5), (int)(count * 1.5));
                var currentSpecies = new HashSet<int>();
                while (currentSpecies.Count < productSpeciesCount)
                {
                    var randomProductId = productIds[random.GetRandomNumber(0, productIds.Count - 1)];
                    currentSpecies.Add(randomProductId);
                }

                foreach (var productId in currentSpecies)
                {
                    data.ProductSpecies.Add(new ProductSpecies { SpeciesId = speciesId, ProductId = productId });
                }
            }
        }
    }
}