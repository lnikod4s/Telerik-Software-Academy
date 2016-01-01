namespace CompanySampleData.ConsoleClient.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Data;

    public class EmployeesProjectsDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities data, IRandomGenerator random, int entriesCount)
        {
            var employeesIdsToAdd = data.Employees.Select(emp => emp.Id).ToList();
            var projectIdsToAdd = data.Projects.Select(pro => pro.Id).ToList();
            foreach (var employeeId in employeesIdsToAdd)
            {
                var employeeProjectsCount = random.GenerateRandomNumber(
                    (int)(entriesCount * 0.5),
                    (int)(entriesCount * 1.5));
                var projectIds = new HashSet<int>();
                while (projectIds.Count < employeeProjectsCount)
                {
                    var randomProjectId = projectIdsToAdd[random.GenerateRandomNumber(0, projectIdsToAdd.Count - 1)];
                    projectIds.Add(randomProjectId);
                }

                foreach (var projectId in projectIds)
                {
                    var timeSpan = random.GenerateRandomNumber(100, 500);
                    data.EmployeesProjects.Add(
                        new EmployeesProject
                            {
                                EmployeeId = employeeId,
                                ProjectId = projectId,
                                StartDate = DateTime.Now.AddDays(-timeSpan),
                                EndDate = DateTime.Now.AddDays(timeSpan)
                            });
                }
            }
        }
    }
}