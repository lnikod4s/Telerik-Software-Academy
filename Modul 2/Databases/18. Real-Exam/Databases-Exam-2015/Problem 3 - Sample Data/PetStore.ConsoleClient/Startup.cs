namespace PetStore.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    using Data;

    using Importer;
    using Importer.DataGenerators;

    public class Startup
    {
        public static void Main()
        {
            var dataGeneratorExecutors = new List<DataGeneratorExecutor>
                {
                    new DataGeneratorExecutor(new CategoryDataGenerator(), 50),
                    new DataGeneratorExecutor(new CountryDataGenerator(), 20),
                    new DataGeneratorExecutor(new SpeciesDataGenerator(), 5),
                    new DataGeneratorExecutor(new PetDataGenerator(), 50),
                    new DataGeneratorExecutor(new ColorDataGenerator(), 10),
                    new DataGeneratorExecutor(new ProductSpeciesDataGenerator(), 400),
                    new DataGeneratorExecutor(new ProductDataGenerator(), 10)
                };

            foreach (var dataGeneratorExecutor in dataGeneratorExecutors)
            {
                using (var data = new PetStoreEntities())
                {
                    data.Configuration.AutoDetectChangesEnabled = false;

                    Console.WriteLine("Staring {0}...", dataGeneratorExecutor.DataGenerator.GetType().Name);
                    dataGeneratorExecutor.Execute(data, RandomGenerator.Instance);
                    Console.WriteLine("Saving {0}...", dataGeneratorExecutor.DataGenerator.GetType().Name);
                    data.SaveChanges();
                    Console.WriteLine("Finished {0}.", dataGeneratorExecutor.DataGenerator.GetType().Name);
                }
            }
        }
    }
}