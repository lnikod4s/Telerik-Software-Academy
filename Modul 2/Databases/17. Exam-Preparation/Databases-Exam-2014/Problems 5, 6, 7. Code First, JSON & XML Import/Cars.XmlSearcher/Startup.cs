namespace Cars.XmlSearcher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using Data;

    using Mapping;

    internal class Program
    {
        private static void Main()
        {
            const string QueriesFileName = "Queries.xml";
            if (!File.Exists(QueriesFileName))
            {
                Console.WriteLine("{0} file not found!", QueriesFileName);
                return;
            }

            var serializer = new XmlSerializer(typeof(List<Query>), new XmlRootAttribute("Queries"));
            IEnumerable<Query> queries;
            using (var fs = new FileStream(QueriesFileName, FileMode.Open))
            {
                queries = (IEnumerable<Query>)serializer.Deserialize(fs);
            }

            foreach (var query in queries)
            {
                ProcessQuery(query);
            }
        }

        private static void ProcessQuery(Query query)
        {
            var db = new CarsDbContext();
            var dataQuery =
                db.Cars.Select(
                    car =>
                    new Car
                    {
                        Id = car.Id,
                        Manufacturer = car.Manufacturer.Name,
                        Model = car.Model,
                        Price = car.Price,
                        Year = car.Year,
                        TransmissionType =
                                car.TransmissionType == Models.TransmissionType.Manual ? "manual" : "automatic",
                        Dealer =
                                new Dealer
                                {
                                    Name = car.Dealer.Name,
                                    Cities = car.Dealer.Cities.Select(city => city.Name).ToList(),
                                }
                    });

            switch (query.OrderBy)
            {
                case "Id":
                    dataQuery = dataQuery.OrderBy(x => x.Id);
                    break;
                case "Year":
                    dataQuery = dataQuery.OrderBy(x => x.Year);
                    break;
                case "Model":
                    dataQuery = dataQuery.OrderBy(x => x.Model);
                    break;
                case "Price":
                    dataQuery = dataQuery.OrderBy(x => x.Price);
                    break;
                case "Manufacturer":
                    dataQuery = dataQuery.OrderBy(x => x.Manufacturer);
                    break;
                case "Dealer":
                    dataQuery = dataQuery.OrderBy(x => x.Dealer.Name);
                    break;
            }

            foreach (var whereClause in query.WhereClauses)
            {
                if (whereClause.PropertyName == "Id")
                {
                    var constant = int.Parse(whereClause.Value);
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereType.Equals:
                            dataQuery = dataQuery.Where(x => x.Id == constant);
                            break;
                        case WhereType.GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Id > constant);
                            break;
                        case WhereType.LessThan:
                            dataQuery = dataQuery.Where(x => x.Id < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Year")
                {
                    var constant = int.Parse(whereClause.Value);
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereType.Equals:
                            dataQuery = dataQuery.Where(x => x.Year == constant);
                            break;
                        case WhereType.GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Year > constant);
                            break;
                        case WhereType.LessThan:
                            dataQuery = dataQuery.Where(x => x.Year < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Price")
                {
                    var constant = decimal.Parse(whereClause.Value);
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereType.Equals:
                            dataQuery = dataQuery.Where(x => x.Price == constant);
                            break;
                        case WhereType.GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Price > constant);
                            break;
                        case WhereType.LessThan:
                            dataQuery = dataQuery.Where(x => x.Price < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Model")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereType.Equals:
                            dataQuery = dataQuery.Where(x => x.Model == whereClause.Value);
                            break;
                        case WhereType.Contains:
                            dataQuery = dataQuery.Where(x => x.Model.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Manufacturer")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereType.Equals:
                            dataQuery = dataQuery.Where(x => x.Manufacturer == whereClause.Value);
                            break;
                        case WhereType.Contains:
                            dataQuery = dataQuery.Where(x => x.Manufacturer.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Dealer")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereType.Equals:
                            dataQuery = dataQuery.Where(x => x.Dealer.Name == whereClause.Value);
                            break;
                        case WhereType.Contains:
                            dataQuery = dataQuery.Where(x => x.Dealer.Name.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "City")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereType.Equals:
                            dataQuery = dataQuery.Where(x => x.Dealer.Cities.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            var data = dataQuery.ToList();
            var serializer = new XmlSerializer(data.GetType(), new XmlRootAttribute("Cars"));
            using (var fs = new FileStream(query.OutputFileName, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }

            Console.WriteLine("{0} ready.", query.OutputFileName);
        }

        private static void CreateSampleQueries()
        {
            var queries = new List<Query>
                              {
                                  new Query
                                      {
                                          OrderBy = "Id",
                                          OutputFileName = "Result0.xml",
                                          WhereClauses = new List<WhereClause>
                                              {
                                                  new WhereClause
                                                      {
                                                          PropertyName = "City",
                                                          Type = "Equals",
                                                          Value = "Sofia"
                                                      },
                                                    new WhereClause
                                                        {
                                                            PropertyName = "Year",
                                                            Type = "GreaterThan",
                                                            Value = "1999"
                                                        }
                                              }
                                      }
                              };

            var serializer = new XmlSerializer(queries.GetType(), new XmlRootAttribute("Queries"));

            using (var fs = new FileStream("Queries.xml", FileMode.Create))
            {
                serializer.Serialize(fs, queries);
            }
        }

        private static void CreateSampleExport()
        {
            var db = new CarsDbContext();
            var cars =
                db.Cars.Where(car => car.Id <= 4)
                    .OrderBy(car => car.Id)
                    .Select(
                        car =>
                        new Car
                        {
                            Id = car.Id,
                            Manufacturer = car.Manufacturer.Name,
                            Model = car.Model,
                            Price = car.Price,
                            Year = car.Year,
                            TransmissionType =
                                    car.TransmissionType == Models.TransmissionType.Manual ? "manual" : "automatic",
                            Dealer =
                                    new Dealer
                                    {
                                        Name = car.Dealer.Name,
                                        Cities = car.Dealer.Cities.Select(city => city.Name).ToList(),
                                    }
                        })
                    .ToList();

            var serializer = new XmlSerializer(cars.GetType(), new XmlRootAttribute("Cars"));

            using (var fs = new FileStream("Cars.xml", FileMode.Create))
            {
                serializer.Serialize(fs, cars);
            }
        }
    }
}