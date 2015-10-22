namespace CompanySampleData.ConsoleClient.DataGenerators
{
    using Contracts;

    using Data;

    public class ProjectDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities data, IRandomGenerator random, int entriesCount)
        {
            for (var entry = 0; entry < entriesCount; entry++)
            {
                data.Projects.Add(
                    new Project { Name = random.GenerateRandomString(random.GenerateRandomNumber(5, 50)) });
            }
        }
    }
}