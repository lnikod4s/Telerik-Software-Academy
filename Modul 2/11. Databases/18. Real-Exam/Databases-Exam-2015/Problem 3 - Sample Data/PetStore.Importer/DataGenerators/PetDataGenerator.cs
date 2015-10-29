namespace PetStore.Importer.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Data;

    public class PetDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            var petsToAdd = new List<Pet>();
            var colorIds = data.Colors.Select(c => c.Id).ToList();
            var speciesIds = data.Species.Select(s => s.Id).ToList();
            for (var i = 0; i < count; i++)
            {
                var pet = new Pet
                    {
                        Price = random.GetRandomNumber(5, 2500),
                        BirthDateTime = random.GetRandomDate(new DateTime(2010, 1, 1), DateTime.Now.AddDays(-60)),
                        Breed = random.GetRandomString(random.GetRandomNumber(5, 30)),
                        ColorId = colorIds[random.GetRandomNumber(0, colorIds.Count - 1)],
                        SpeciesId = speciesIds[random.GetRandomNumber(0, speciesIds.Count - 1)]
                    };

                petsToAdd.Add(pet);
            }

            data.Pets.AddRange(petsToAdd);
        }
    }
}