namespace CompanySampleData.ConsoleClient.DataGenerators
{
    using System.Collections.Generic;

    using Contracts;

    using Data;

    public class DepartmentDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities data, IRandomGenerator random, int entriesCount)
        {
            var uniqueNames = new HashSet<string>();
            while (uniqueNames.Count < entriesCount)
            {
                var uniqueName = random.GenerateRandomString(random.GenerateRandomNumber(10, 50));
                uniqueNames.Add(uniqueName);
            }

            foreach (var uniqueName in uniqueNames)
            {
                data.Departments.Add(new Department { Name = uniqueName });
            }
        }
    }
}