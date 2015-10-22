namespace CompanySampleData.ConsoleClient.DataGenerators
{
    using System;
    using System.Linq;

    using Contracts;

    using Data;

    public class ReportDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities data, IRandomGenerator random, int entriesCount)
        {
            var employeeIdsToAdd = data.Employees.Select(emp => emp.Id).ToList();
            foreach (var employeeId in employeeIdsToAdd)
            {
                var reportsCount = random.GenerateRandomNumber((int)(0.5 * entriesCount), (int)(1.5 * entriesCount));
                for (var report = 0; report < reportsCount; report++)
                {
                    var timeSpan = random.GenerateRandomNumber(-500, 500);
                    data.Reports.Add(new Report { EmployeeId = employeeId, Time = DateTime.Now.AddDays(timeSpan) });
                }
            }
        }
    }
}