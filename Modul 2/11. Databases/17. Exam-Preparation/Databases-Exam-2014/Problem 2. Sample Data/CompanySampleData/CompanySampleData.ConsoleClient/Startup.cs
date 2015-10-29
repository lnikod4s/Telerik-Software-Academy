namespace CompanySampleData.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    using Data;

    using DataGenerators;

    internal class Startup
    {
        private static void Main()
        {
            var dataGenerators = new List<BaseDataGenerator>
                {
                    new BaseDataGenerator(new DepartmentDataGenerator(), 100),
                    new BaseDataGenerator(new EmployeeDataGenerator(), 5000),
                    new BaseDataGenerator(new ProjectDataGenerator(), 1000),
                    new BaseDataGenerator(new EmployeesProjectsDataGenerator(), 10),
                    new BaseDataGenerator(new ReportDataGenerator(), 50)
                };

            foreach (var dataGenerator in dataGenerators)
            {
                using (var db = new CompanyEntities())
                {
                    db.Configuration.AutoDetectChangesEnabled = false;

                    Console.WriteLine("Importing data...");
                    dataGenerator.Generate(db, RandomGenerator.Instance);
                    Console.WriteLine("Save changes...");
                    db.SaveChanges();
                    Console.WriteLine("Finished importing data...");
                }
            }
        }
    }
}