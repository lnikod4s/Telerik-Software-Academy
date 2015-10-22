namespace Cars.JsonImporter
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    using Data;

    using Mapping;

    using Models;

    using Newtonsoft.Json;

    internal class Startup
    {
        private static void Main()
        {
            ImportData();
        }

        private static void ImportData()
        {
            const string JsonFilesPath = "/JsonFiles/";
            const string Ending = ".json";

            var carsToAdd = Directory.GetFiles(Directory.GetCurrentDirectory() + JsonFilesPath)
                .Where(file => file.EndsWith(Ending))
                .Select(File.ReadAllText)
                .SelectMany(JsonConvert.DeserializeObject<IEnumerable<JsonCarModel>>).ToList();

            var manufacturerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var citiesNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var dealerNames = new HashSet<string>();
            foreach (var car in carsToAdd)
            {
                manufacturerNames.Add(car.ManufacturerName);
                citiesNames.Add(car.Dealer.City);
                dealerNames.Add(car.Dealer.Name);
            }

            var db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;

            Console.WriteLine("Adding cities...");
            foreach (var cityName in citiesNames)
            {
                db.Cities.AddOrUpdate(city => city.Name, new City { Name = cityName });
            }

            db.SaveChanges();
            Console.WriteLine("Cities successfully added!");

            Console.WriteLine("Adding manufacturers...");
            foreach (var manufacturerName in manufacturerNames)
            {
                db.Manufacturers.AddOrUpdate(m => m.Name, new Manufacturer { Name = manufacturerName });
            }

            db.SaveChanges();
            Console.WriteLine("Manufacturers successfully added!");

            Console.WriteLine("Adding dealers...");
            foreach (var dealerName in dealerNames)
            {
                db.Dealers.AddOrUpdate(d => d.Name, new Dealer { Name = dealerName });
            }

            db.SaveChanges();
            Console.WriteLine("Dealers successfully added!");

            Console.WriteLine("Adding cars...");
            foreach (var car in carsToAdd)
            {
                var dbCar = new Car
                {
                    Dealer = db.Dealers.FirstOrDefault(d => d.Name == car.Dealer.Name),
                    Manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == car.ManufacturerName),
                    Model = car.Model,
                    Price = car.Price,
                    TransmissionType = car.TransmissionType,
                    Year = car.Year
                };

                db.Cars.AddOrUpdate(dbCar);
                db.SaveChanges();
            }

            db.SaveChanges();
            Console.WriteLine("Cars successfully added!");
        }
    }
}