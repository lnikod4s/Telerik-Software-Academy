namespace PetStore.Importer.DataGenerators
{
    using System.Linq;

    using Contracts;

    using Data;

    public class ProductDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            var categoryIds = data.Categories.Select(c => c.Id).ToList();
            foreach (var categoryId in categoryIds)
            {
                var productsCount = random.GetRandomNumber((int)(0.5 * count), (int)(1.5 * count));
                for (var i = 0; i < productsCount; i++)
                {
                    var product = new Product
                        {
                            Price = random.GetRandomNumber(10, 1000),
                            Name = random.GetRandomString(random.GetRandomNumber(5, 25)),
                            CategoryId = categoryId
                        };

                    data.Products.Add(product);
                }
            }
        }
    }
}