namespace PetStore.Importer.DataGenerators
{
    using Contracts;

    using Data;

    public class ColorDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            var initialColors = new[] { "black", "red", "white", "mixed" };
            for (var i = 0; i < count; i++)
            {
                var color = random.GetRandomElementFromArray(initialColors);
                data.Colors.Add(new Color { Color1 = color });
            }
        }
    }
}